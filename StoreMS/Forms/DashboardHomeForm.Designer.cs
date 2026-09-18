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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlGreeting = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.pnlKpiRow = new System.Windows.Forms.Panel();
            this.tlpKpi = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiSales = new Guna.UI2.WinForms.Guna2Panel();
            this.barKpiSales = new System.Windows.Forms.Panel();
            this.lblKpiSalesValue = new System.Windows.Forms.Label();
            this.lblKpiSalesLabel = new System.Windows.Forms.Label();
            this.lblKpiSalesDelta = new System.Windows.Forms.Label();
            this.pnlKpiOrders = new Guna.UI2.WinForms.Guna2Panel();
            this.barKpiOrders = new System.Windows.Forms.Panel();
            this.lblKpiOrdersValue = new System.Windows.Forms.Label();
            this.lblKpiOrdersLabel = new System.Windows.Forms.Label();
            this.lblKpiOrdersDelta = new System.Windows.Forms.Label();
            this.pnlKpiProducts = new Guna.UI2.WinForms.Guna2Panel();
            this.barKpiProducts = new System.Windows.Forms.Panel();
            this.lblKpiProductsValue = new System.Windows.Forms.Label();
            this.lblKpiProductsLabel = new System.Windows.Forms.Label();
            this.lblKpiProductsDelta = new System.Windows.Forms.Label();
            this.pnlKpiLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.barKpiLowStock = new System.Windows.Forms.Panel();
            this.lblKpiLowStockValue = new System.Windows.Forms.Label();
            this.lblKpiLowStockLabel = new System.Windows.Forms.Label();
            this.lblKpiLowStockDelta = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlRecentSales = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecentSalesTitle = new System.Windows.Forms.Label();
            this.lblRecentSalesSub = new System.Windows.Forms.Label();
            this.dgvRecentSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGapBodyH = new System.Windows.Forms.Panel();
            this.pnlLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.btnViewStock = new Guna.UI2.WinForms.Guna2Button();
            this.flpLowStock = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlGreeting.SuspendLayout();
            this.pnlKpiRow.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlKpiSales.SuspendLayout();
            this.pnlKpiOrders.SuspendLayout();
            this.pnlKpiProducts.SuspendLayout();
            this.pnlKpiLowStock.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlRecentSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).BeginInit();
            this.pnlLowStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGreeting
            // 
            this.pnlGreeting.Controls.Add(this.lblDateToday);
            this.pnlGreeting.Controls.Add(this.lblGreeting);
            this.pnlGreeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGreeting.Location = new System.Drawing.Point(0, 0);
            this.pnlGreeting.Name = "pnlGreeting";
            this.pnlGreeting.Size = new System.Drawing.Size(920, 56);
            this.pnlGreeting.TabIndex = 0;
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGreeting.Location = new System.Drawing.Point(0, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(230, 28);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.Text = "Good morning, Sok Dara";
            // 
            // lblDateToday
            // 
            this.lblDateToday.AutoSize = true;
            this.lblDateToday.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDateToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDateToday.Location = new System.Drawing.Point(2, 31);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(220, 19);
            this.lblDateToday.TabIndex = 1;
            this.lblDateToday.Text = "Here\'s how the shop is doing today.";
            // 
            // pnlKpiRow
            // 
            this.pnlKpiRow.Controls.Add(this.tlpKpi);
            this.pnlKpiRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiRow.Location = new System.Drawing.Point(0, 56);
            this.pnlKpiRow.Name = "pnlKpiRow";
            this.pnlKpiRow.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlKpiRow.Size = new System.Drawing.Size(920, 132);
            this.pnlKpiRow.TabIndex = 1;
            // 
            // tlpKpi
            // 
            this.tlpKpi.ColumnCount = 4;
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.Controls.Add(this.pnlKpiSales, 0, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiOrders, 1, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiProducts, 2, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiLowStock, 3, 0);
            this.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpi.Location = new System.Drawing.Point(0, 20);
            this.tlpKpi.Name = "tlpKpi";
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Size = new System.Drawing.Size(920, 112);
            this.tlpKpi.TabIndex = 0;
            // 
            // pnlKpiSales
            // 
            this.pnlKpiSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlKpiSales.BorderRadius = 12;
            this.pnlKpiSales.BorderThickness = 1;
            this.pnlKpiSales.Controls.Add(this.lblKpiSalesDelta);
            this.pnlKpiSales.Controls.Add(this.lblKpiSalesLabel);
            this.pnlKpiSales.Controls.Add(this.lblKpiSalesValue);
            this.pnlKpiSales.Controls.Add(this.barKpiSales);
            this.pnlKpiSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiSales.FillColor = System.Drawing.Color.White;
            this.pnlKpiSales.Location = new System.Drawing.Point(3, 3);
            this.pnlKpiSales.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.pnlKpiSales.Name = "pnlKpiSales";
            this.pnlKpiSales.Size = new System.Drawing.Size(211, 106);
            this.pnlKpiSales.TabIndex = 0;
            // 
            // barKpiSales
            // 
            this.barKpiSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.barKpiSales.Location = new System.Drawing.Point(0, 16);
            this.barKpiSales.Name = "barKpiSales";
            this.barKpiSales.Size = new System.Drawing.Size(4, 74);
            this.barKpiSales.TabIndex = 0;
            // 
            // lblKpiSalesValue
            // 
            this.lblKpiSalesValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiSalesValue.Location = new System.Drawing.Point(20, 14);
            this.lblKpiSalesValue.Name = "lblKpiSalesValue";
            this.lblKpiSalesValue.Size = new System.Drawing.Size(180, 32);
            this.lblKpiSalesValue.TabIndex = 1;
            this.lblKpiSalesValue.Text = "$1,284.50";
            // 
            // lblKpiSalesLabel
            // 
            this.lblKpiSalesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiSalesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiSalesLabel.Location = new System.Drawing.Point(20, 48);
            this.lblKpiSalesLabel.Name = "lblKpiSalesLabel";
            this.lblKpiSalesLabel.Size = new System.Drawing.Size(180, 18);
            this.lblKpiSalesLabel.TabIndex = 2;
            this.lblKpiSalesLabel.Text = "Today\'s sales";
            // 
            // lblKpiSalesDelta
            // 
            this.lblKpiSalesDelta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblKpiSalesDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblKpiSalesDelta.Location = new System.Drawing.Point(20, 74);
            this.lblKpiSalesDelta.Name = "lblKpiSalesDelta";
            this.lblKpiSalesDelta.Size = new System.Drawing.Size(180, 18);
            this.lblKpiSalesDelta.TabIndex = 3;
            this.lblKpiSalesDelta.Text = "Up 12% from yesterday";
            // 
            // pnlKpiOrders
            // 
            this.pnlKpiOrders.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlKpiOrders.BorderRadius = 12;
            this.pnlKpiOrders.BorderThickness = 1;
            this.pnlKpiOrders.Controls.Add(this.lblKpiOrdersDelta);
            this.pnlKpiOrders.Controls.Add(this.lblKpiOrdersLabel);
            this.pnlKpiOrders.Controls.Add(this.lblKpiOrdersValue);
            this.pnlKpiOrders.Controls.Add(this.barKpiOrders);
            this.pnlKpiOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiOrders.FillColor = System.Drawing.Color.White;
            this.pnlKpiOrders.Location = new System.Drawing.Point(233, 3);
            this.pnlKpiOrders.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.pnlKpiOrders.Name = "pnlKpiOrders";
            this.pnlKpiOrders.Size = new System.Drawing.Size(211, 106);
            this.pnlKpiOrders.TabIndex = 1;
            // 
            // barKpiOrders
            // 
            this.barKpiOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.barKpiOrders.Location = new System.Drawing.Point(0, 16);
            this.barKpiOrders.Name = "barKpiOrders";
            this.barKpiOrders.Size = new System.Drawing.Size(4, 74);
            this.barKpiOrders.TabIndex = 0;
            // 
            // lblKpiOrdersValue
            // 
            this.lblKpiOrdersValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiOrdersValue.Location = new System.Drawing.Point(20, 14);
            this.lblKpiOrdersValue.Name = "lblKpiOrdersValue";
            this.lblKpiOrdersValue.Size = new System.Drawing.Size(180, 32);
            this.lblKpiOrdersValue.TabIndex = 1;
            this.lblKpiOrdersValue.Text = "38";
            // 
            // lblKpiOrdersLabel
            // 
            this.lblKpiOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiOrdersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiOrdersLabel.Location = new System.Drawing.Point(20, 48);
            this.lblKpiOrdersLabel.Name = "lblKpiOrdersLabel";
            this.lblKpiOrdersLabel.Size = new System.Drawing.Size(180, 18);
            this.lblKpiOrdersLabel.TabIndex = 2;
            this.lblKpiOrdersLabel.Text = "Orders today";
            // 
            // lblKpiOrdersDelta
            // 
            this.lblKpiOrdersDelta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblKpiOrdersDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblKpiOrdersDelta.Location = new System.Drawing.Point(20, 74);
            this.lblKpiOrdersDelta.Name = "lblKpiOrdersDelta";
            this.lblKpiOrdersDelta.Size = new System.Drawing.Size(180, 18);
            this.lblKpiOrdersDelta.TabIndex = 3;
            this.lblKpiOrdersDelta.Text = "5 more than yesterday";
            // 
            // pnlKpiProducts
            // 
            this.pnlKpiProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlKpiProducts.BorderRadius = 12;
            this.pnlKpiProducts.BorderThickness = 1;
            this.pnlKpiProducts.Controls.Add(this.lblKpiProductsDelta);
            this.pnlKpiProducts.Controls.Add(this.lblKpiProductsLabel);
            this.pnlKpiProducts.Controls.Add(this.lblKpiProductsValue);
            this.pnlKpiProducts.Controls.Add(this.barKpiProducts);
            this.pnlKpiProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiProducts.FillColor = System.Drawing.Color.White;
            this.pnlKpiProducts.Location = new System.Drawing.Point(463, 3);
            this.pnlKpiProducts.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.pnlKpiProducts.Name = "pnlKpiProducts";
            this.pnlKpiProducts.Size = new System.Drawing.Size(211, 106);
            this.pnlKpiProducts.TabIndex = 2;
            // 
            // barKpiProducts
            // 
            this.barKpiProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.barKpiProducts.Location = new System.Drawing.Point(0, 16);
            this.barKpiProducts.Name = "barKpiProducts";
            this.barKpiProducts.Size = new System.Drawing.Size(4, 74);
            this.barKpiProducts.TabIndex = 0;
            // 
            // lblKpiProductsValue
            // 
            this.lblKpiProductsValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiProductsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiProductsValue.Location = new System.Drawing.Point(20, 14);
            this.lblKpiProductsValue.Name = "lblKpiProductsValue";
            this.lblKpiProductsValue.Size = new System.Drawing.Size(180, 32);
            this.lblKpiProductsValue.TabIndex = 1;
            this.lblKpiProductsValue.Text = "412";
            // 
            // lblKpiProductsLabel
            // 
            this.lblKpiProductsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiProductsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiProductsLabel.Location = new System.Drawing.Point(20, 48);
            this.lblKpiProductsLabel.Name = "lblKpiProductsLabel";
            this.lblKpiProductsLabel.Size = new System.Drawing.Size(180, 18);
            this.lblKpiProductsLabel.TabIndex = 2;
            this.lblKpiProductsLabel.Text = "Products in stock";
            // 
            // lblKpiProductsDelta
            // 
            this.lblKpiProductsDelta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblKpiProductsDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiProductsDelta.Location = new System.Drawing.Point(20, 74);
            this.lblKpiProductsDelta.Name = "lblKpiProductsDelta";
            this.lblKpiProductsDelta.Size = new System.Drawing.Size(180, 18);
            this.lblKpiProductsDelta.TabIndex = 3;
            this.lblKpiProductsDelta.Text = "Across 6 categories";
            // 
            // pnlKpiLowStock
            // 
            this.pnlKpiLowStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlKpiLowStock.BorderRadius = 12;
            this.pnlKpiLowStock.BorderThickness = 1;
            this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockDelta);
            this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockLabel);
            this.pnlKpiLowStock.Controls.Add(this.lblKpiLowStockValue);
            this.pnlKpiLowStock.Controls.Add(this.barKpiLowStock);
            this.pnlKpiLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiLowStock.FillColor = System.Drawing.Color.White;
            this.pnlKpiLowStock.Location = new System.Drawing.Point(693, 3);
            this.pnlKpiLowStock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pnlKpiLowStock.Name = "pnlKpiLowStock";
            this.pnlKpiLowStock.Size = new System.Drawing.Size(224, 106);
            this.pnlKpiLowStock.TabIndex = 3;
            // 
            // barKpiLowStock
            // 
            this.barKpiLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.barKpiLowStock.Location = new System.Drawing.Point(0, 16);
            this.barKpiLowStock.Name = "barKpiLowStock";
            this.barKpiLowStock.Size = new System.Drawing.Size(4, 74);
            this.barKpiLowStock.TabIndex = 0;
            // 
            // lblKpiLowStockValue
            // 
            this.lblKpiLowStockValue.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblKpiLowStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiLowStockValue.Location = new System.Drawing.Point(20, 14);
            this.lblKpiLowStockValue.Name = "lblKpiLowStockValue";
            this.lblKpiLowStockValue.Size = new System.Drawing.Size(190, 32);
            this.lblKpiLowStockValue.TabIndex = 1;
            this.lblKpiLowStockValue.Text = "7";
            // 
            // lblKpiLowStockLabel
            // 
            this.lblKpiLowStockLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiLowStockLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiLowStockLabel.Location = new System.Drawing.Point(20, 48);
            this.lblKpiLowStockLabel.Name = "lblKpiLowStockLabel";
            this.lblKpiLowStockLabel.Size = new System.Drawing.Size(190, 18);
            this.lblKpiLowStockLabel.TabIndex = 2;
            this.lblKpiLowStockLabel.Text = "Low stock items";
            // 
            // lblKpiLowStockDelta
            // 
            this.lblKpiLowStockDelta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblKpiLowStockDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblKpiLowStockDelta.Location = new System.Drawing.Point(20, 74);
            this.lblKpiLowStockDelta.Name = "lblKpiLowStockDelta";
            this.lblKpiLowStockDelta.Size = new System.Drawing.Size(190, 18);
            this.lblKpiLowStockDelta.TabIndex = 3;
            this.lblKpiLowStockDelta.Text = "Needs restocking";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlRecentSales);
            this.pnlBody.Controls.Add(this.pnlGapBodyH);
            this.pnlBody.Controls.Add(this.pnlLowStock);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 188);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlBody.Size = new System.Drawing.Size(920, 408);
            this.pnlBody.TabIndex = 2;
            // 
            // pnlRecentSales
            // 
            this.pnlRecentSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlRecentSales.BorderRadius = 12;
            this.pnlRecentSales.BorderThickness = 1;
            this.pnlRecentSales.Controls.Add(this.dgvRecentSales);
            this.pnlRecentSales.Controls.Add(this.lblRecentSalesSub);
            this.pnlRecentSales.Controls.Add(this.lblRecentSalesTitle);
            this.pnlRecentSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecentSales.FillColor = System.Drawing.Color.White;
            this.pnlRecentSales.Location = new System.Drawing.Point(0, 20);
            this.pnlRecentSales.Name = "pnlRecentSales";
            this.pnlRecentSales.Size = new System.Drawing.Size(600, 388);
            this.pnlRecentSales.TabIndex = 0;
            // 
            // lblRecentSalesTitle
            // 
            this.lblRecentSalesTitle.AutoSize = true;
            this.lblRecentSalesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblRecentSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRecentSalesTitle.Location = new System.Drawing.Point(20, 16);
            this.lblRecentSalesTitle.Name = "lblRecentSalesTitle";
            this.lblRecentSalesTitle.Size = new System.Drawing.Size(103, 21);
            this.lblRecentSalesTitle.TabIndex = 0;
            this.lblRecentSalesTitle.Text = "Recent sales";
            // 
            // lblRecentSalesSub
            // 
            this.lblRecentSalesSub.AutoSize = true;
            this.lblRecentSalesSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecentSalesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRecentSalesSub.Location = new System.Drawing.Point(20, 40);
            this.lblRecentSalesSub.Name = "lblRecentSalesSub";
            this.lblRecentSalesSub.Size = new System.Drawing.Size(140, 19);
            this.lblRecentSalesSub.TabIndex = 1;
            this.lblRecentSalesSub.Text = "Last 10 transactions";
            // 
            // dgvRecentSales
            // 
            this.dgvRecentSales.AllowUserToAddRows = false;
            this.dgvRecentSales.AllowUserToDeleteRows = false;
            this.dgvRecentSales.AllowUserToResizeColumns = false;
            this.dgvRecentSales.AllowUserToResizeRows = false;
            this.dgvRecentSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentSales.ColumnHeadersHeight = 38;
            this.dgvRecentSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoice,
            this.colCustomer,
            this.colItems,
            this.colTotal,
            this.colPayment,
            this.colTime});
            this.dgvRecentSales.EnableHeadersVisualStyles = false;
            this.dgvRecentSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvRecentSales.Location = new System.Drawing.Point(20, 68);
            this.dgvRecentSales.MultiSelect = false;
            this.dgvRecentSales.Name = "dgvRecentSales";
            this.dgvRecentSales.ReadOnly = true;
            this.dgvRecentSales.RowHeadersVisible = false;
            this.dgvRecentSales.RowTemplate.Height = 38;
            this.dgvRecentSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentSales.Size = new System.Drawing.Size(560, 300);
            this.dgvRecentSales.TabIndex = 2;
            // 
            // colInvoice
            // 
            this.colInvoice.FillWeight = 90F;
            this.colInvoice.HeaderText = "Invoice";
            this.colInvoice.Name = "colInvoice";
            this.colInvoice.ReadOnly = true;
            // 
            // colCustomer
            // 
            this.colCustomer.FillWeight = 140F;
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.FillWeight = 70F;
            this.colItems.HeaderText = "Items";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.FillWeight = 90F;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colPayment
            // 
            this.colPayment.FillWeight = 100F;
            this.colPayment.HeaderText = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.FillWeight = 80F;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // pnlGapBodyH
            // 
            this.pnlGapBodyH.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGapBodyH.Location = new System.Drawing.Point(600, 20);
            this.pnlGapBodyH.Name = "pnlGapBodyH";
            this.pnlGapBodyH.Size = new System.Drawing.Size(20, 388);
            this.pnlGapBodyH.TabIndex = 1;
            // 
            // pnlLowStock
            // 
            this.pnlLowStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlLowStock.BorderRadius = 12;
            this.pnlLowStock.BorderThickness = 1;
            this.pnlLowStock.Controls.Add(this.flpLowStock);
            this.pnlLowStock.Controls.Add(this.btnViewStock);
            this.pnlLowStock.Controls.Add(this.lblLowStockTitle);
            this.pnlLowStock.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLowStock.FillColor = System.Drawing.Color.White;
            this.pnlLowStock.Location = new System.Drawing.Point(620, 20);
            this.pnlLowStock.Name = "pnlLowStock";
            this.pnlLowStock.Size = new System.Drawing.Size(300, 388);
            this.pnlLowStock.TabIndex = 2;
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLowStockTitle.Location = new System.Drawing.Point(20, 16);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(116, 21);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Low stock alert";
            // 
            // btnViewStock
            // 
            this.btnViewStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnViewStock.BorderRadius = 8;
            this.btnViewStock.BorderThickness = 1;
            this.btnViewStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewStock.FillColor = System.Drawing.Color.White;
            this.btnViewStock.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnViewStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnViewStock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.btnViewStock.Location = new System.Drawing.Point(220, 12);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(64, 28);
            this.btnViewStock.TabIndex = 1;
            this.btnViewStock.Text = "View all";
            this.btnViewStock.Click += new System.EventHandler(this.btnViewStock_Click);
            // 
            // flpLowStock
            // 
            this.flpLowStock.AutoScroll = true;
            this.flpLowStock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpLowStock.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLowStock.Location = new System.Drawing.Point(0, 56);
            this.flpLowStock.Name = "flpLowStock";
            this.flpLowStock.Padding = new System.Windows.Forms.Padding(16, 0, 8, 16);
            this.flpLowStock.Size = new System.Drawing.Size(300, 332);
            this.flpLowStock.TabIndex = 2;
            this.flpLowStock.WrapContents = false;
            // 
            // DashboardHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(920, 596);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlKpiRow);
            this.Controls.Add(this.pnlGreeting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardHomeForm";
            this.Text = "DashboardHomeForm";
            this.Load += new System.EventHandler(this.DashboardHomeForm_Load);
            this.pnlGreeting.ResumeLayout(false);
            this.pnlGreeting.PerformLayout();
            this.pnlKpiRow.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlKpiSales.ResumeLayout(false);
            this.pnlKpiOrders.ResumeLayout(false);
            this.pnlKpiProducts.ResumeLayout(false);
            this.pnlKpiLowStock.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlRecentSales.ResumeLayout(false);
            this.pnlRecentSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentSales)).EndInit();
            this.pnlLowStock.ResumeLayout(false);
            this.pnlLowStock.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlGreeting;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblDateToday;
        private System.Windows.Forms.Panel pnlKpiRow;
        private System.Windows.Forms.TableLayoutPanel tlpKpi;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiSales;
        private System.Windows.Forms.Panel barKpiSales;
        private System.Windows.Forms.Label lblKpiSalesValue;
        private System.Windows.Forms.Label lblKpiSalesLabel;
        private System.Windows.Forms.Label lblKpiSalesDelta;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiOrders;
        private System.Windows.Forms.Panel barKpiOrders;
        private System.Windows.Forms.Label lblKpiOrdersValue;
        private System.Windows.Forms.Label lblKpiOrdersLabel;
        private System.Windows.Forms.Label lblKpiOrdersDelta;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiProducts;
        private System.Windows.Forms.Panel barKpiProducts;
        private System.Windows.Forms.Label lblKpiProductsValue;
        private System.Windows.Forms.Label lblKpiProductsLabel;
        private System.Windows.Forms.Label lblKpiProductsDelta;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiLowStock;
        private System.Windows.Forms.Panel barKpiLowStock;
        private System.Windows.Forms.Label lblKpiLowStockValue;
        private System.Windows.Forms.Label lblKpiLowStockLabel;
        private System.Windows.Forms.Label lblKpiLowStockDelta;
        private System.Windows.Forms.Panel pnlBody;
        private Guna.UI2.WinForms.Guna2Panel pnlRecentSales;
        private System.Windows.Forms.Label lblRecentSalesTitle;
        private System.Windows.Forms.Label lblRecentSalesSub;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecentSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.Panel pnlGapBodyH;
        private Guna.UI2.WinForms.Guna2Panel pnlLowStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private Guna.UI2.WinForms.Guna2Button btnViewStock;
        private System.Windows.Forms.FlowLayoutPanel flpLowStock;
    }
}