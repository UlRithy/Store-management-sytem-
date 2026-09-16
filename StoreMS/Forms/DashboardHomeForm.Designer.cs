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
            this.cardSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.cardOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.cardProducts = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.cardCustomers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomersValue = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.cardLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.cardProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfitValue = new System.Windows.Forms.Label();
            this.lblProfitTitle = new System.Windows.Forms.Label();
            this.panelChartSection = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
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
            this.panelTopCards.Location = new System.Drawing.Point(0, 0);
            this.panelTopCards.Name = "panelTopCards";
            this.panelTopCards.Size = new System.Drawing.Size(980, 160);
            this.panelTopCards.TabIndex = 0;
            // 
            // cardSales
            // 
            this.cardSales.BorderRadius = 8;
            this.cardSales.Controls.Add(this.lblSalesValue);
            this.cardSales.Controls.Add(this.lblSalesTitle);
            this.cardSales.FillColor = System.Drawing.Color.White;
            this.cardSales.Location = new System.Drawing.Point(0, 0);
            this.cardSales.Name = "cardSales";
            this.cardSales.Size = new System.Drawing.Size(300, 70);
            this.cardSales.TabIndex = 0;
            // 
            // lblSalesValue
            // 
            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSalesValue.Location = new System.Drawing.Point(12, 32);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Size = new System.Drawing.Size(91, 32);
            this.lblSalesValue.TabIndex = 0;
            this.lblSalesValue.Text = "$1,250";
            // 
            // lblSalesTitle
            // 
            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSalesTitle.Location = new System.Drawing.Point(12, 10);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(47, 21);
            this.lblSalesTitle.TabIndex = 1;
            this.lblSalesTitle.Text = "Sales";
            // 
            // cardOrders
            // 
            this.cardOrders.BorderRadius = 8;
            this.cardOrders.Controls.Add(this.lblOrdersValue);
            this.cardOrders.Controls.Add(this.lblOrdersTitle);
            this.cardOrders.FillColor = System.Drawing.Color.White;
            this.cardOrders.Location = new System.Drawing.Point(320, 0);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Size = new System.Drawing.Size(300, 70);
            this.cardOrders.TabIndex = 1;
            // 
            // lblOrdersValue
            // 
            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblOrdersValue.Location = new System.Drawing.Point(12, 32);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new System.Drawing.Size(42, 32);
            this.lblOrdersValue.TabIndex = 0;
            this.lblOrdersValue.Text = "85";
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(12, 10);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(60, 21);
            this.lblOrdersTitle.TabIndex = 1;
            this.lblOrdersTitle.Text = "Orders";
            // 
            // cardProducts
            // 
            this.cardProducts.BorderRadius = 8;
            this.cardProducts.Controls.Add(this.lblProductsValue);
            this.cardProducts.Controls.Add(this.lblProductsTitle);
            this.cardProducts.FillColor = System.Drawing.Color.White;
            this.cardProducts.Location = new System.Drawing.Point(640, 0);
            this.cardProducts.Name = "cardProducts";
            this.cardProducts.Size = new System.Drawing.Size(300, 70);
            this.cardProducts.TabIndex = 2;
            // 
            // lblProductsValue
            // 
            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblProductsValue.Location = new System.Drawing.Point(12, 32);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Size = new System.Drawing.Size(77, 32);
            this.lblProductsValue.TabIndex = 0;
            this.lblProductsValue.Text = "1,250";
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(12, 10);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(75, 21);
            this.lblProductsTitle.TabIndex = 1;
            this.lblProductsTitle.Text = "Products";
            // 
            // cardCustomers
            // 
            this.cardCustomers.BorderRadius = 8;
            this.cardCustomers.Controls.Add(this.lblCustomersValue);
            this.cardCustomers.Controls.Add(this.lblCustomersTitle);
            this.cardCustomers.FillColor = System.Drawing.Color.White;
            this.cardCustomers.Location = new System.Drawing.Point(0, 80);
            this.cardCustomers.Name = "cardCustomers";
            this.cardCustomers.Size = new System.Drawing.Size(300, 70);
            this.cardCustomers.TabIndex = 3;
            // 
            // lblCustomersValue
            // 
            this.lblCustomersValue.AutoSize = true;
            this.lblCustomersValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCustomersValue.Location = new System.Drawing.Point(12, 32);
            this.lblCustomersValue.Name = "lblCustomersValue";
            this.lblCustomersValue.Size = new System.Drawing.Size(56, 32);
            this.lblCustomersValue.TabIndex = 0;
            this.lblCustomersValue.Text = "520";
            // 
            // lblCustomersTitle
            // 
            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCustomersTitle.Location = new System.Drawing.Point(12, 10);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Size = new System.Drawing.Size(88, 21);
            this.lblCustomersTitle.TabIndex = 1;
            this.lblCustomersTitle.Text = "Customers";
            // 
            // cardLowStock
            // 
            this.cardLowStock.BorderRadius = 8;
            this.cardLowStock.Controls.Add(this.lblLowStockValue);
            this.cardLowStock.Controls.Add(this.lblLowStockTitle);
            this.cardLowStock.FillColor = System.Drawing.Color.White;
            this.cardLowStock.Location = new System.Drawing.Point(320, 80);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Size = new System.Drawing.Size(300, 70);
            this.cardLowStock.TabIndex = 4;
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblLowStockValue.Location = new System.Drawing.Point(12, 32);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(42, 32);
            this.lblLowStockValue.TabIndex = 0;
            this.lblLowStockValue.Text = "18";
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblLowStockTitle.Location = new System.Drawing.Point(12, 10);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(85, 21);
            this.lblLowStockTitle.TabIndex = 1;
            this.lblLowStockTitle.Text = "Low Stock";
            // 
            // cardProfit
            // 
            this.cardProfit.BorderRadius = 8;
            this.cardProfit.Controls.Add(this.lblProfitValue);
            this.cardProfit.Controls.Add(this.lblProfitTitle);
            this.cardProfit.FillColor = System.Drawing.Color.White;
            this.cardProfit.Location = new System.Drawing.Point(640, 80);
            this.cardProfit.Name = "cardProfit";
            this.cardProfit.Size = new System.Drawing.Size(300, 70);
            this.cardProfit.TabIndex = 5;
            // 
            // lblProfitValue
            // 
            this.lblProfitValue.AutoSize = true;
            this.lblProfitValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProfitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblProfitValue.Location = new System.Drawing.Point(12, 32);
            this.lblProfitValue.Name = "lblProfitValue";
            this.lblProfitValue.Size = new System.Drawing.Size(70, 32);
            this.lblProfitValue.TabIndex = 0;
            this.lblProfitValue.Text = "$320";
            // 
            // lblProfitTitle
            // 
            this.lblProfitTitle.AutoSize = true;
            this.lblProfitTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProfitTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblProfitTitle.Location = new System.Drawing.Point(12, 10);
            this.lblProfitTitle.Name = "lblProfitTitle";
            this.lblProfitTitle.Size = new System.Drawing.Size(51, 21);
            this.lblProfitTitle.TabIndex = 1;
            this.lblProfitTitle.Text = "Profit";
            // 
            // panelChartSection
            // 
            this.panelChartSection.BorderRadius = 8;
            this.panelChartSection.Controls.Add(this.lblChartTitle);
            this.panelChartSection.FillColor = System.Drawing.Color.White;
            this.panelChartSection.Location = new System.Drawing.Point(20, 190);
            this.panelChartSection.Name = "panelChartSection";
            this.panelChartSection.Size = new System.Drawing.Size(940, 180);
            this.panelChartSection.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(196, 25);
            this.lblChartTitle.TabIndex = 0;
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
            // 
            // cardTopSelling
            // 
            this.cardTopSelling.BorderRadius = 8;
            this.cardTopSelling.Controls.Add(this.lblTopSellingTitle);
            this.cardTopSelling.FillColor = System.Drawing.Color.White;
            this.cardTopSelling.Location = new System.Drawing.Point(0, 0);
            this.cardTopSelling.Name = "cardTopSelling";
            this.cardTopSelling.Size = new System.Drawing.Size(460, 145);
            this.cardTopSelling.TabIndex = 0;
            // 
            // lblTopSellingTitle
            // 
            this.lblTopSellingTitle.AutoSize = true;
            this.lblTopSellingTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopSellingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTopSellingTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTopSellingTitle.Name = "lblTopSellingTitle";
            this.lblTopSellingTitle.Size = new System.Drawing.Size(156, 25);
            this.lblTopSellingTitle.TabIndex = 0;
            this.lblTopSellingTitle.Text = "🏅 TOP SELLING";
            // 
            // cardStockPreview
            // 
            this.cardStockPreview.BorderRadius = 8;
            this.cardStockPreview.Controls.Add(this.lblStockPreviewTitle);
            this.cardStockPreview.FillColor = System.Drawing.Color.White;
            this.cardStockPreview.Location = new System.Drawing.Point(480, 0);
            this.cardStockPreview.Name = "cardStockPreview";
            this.cardStockPreview.Size = new System.Drawing.Size(460, 145);
            this.cardStockPreview.TabIndex = 1;
            // 
            // lblStockPreviewTitle
            // 
            this.lblStockPreviewTitle.AutoSize = true;
            this.lblStockPreviewTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStockPreviewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblStockPreviewTitle.Location = new System.Drawing.Point(15, 12);
            this.lblStockPreviewTitle.Name = "lblStockPreviewTitle";
            this.lblStockPreviewTitle.Size = new System.Drawing.Size(146, 25);
            this.lblStockPreviewTitle.TabIndex = 0;
            this.lblStockPreviewTitle.Text = "⚠️ LOW STOCK";
            // 
            // DashboardHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(980, 550);
            this.Controls.Add(this.panelBottomSection);
            this.Controls.Add(this.panelChartSection);
            this.Controls.Add(this.panelTopCards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardHomeForm";
            this.Text = "DashboardHomeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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