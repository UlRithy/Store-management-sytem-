using System;
using System.Drawing;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class DashboardHomeForm : Form
    {
        public DashboardHomeForm()
        {
            InitializeComponent();
        }

        private void DashboardHomeForm_Load(object sender, EventArgs e)
        {
            SetGreeting();
            LoadRecentSales();
            LoadLowStock();
        }

        private void SetGreeting()
        {
            int hour = DateTime.Now.Hour;
            string timeOfDay = hour < 12 ? "morning" : (hour < 18 ? "afternoon" : "evening");
            lblGreeting.Text = "Good " + timeOfDay + ", Sok Dara";
            lblDateToday.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
        }

        // TODO: replace with a real query against the sales/orders table.
        private void LoadRecentSales()
        {
            dgvRecentSales.Rows.Clear();

            var sample = new (string Invoice, string Customer, string Items, string Total, string Payment, string Time)[]
            {
                ("INV-1042", "Chan Sopheak",   "4", "$28.50", "Cash",     "10:42 AM"),
                ("INV-1041", "Walk-in",        "2", "$9.00",  "Cash",     "10:31 AM"),
                ("INV-1040", "Ly Vannak",      "9", "$64.20", "Card",     "10:05 AM"),
                ("INV-1039", "Srey Neang",     "1", "$4.50",  "ABA Pay",  "9:52 AM"),
                ("INV-1038", "Walk-in",        "3", "$15.75", "Cash",     "9:40 AM"),
                ("INV-1037", "Heng Dara",      "6", "$41.00", "Card",     "9:21 AM"),
                ("INV-1036", "Walk-in",        "2", "$7.20",  "Cash",     "9:08 AM"),
            };

            foreach (var row in sample)
            {
                dgvRecentSales.Rows.Add(row.Invoice, row.Customer, row.Items, row.Total, row.Payment, row.Time);
            }
        }

        // TODO: replace with a real query for products at or below their reorder threshold.
        private void LoadLowStock()
        {
            flpLowStock.Controls.Clear();

            var items = new (string Name, int Qty, int Threshold)[]
            {
                ("Coca-Cola 330ml",       2, 10),
                ("Instant Noodles (box)", 3, 15),
                ("Cooking Oil 1L",        1, 8),
                ("Fresh Eggs (tray)",     4, 12),
                ("Bottled Water 500ml",   5, 20),
                ("Rice 5kg",              2, 6),
                ("Toothpaste 100g",       3, 10),
            };

            foreach (var item in items)
            {
                flpLowStock.Controls.Add(BuildStockRow(item.Name, item.Qty, item.Threshold));
            }
        }

        private Control BuildStockRow(string name, int qty, int threshold)
        {
            Color badgeColor = qty <= threshold / 3
                ? Color.FromArgb(220, 38, 38)   // critical - red
                : Color.FromArgb(217, 119, 6);  // low - amber

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

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            // TODO: wire this to the same navigation the sidebar's Stock button uses,
            // e.g. raise an event the parent DashboardForm subscribes to, or call
            // ((DashboardForm)this.ParentForm)?.NavigateTo("Stock");
        }
    }
}