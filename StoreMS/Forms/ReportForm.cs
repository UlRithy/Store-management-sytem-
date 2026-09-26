using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using StoreMS.Data;

namespace StoreMS.Forms
{
    public partial class ReportForm : Form
    {
        // ============================================================
        // PRINT VARIABLES
        // IMPORTANT: These are declared ONLY ONCE in this class.
        // ============================================================
        private readonly PrintDocument reportPrintDocument = new PrintDocument();
        private int reportPrintRowIndex = 0;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public ReportForm()
        {
            InitializeComponent();

            // Report type
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.Add("Daily Sales");
            guna2ComboBox1.Items.Add("Monthly Sales");
            guna2ComboBox1.Items.Add("Sales Report");

            if (guna2ComboBox1.Items.Count > 0)
                guna2ComboBox1.SelectedIndex = 0;

            // Date format
            guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker1.CustomFormat = "yyyy-MM-dd";

            guna2DateTimePicker2.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker2.CustomFormat = "yyyy-MM-dd";

            // Default dates
            guna2DateTimePicker1.Value = DateTime.Today;
            guna2DateTimePicker2.Value = DateTime.Today;

            // Grid
            SetupGrid();

            // Print
            reportPrintDocument.BeginPrint += ReportPrintDocument_BeginPrint;
            reportPrintDocument.PrintPage += ReportPrintDocument_PrintPage;
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSalesReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading sales report:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // SETUP GRID
        // ============================================================
        private void SetupGrid()
        {
            guna2DataGridView1.AutoGenerateColumns = false;

            guna2DataGridView1.Columns[0].HeaderText = "Date";
            guna2DataGridView1.Columns[1].HeaderText = "Invoice No";
            guna2DataGridView1.Columns[2].HeaderText = "Customer";
            guna2DataGridView1.Columns[3].HeaderText = "Qty";
            guna2DataGridView1.Columns[4].HeaderText = "Total Amount";

            guna2DataGridView1.Columns[0].Width = 120;
            guna2DataGridView1.Columns[1].Width = 220;
            guna2DataGridView1.Columns[2].Width = 220;
            guna2DataGridView1.Columns[3].Width = 100;
            guna2DataGridView1.Columns[4].Width = 150;

            guna2DataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            guna2DataGridView1.MultiSelect = false;
        }

        // ============================================================
        // LOAD SALES REPORT
        // ============================================================
        private void LoadSalesReport()
        {
            DateTime fromDate = guna2DateTimePicker1.Value.Date;
            DateTime toDate = guna2DateTimePicker2.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show(
                    "From date cannot be greater than To date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataTable dt = new DataTable();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT
                        s.SaleID,
                        s.SaleDate,
                        s.InvoiceNo,
                        ISNULL(c.CustomerName, 'Walk-in Customer') AS CustomerName,
                        ISNULL(SUM(sd.Quantity), 0) AS TotalQty,
                        ISNULL(s.TotalAmount, 0) AS TotalAmount,
                        ISNULL(s.PaymentMethod, 'Cash') AS PaymentMethod
                    FROM tbSales s
                    LEFT JOIN tbCustomers c
                        ON s.CustomerID = c.CustomerID
                    LEFT JOIN tbSaleDetails sd
                        ON s.SaleID = sd.SaleID
                    WHERE s.SaleDate >= @FromDate
                      AND s.SaleDate < DATEADD(DAY, 1, @ToDate)
                    GROUP BY
                        s.SaleID,
                        s.SaleDate,
                        s.InvoiceNo,
                        c.CustomerName,
                        s.TotalAmount,
                        s.PaymentMethod
                    ORDER BY s.SaleDate DESC;
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime)
                        .Value = fromDate;

                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime)
                        .Value = toDate;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            // Clear grid
            guna2DataGridView1.Rows.Clear();

            decimal totalSales = 0m;
            int totalItems = 0;

            foreach (DataRow row in dt.Rows)
            {
                DateTime saleDate = Convert.ToDateTime(row["SaleDate"]);

                string invoiceNo =
                    row["InvoiceNo"] == DBNull.Value
                        ? ""
                        : row["InvoiceNo"].ToString();

                string customerName =
                    row["CustomerName"] == DBNull.Value
                        ? "Walk-in Customer"
                        : row["CustomerName"].ToString();

                int qty =
                    row["TotalQty"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(row["TotalQty"]);

                decimal totalAmount =
                    row["TotalAmount"] == DBNull.Value
                        ? 0m
                        : Convert.ToDecimal(row["TotalAmount"]);

                guna2DataGridView1.Rows.Add(
                    saleDate.ToString("yyyy-MM-dd"),
                    invoiceNo,
                    customerName,
                    qty.ToString(),
                    totalAmount.ToString("$0.00")
                );

                totalItems += qty;
                totalSales += totalAmount;
            }

            // Summary
            lblTotalItems.Text = totalItems.ToString();
            label2.Text = totalSales.ToString("$0.00");
        }

        // ============================================================
        // SHOW REPORT BUTTON
        // Designer event:
        // guna2Button4_Click
        // ============================================================
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSalesReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading sales report:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EXPORT BUTTON
        // Designer event:
        // guna2Button3_Click
        // ============================================================
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no report data to export.",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Export Sales Report";
                saveDialog.Filter =
                    "CSV File (*.csv)|*.csv|" +
                    "Text File (*.txt)|*.txt";

                saveDialog.FileName =
                    "SalesReport_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".csv";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Header
                    sb.AppendLine(
                        "Date,Invoice No,Customer,Qty,Total Amount");

                    // Data
                    foreach (DataGridViewRow row
                             in guna2DataGridView1.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string date =
                            EscapeCsv(
                                Convert.ToString(row.Cells[0].Value));

                        string invoice =
                            EscapeCsv(
                                Convert.ToString(row.Cells[1].Value));

                        string customer =
                            EscapeCsv(
                                Convert.ToString(row.Cells[2].Value));

                        string qty =
                            EscapeCsv(
                                Convert.ToString(row.Cells[3].Value));

                        string total =
                            EscapeCsv(
                                Convert.ToString(row.Cells[4].Value));

                        sb.AppendLine(
                            $"{date},{invoice},{customer},{qty},{total}");
                    }

                    File.WriteAllText(
                        saveDialog.FileName,
                        sb.ToString(),
                        Encoding.UTF8);

                    MessageBox.Show(
                        "Sales report exported successfully.",
                        "Export Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error exporting report:\n\n" + ex.Message,
                        "Export Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // PRINT BUTTON
        // Designer event:
        // guna2Button2_Click
        // ============================================================
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no report data to print.",
                    "Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                using (PrintPreviewDialog preview =
                       new PrintPreviewDialog())
                {
                    preview.Document = reportPrintDocument;
                    preview.Width = 1000;
                    preview.Height = 700;

                    preview.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error printing report:\n\n" + ex.Message,
                    "Print Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PRINT BEGIN
        // ============================================================
        private void ReportPrintDocument_BeginPrint(
            object sender,
            PrintEventArgs e)
        {
            reportPrintRowIndex = 0;
        }

        // ============================================================
        // PRINT PAGE
        // ============================================================
        private void ReportPrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font titleFont =
                   new Font("Segoe UI", 18, FontStyle.Bold))
            using (Font headerFont =
                   new Font("Segoe UI", 10, FontStyle.Bold))
            using (Font bodyFont =
                   new Font("Segoe UI", 9))
            using (Font summaryFont =
                   new Font("Segoe UI", 10, FontStyle.Bold))
            using (Pen pen =
                   new Pen(Color.LightGray))
            {
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                // ----------------------------------------------------
                // TITLE
                // ----------------------------------------------------
                g.DrawString(
                    "SALES REPORT",
                    titleFont,
                    Brushes.Black,
                    x,
                    y);

                y += 40;

                // ----------------------------------------------------
                // DATE RANGE
                // ----------------------------------------------------
                string dateRange =
                    "From: " +
                    guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") +
                    "    To: " +
                    guna2DateTimePicker2.Value.ToString("yyyy-MM-dd");

                g.DrawString(
                    dateRange,
                    bodyFont,
                    Brushes.Black,
                    x,
                    y);

                y += 35;

                // ----------------------------------------------------
                // COLUMN WIDTHS
                // ----------------------------------------------------
                float wDate = 90;
                float wInvoice = 150;
                float wCustomer = 150;
                float wQty = 60;
                float wTotal = 100;

                float rowHeight = 30;

                // ----------------------------------------------------
                // HEADER
                // ----------------------------------------------------
                g.DrawString(
                    "Date",
                    headerFont,
                    Brushes.Black,
                    x,
                    y);

                g.DrawString(
                    "Invoice No",
                    headerFont,
                    Brushes.Black,
                    x + wDate,
                    y);

                g.DrawString(
                    "Customer",
                    headerFont,
                    Brushes.Black,
                    x + wDate + wInvoice,
                    y);

                g.DrawString(
                    "Qty",
                    headerFont,
                    Brushes.Black,
                    x + wDate + wInvoice + wCustomer,
                    y);

                g.DrawString(
                    "Total",
                    headerFont,
                    Brushes.Black,
                    x + wDate + wInvoice + wCustomer + wQty,
                    y);

                y += rowHeight;

                g.DrawLine(
                    pen,
                    x,
                    y - 5,
                    e.MarginBounds.Right,
                    y - 5);

                // ----------------------------------------------------
                // DATA
                // ----------------------------------------------------
                while (reportPrintRowIndex <
                       guna2DataGridView1.Rows.Count)
                {
                    DataGridViewRow row =
                        guna2DataGridView1.Rows[
                            reportPrintRowIndex];

                    if (row.IsNewRow)
                    {
                        reportPrintRowIndex++;
                        continue;
                    }

                    if (y + rowHeight >
                        e.MarginBounds.Bottom - 60)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    string date =
                        Convert.ToString(row.Cells[0].Value);

                    string invoice =
                        Convert.ToString(row.Cells[1].Value);

                    string customer =
                        Convert.ToString(row.Cells[2].Value);

                    string qty =
                        Convert.ToString(row.Cells[3].Value);

                    string total =
                        Convert.ToString(row.Cells[4].Value);

                    g.DrawString(
                        date,
                        bodyFont,
                        Brushes.Black,
                        x,
                        y);

                    g.DrawString(
                        invoice,
                        bodyFont,
                        Brushes.Black,
                        x + wDate,
                        y);

                    g.DrawString(
                        customer,
                        bodyFont,
                        Brushes.Black,
                        x + wDate + wInvoice,
                        y);

                    g.DrawString(
                        qty,
                        bodyFont,
                        Brushes.Black,
                        x + wDate + wInvoice + wCustomer,
                        y);

                    g.DrawString(
                        total,
                        bodyFont,
                        Brushes.Black,
                        x + wDate + wInvoice + wCustomer + wQty,
                        y);

                    y += rowHeight;

                    g.DrawLine(
                        pen,
                        x,
                        y - 5,
                        e.MarginBounds.Right,
                        y - 5);

                    reportPrintRowIndex++;
                }

                // ----------------------------------------------------
                // SUMMARY
                // ----------------------------------------------------
                y += 20;

                g.DrawString(
                    "Total Items:",
                    summaryFont,
                    Brushes.Black,
                    x,
                    y);

                g.DrawString(
                    lblTotalItems.Text,
                    summaryFont,
                    Brushes.Black,
                    x + 100,
                    y);

                g.DrawString(
                    "Total Sales:",
                    summaryFont,
                    Brushes.Black,
                    x + 250,
                    y);

                g.DrawString(
                    label2.Text,
                    summaryFont,
                    Brushes.Black,
                    x + 350,
                    y);

                e.HasMorePages = false;
            }
        }

        // ============================================================
        // CSV ESCAPE
        // ============================================================
        private string EscapeCsv(string value)
        {
            if (value == null)
                return "";

            value = value.Replace("\"", "\"\"");

            if (value.Contains(",") ||
                value.Contains("\"") ||
                value.Contains("\n") ||
                value.Contains("\r"))
            {
                return "\"" + value + "\"";
            }

            return value;
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        // ============================================================
        // LABEL CLICK
        // Designer currently has label2_Click event.
        // It does not need to do anything.
        // ============================================================

    }
}