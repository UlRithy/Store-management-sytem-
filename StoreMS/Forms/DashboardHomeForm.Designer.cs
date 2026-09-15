namespace StoreMS.Forms
{
    partial class DashboardHomeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTopCards = new System.Windows.Forms.Panel();

            // Card 1: Sales
            this.cardSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();

            // Card 2: Orders
            this.cardOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();

            // Card 3: Products
            this.cardProducts = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();

            // Card 4: Customers
            this.cardCustomers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomersValue = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();

            // Card 5: Low Stock
            this.cardLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();

            // Card 6: Profit
            this.cardProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfitValue = new System.Windows.Forms.Label();
            this.lblProfitTitle = new System.Windows.Forms.Label();

            // Chart Section
            this.panelChartSection = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();

            // Bottom Tables Section (Top Selling & Low Stock Preview)
            this.panelBottomSection = new System.Windows.Forms.Panel();
            this.cardTopSelling = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTopSellingTitle = new System.Windows.Forms.Label();

            this.cardStockPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockPreviewTitle = new System.Windows.Forms.Label();

            this.panelTopCards.SuspendLayout();
            this.cardSales.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardProducts.SuspendLayout();
            this.cardCustomers.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardProfit.SuspendLayout();
            this.panelChartSection.SuspendLayout();
            this.panelBottomSection.SuspendLayout();
            this.cardTopSelling.SuspendLayout();
            this.cardStockPreview.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTopCards
            // 
            this.panelTopCards.Controls.Add(this.cardSales);
            this.panelTopCards.Controls.Add(this.cardOrders);
            this.panelTopCards.Controls.Add(this.cardProducts);
            this.panelTopCards.Controls.Add(this.cardCustomers);
            this.panelTopCards.Controls.Add(this.cardLowStock);
            this.panelTopCards.Controls.Add(this.cardProfit);
            this.panelTopCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopCards.Location = new System.Drawing.Point(20, 20);
            this.panelTopCards.Name = "panelTopCards";
            this.panelTopCards.Size = new System.Drawing.Size(940, 160);
            this.panelTopCards.TabIndex = 0;

            // --- Card 1: Sales ---
            this.cardSales.BorderRadius = 8;
            this.cardSales.FillColor = System.Drawing.Color.White;
            this.cardSales.Controls.Add(this.lblSalesValue);
            this.cardSales.Controls.Add(this.lblSalesTitle);
            this.cardSales.Location = new System.Drawing.Point(0, 0);
            this.cardSales.Name = "cardSales";
            this.cardSales.Size = new System.Drawing.Size(300, 70);
            this.cardSales.TabIndex = 0;

            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSalesTitle.Location = new System.Drawing.Point(12, 10);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Text = "Sales";

            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSalesValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSalesValue.Location = new System.Drawing.Point(12, 32);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Text = "$1,250";

            // --- Card 2: Orders ---
            this.cardOrders.BorderRadius = 8;
            this.cardOrders.FillColor = System.Drawing.Color.White;
            this.cardOrders.Controls.Add(this.lblOrdersValue);
            this.cardOrders.Controls.Add(this.lblOrdersTitle);
            this.cardOrders.Location = new System.Drawing.Point(320, 0);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Size = new System.Drawing.Size(300, 70);
            this.cardOrders.TabIndex = 1;

            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblOrdersTitle.Location = new System.Drawing.Point(12, 10);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Text = "Orders";

            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrdersValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblOrdersValue.Location = new System.Drawing.Point(12, 32);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Text = "85";

            // --- Card 3: Products ---
            this.cardProducts.BorderRadius = 8;
            this.cardProducts.FillColor = System.Drawing.Color.White;
            this.cardProducts.Controls.Add(this.lblProductsValue);
            this.cardProducts.Controls.Add(this.lblProductsTitle);
            this.cardProducts.Location = new System.Drawing.Point(640, 0);
            this.cardProducts.Name = "cardProducts";
            this.cardProducts.Size = new System.Drawing.Size(300, 70);
            this.cardProducts.TabIndex = 2;

            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblProductsTitle.Location = new System.Drawing.Point(12, 10);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Text = "Products";

            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductsValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblProductsValue.Location = new System.Drawing.Point(12, 32);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Text = "1,250";

            // --- Card 4: Customers ---
            this.cardCustomers.BorderRadius = 8;
            this.cardCustomers.FillColor = System.Drawing.Color.White;
            this.cardCustomers.Controls.Add(this.lblCustomersValue);
            this.cardCustomers.Controls.Add(this.lblCustomersTitle);
            this.cardCustomers.Location = new System.Drawing.Point(0, 80);
            this.cardCustomers.Name = "cardCustomers";
            this.cardCustomers.Size = new System.Drawing.Size(300, 70);
            this.cardCustomers.TabIndex = 3;

            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCustomersTitle.Location = new System.Drawing.Point(12, 10);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Text = "Customers";

            this.lblCustomersValue.AutoSize = true;
            this.lblCustomersValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomersValue.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCustomersValue.Location = new System.Drawing.Point(12, 32);
            this.lblCustomersValue.Name = "lblCustomersValue";
            this.lblCustomersValue.Text = "520";

            // --- Card 5: Low Stock ---
            this.cardLowStock.BorderRadius = 8;
            this.cardLowStock.FillColor = System.Drawing.Color.White;
            this.cardLowStock.Controls.Add(this.lblLowStockValue);
            this.cardLowStock.Controls.Add(this.lblLowStockTitle);
            this.cardLowStock.Location = new System.Drawing.Point(320, 80);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Size = new System.Drawing.Size(300, 70);
            this.cardLowStock.TabIndex = 4;

            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblLowStockTitle.Location = new System.Drawing.Point(12, 10);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Text = "Low Stock";

            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblLowStockValue.Location = new System.Drawing.Point(12, 32);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Text = "18";

            // --- Card 6: Profit ---
            this.cardProfit.BorderRadius = 8;
            this.cardProfit.FillColor = System.Drawing.Color.White;
            this.cardProfit.Controls.Add(this.lblProfitValue);
            this.cardProfit.Controls.Add(this.lblProfitTitle);
            this.cardProfit.Location = new System.Drawing.Point(640, 80);
            this.cardProfit.Name = "cardProfit";
            this.cardProfit.Size = new System.Drawing.Size(300, 70);
            this.cardProfit.TabIndex = 5;

            this.lblProfitTitle.AutoSize = true;
            this.lblProfitTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfitTitle.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblProfitTitle.Location = new System.Drawing.Point(12, 10);
            this.lblProfitTitle.Name = "lblProfitTitle";
            this.lblProfitTitle.Text = "Profit";

            this.lblProfitValue.AutoSize = true;
            this.lblProfitValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProfitValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblProfitValue.Location = new System.Drawing.Point(12, 32);
            this.lblProfitValue.Name = "lblProfitValue";
            this.lblProfitValue.Text = "$320";

            // 
            // panelChartSection
            // 
            this.panelChartSection.BorderRadius = 8;
            this.panelChartSection.FillColor = System.Drawing.Color.White;
            this.panelChartSection.Controls.Add(this.lblChartTitle);
            this.panelChartSection.Location = new System.Drawing.Point(20, 190);
            this.panelChartSection.Name = "panelChartSection";
            this.panelChartSection.Size = new System.Drawing.Size(940, 180);
            this.panelChartSection.TabIndex = 1;

            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblChartTitle.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Text = "📊 SALES OVERVIEW";

            // 
            // panelBottomSection
            // 
            this.panelBottomSection.Controls.Add(this.cardTopSelling);
            this.panelBottomSection.Controls.Add(this.cardStockPreview);
            this.panelBottomSection.Location = new System.Drawing.Point(20, 380);
            this.panelBottomSection.Name = "panelBottomSection";
            this.panelBottomSection.Size = new System.Drawing.Size(940, 150);
            this.panelBottomSection.TabIndex = 2;

            // Top Selling Card
            this.cardTopSelling.BorderRadius = 8;
            this.cardTopSelling.FillColor = System.Drawing.Color.White;
            this.cardTopSelling.Controls.Add(this.lblTopSellingTitle);
            this.cardTopSelling.Location = new System.Drawing.Point(0, 0);
            this.cardTopSelling.Name = "cardTopSelling";
            this.cardTopSelling.Size = new System.Drawing.Size(460, 145);
            this.cardTopSelling.TabIndex = 0;

            this.lblTopSellingTitle.AutoSize = true;
            this.lblTopSellingTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopSellingTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTopSellingTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTopSellingTitle.Name = "lblTopSellingTitle";
            this.lblTopSellingTitle.Text = "🏅 TOP SELLING";

            // Stock Preview Card
            this.cardStockPreview.BorderRadius = 8;
            this.cardStockPreview.FillColor = System.Drawing.Color.White;
            this.cardStockPreview.Controls.Add(this.lblStockPreviewTitle);
            this.cardStockPreview.Location = new System.Drawing.Point(480, 0);
            this.cardStockPreview.Name = "cardStockPreview";
            this.cardStockPreview.Size = new System.Drawing.Size(460, 145);
            this.cardStockPreview.TabIndex = 1;

            this.lblStockPreviewTitle.AutoSize = true;
            this.lblStockPreviewTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStockPreviewTitle.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblStockPreviewTitle.Location = new System.Drawing.Point(15, 12);
            this.lblStockPreviewTitle.Name = "lblStockPreviewTitle";
            this.lblStockPreviewTitle.Text = "⚠️ LOW STOCK";

            // 
            // DashboardHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(980, 550);
            this.Controls.Add(this.panelBottomSection);
            this.Controls.Add(this.panelChartSection);
            this.Controls.Add(this.panelTopCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardHomeForm";
            this.Text = "DashboardHomeForm";

            this.panelTopCards.ResumeLayout(false);
            this.cardSales.ResumeLayout(false);
            this.cardSales.PerformLayout();
            this.cardOrders.ResumeLayout(false);
            this.cardOrders.PerformLayout();
            this.cardProducts.ResumeLayout(false);
            this.cardProducts.PerformLayout();
            this.cardCustomers.ResumeLayout(false);
            this.cardCustomers.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardProfit.ResumeLayout(false);
            this.cardProfit.PerformLayout();
            this.panelChartSection.ResumeLayout(false);
            this.panelChartSection.PerformLayout();
            this.panelBottomSection.ResumeLayout(false);
            this.cardTopSelling.ResumeLayout(false);
            this.cardTopSelling.PerformLayout();
            this.cardStockPreview.ResumeLayout(false);
            this.cardStockPreview.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopCards;

        private Guna.UI2.WinForms.Guna2Panel cardSales;
        private System.Windows.Forms.Label lblSalesTitle;
        private System.Windows.Forms.Label lblSalesValue;

        private Guna.UI2.WinForms.Guna2Panel cardOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrdersValue;

        private Guna.UI2.WinForms.Guna2Panel cardProducts;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblProductsValue;

        private Guna.UI2.WinForms.Guna2Panel cardCustomers;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Label lblCustomersValue;

        private Guna.UI2.WinForms.Guna2Panel cardLowStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Label lblLowStockValue;

        private Guna.UI2.WinForms.Guna2Panel cardProfit;
        private System.Windows.Forms.Label lblProfitTitle;
        private System.Windows.Forms.Label lblProfitValue;

        private Guna.UI2.WinForms.Guna2Panel panelChartSection;
        private System.Windows.Forms.Label lblChartTitle;

        private System.Windows.Forms.Panel panelBottomSection;
        private Guna.UI2.WinForms.Guna2Panel cardTopSelling;
        private System.Windows.Forms.Label lblTopSellingTitle;

        private Guna.UI2.WinForms.Guna2Panel cardStockPreview;
        private System.Windows.Forms.Label lblStockPreviewTitle;
    }
}