using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StoreMS.Data;
using StoreMS.Repositories;

namespace StoreMS.Forms
{
    public partial class DashboardHomeForm : Form
    {
        private readonly ProductRepository productRepo;

        public int CurrentUserId { get; set; }
        public string CurrentFullName { get; set; }
        public string CurrentRole { get; set; }

        public DashboardHomeForm()
        {
            InitializeComponent();
            productRepo = new ProductRepository();
        }

        public DashboardHomeForm(int userId, string fullName, string role) : this()
        {
            CurrentUserId = userId;
            CurrentFullName = fullName;
            CurrentRole = role;
        }

        private void DashboardHomeForm_Load(object sender, EventArgs e)
        {
            SetGreeting();
            LoadKpis();
            LoadRecentSales();
            LoadLowStock();
        }

        private void SetGreeting()
        {
            int hour = DateTime.Now.Hour;
            string timeOfDay = hour < 12 ? "morning" : (hour < 18 ? "afternoon" : "evening");
            string displayName = !string.IsNullOrEmpty(CurrentFullName) ? CurrentFullName : "Admin";

            lblGreeting.Text = "Good " + timeOfDay + ", " + displayName;
            lblDateToday.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
        }

        private void LoadKpis()
        {
            try
            {
                var products = productRepo.GetAll();
                int productCount = products.Count;
                int lowStockCount = products.Count(p => p.StockQty <= 10);
                int categoryCount = products
                    .Where(p => !string.IsNullOrWhiteSpace(p.CategoryName))
                    .Select(p => p.CategoryName)
                    .Distinct()
                    .Count();

                lblKpiProductsValue.Text = productCount.ToString("N0");
                lblKpiProductsDelta.Text = "Across " + categoryCount + " categories";
                lblKpiLowStockValue.Text = lowStockCount.ToString("N0");
                lblKpiLowStockDelta.Text = lowStockCount > 0 ? "Needs restocking" : "Stock looks healthy";
            }
            catch (Exception)
            {
                lblKpiProductsValue.Text = "0";
                lblKpiProductsDelta.Text = "Product data unavailable";
                lblKpiLowStockValue.Text = "0";
                lblKpiLowStockDelta.Text = "Stock data unavailable";
            }

            // ទាញយកទឹកប្រាក់សរុប និងចំនួនបញ្ជាទិញថ្ងៃនេះពី tbSales
            DataTable salesSummary = TryGetDataTable(@"
                SELECT 
                    COUNT(*) AS OrderCount,
                    ISNULL(SUM(TotalAmount), 0) AS TotalSales
                FROM tbSales
                WHERE CAST(SaleDate AS date) = CAST(GETDATE() AS date)");

            if (salesSummary != null && salesSummary.Rows.Count > 0)
            {
                DataRow row = salesSummary.Rows[0];
                decimal totalSales = row["TotalSales"] != DBNull.Value ? Convert.ToDecimal(row["TotalSales"]) : 0m;
                int orderCount = row["OrderCount"] != DBNull.Value ? Convert.ToInt32(row["OrderCount"]) : 0;

                lblKpiSalesValue.Text = totalSales.ToString("$#,##0.00");
                lblKpiOrdersValue.Text = orderCount.ToString("N0");
                lblKpiSalesDelta.Text = "Today's revenue";
                lblKpiOrdersDelta.Text = "Orders today";
            }
            else
            {
                lblKpiSalesValue.Text = "$0.00";
                lblKpiOrdersValue.Text = "0";
                lblKpiSalesDelta.Text = "Sales data unavailable";
                lblKpiOrdersDelta.Text = "Orders data unavailable";
            }
        }

        private void LoadRecentSales()
        {
            dgvRecentSales.Rows.Clear();

            // ទាញយកទិន្នន័យលក់ចុងក្រោយដោយដក Customer ចេញ
            DataTable sales = TryGetDataTable(@"
                SELECT TOP 10
                    s.InvoiceNo AS Invoice,
                    CAST(ISNULL(SUM(sd.Quantity), 0) AS varchar(20)) AS Items,
                    s.TotalAmount AS Total,
                    s.PaymentMethod AS Payment,
                    s.SaleDate AS SaleTime
                FROM tbSales s
                LEFT JOIN tbSaleDetails sd ON s.SaleID = sd.SaleID
                GROUP BY s.SaleID, s.InvoiceNo, s.TotalAmount, s.PaymentMethod, s.SaleDate
                ORDER BY s.SaleDate DESC");

            if (sales == null || sales.Rows.Count == 0)
            {
                dgvRecentSales.Rows.Add("No sales", "No transactions yet", "$0.00", "-", "-");
                return;
            }

            foreach (DataRow row in sales.Rows)
            {
                decimal total = row["Total"] != DBNull.Value ? Convert.ToDecimal(row["Total"]) : 0m;
                string time = row["SaleTime"] != DBNull.Value
                    ? Convert.ToDateTime(row["SaleTime"]).ToString("h:mm tt")
                    : "-";

                dgvRecentSales.Rows.Add(
                    row["Invoice"]?.ToString(),
                    row["Items"]?.ToString(),
                    total.ToString("$#,##0.00"),
                    row["Payment"]?.ToString(),
                    time);
            }
        }

        private void LoadLowStock()
        {
            flpLowStock.Controls.Clear();

            try
            {
                var items = productRepo.GetAll()
                    .Where(p => p.StockQty <= 10)
                    .OrderBy(p => p.StockQty)
                    .ThenBy(p => p.ProductName)
                    .Take(10)
                    .ToList();

                if (items.Count == 0)
                {
                    flpLowStock.Controls.Add(BuildMessageRow("All products have enough stock."));
                    return;
                }

                foreach (var item in items)
                {
                    flpLowStock.Controls.Add(BuildStockRow(item.ProductName, item.StockQty, 10));
                }
            }
            catch (Exception)
            {
                flpLowStock.Controls.Add(BuildMessageRow("Stock data is unavailable."));
            }
        }

        private Control BuildStockRow(string name, int qty, int threshold)
        {
            Color badgeColor = qty <= threshold / 3
                ? Color.FromArgb(220, 38, 38)
                : Color.FromArgb(217, 119, 6);

            var row = new Panel
            {
                Size = new Size(268, 54),
                Margin = new Padding(0, 0, 0, 4)
            };

            var lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI Semibold", 9.5F),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(0, 4),
                Size = new Size(200, 20),
                AutoEllipsis = true
            };

            var lblSub = new Label
            {
                Text = qty + " left in stock",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(0, 26),
                Size = new Size(200, 18)
            };

            var badge = new Guna.UI2.WinForms.Guna2Panel
            {
                FillColor = badgeColor,
                BorderRadius = 10,
                Size = new Size(44, 20),
                Location = new Point(210, 15)
            };

            var lblBadge = new Label
            {
                Text = qty.ToString(),
                Font = new Font("Segoe UI Semibold", 8.5F),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            badge.Controls.Add(lblBadge);

            var divider = new Panel
            {
                BackColor = Color.FromArgb(241, 245, 249),
                Dock = DockStyle.Bottom,
                Height = 1
            };

            row.Controls.Add(divider);
            row.Controls.Add(badge);
            row.Controls.Add(lblSub);
            row.Controls.Add(lblName);

            return row;
        }

        private Control BuildMessageRow(string message)
        {
            return new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Size = new Size(268, 42),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true,
                Margin = new Padding(0, 0, 0, 4)
            };
        }

        private DataTable TryGetDataTable(string query)
        {
            try
            {
                return Database.ExecuteQuery(query);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = ParentForm as DashboardForm;
            dashboard?.NavigateToStock();
        }
    }
}