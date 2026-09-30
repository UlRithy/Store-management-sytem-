namespace StoreMS.Forms
{
    partial class Sale_POSForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtBarcodeScan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProductSearch = new System.Windows.Forms.Panel();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlCartCard = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCartCardHeader = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTotalDivider = new System.Windows.Forms.Panel();
            this.btnClearCart = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoveItem = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlProductSearch.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlCartCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtBarcodeScan);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1712, 74);
            this.pnlTop.TabIndex = 0;
            // 
            // txtBarcodeScan
            // 
            this.txtBarcodeScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.txtBarcodeScan.BorderRadius = 10;
            this.txtBarcodeScan.BorderThickness = 2;
            this.txtBarcodeScan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcodeScan.DefaultText = "";
            this.txtBarcodeScan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtBarcodeScan.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.txtBarcodeScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtBarcodeScan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            this.txtBarcodeScan.Location = new System.Drawing.Point(898, 14);
            this.txtBarcodeScan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBarcodeScan.Name = "txtBarcodeScan";
            this.txtBarcodeScan.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtBarcodeScan.PlaceholderText = "Scan barcode here (auto enter)...";
            this.txtBarcodeScan.SelectedText = "";
            this.txtBarcodeScan.Size = new System.Drawing.Size(790, 46);
            this.txtBarcodeScan.TabIndex = 1;
            this.txtBarcodeScan.TextOffset = new System.Drawing.Point(14, 0);
            this.txtBarcodeScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeScan_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle.Location = new System.Drawing.Point(774, 26);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(104, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quick scan";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.flpProducts);
            this.pnlLeft.Controls.Add(this.pnlProductSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 74);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(693, 789);
            this.pnlLeft.TabIndex = 1;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 74);
            this.flpProducts.Margin = new System.Windows.Forms.Padding(4);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.flpProducts.Size = new System.Drawing.Size(693, 715);
            this.flpProducts.TabIndex = 1;
            // 
            // pnlProductSearch
            // 
            this.pnlProductSearch.Controls.Add(this.txtSearchProduct);
            this.pnlProductSearch.Controls.Add(this.cmbCategory);
            this.pnlProductSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlProductSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlProductSearch.Name = "pnlProductSearch";
            this.pnlProductSearch.Size = new System.Drawing.Size(693, 74);
            this.pnlProductSearch.TabIndex = 0;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtSearchProduct.BorderRadius = 10;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtSearchProduct.Location = new System.Drawing.Point(16, 15);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtSearchProduct.PlaceholderText = "Search product name...";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(380, 44);
            this.txtSearchProduct.TabIndex = 0;
            this.txtSearchProduct.TextOffset = new System.Drawing.Point(12, 0);
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BorderRadius = 10;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbCategory.ItemHeight = 30;
            this.cmbCategory.Location = new System.Drawing.Point(404, 15);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(273, 36);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlCartCard);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(693, 74);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMiddle.Size = new System.Drawing.Size(526, 789);
            this.pnlMiddle.TabIndex = 2;
            // 
            // pnlCartCard
            // 
            this.pnlCartCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCartCard.BorderRadius = 12;
            this.pnlCartCard.BorderThickness = 1;
            this.pnlCartCard.Controls.Add(this.dgvCart);
            this.pnlCartCard.Controls.Add(this.lblCartCardHeader);
            this.pnlCartCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCartCard.FillColor = System.Drawing.Color.White;
            this.pnlCartCard.Location = new System.Drawing.Point(12, 12);
            this.pnlCartCard.Name = "pnlCartCard";
            this.pnlCartCard.Padding = new System.Windows.Forms.Padding(16, 14, 16, 16);
            this.pnlCartCard.Size = new System.Drawing.Size(502, 765);
            this.pnlCartCard.TabIndex = 0;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 38;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductImage,
            this.colProductName,
            this.colPrice,
            this.colQty,
            this.colTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvCart.Location = new System.Drawing.Point(16, 44);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 50;
            this.dgvCart.Size = new System.Drawing.Size(470, 705);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvCart.ThemeStyle.ReadOnly = true;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 50;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            this.dgvCart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellDoubleClick);
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ID";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colProductImage
            // 
            this.colProductImage.DataPropertyName = "ProductImage";
            this.colProductImage.HeaderText = "Image";
            this.colProductImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colProductImage.MinimumWidth = 6;
            this.colProductImage.Name = "colProductImage";
            this.colProductImage.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Item Name";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Quantity";
            this.colQty.HeaderText = "Qty";
            this.colQty.MinimumWidth = 6;
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "SubTotal";
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // lblCartCardHeader
            // 
            this.lblCartCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCartCardHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblCartCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCartCardHeader.Location = new System.Drawing.Point(16, 14);
            this.lblCartCardHeader.Name = "lblCartCardHeader";
            this.lblCartCardHeader.Size = new System.Drawing.Size(470, 30);
            this.lblCartCardHeader.TabIndex = 0;
            this.lblCartCardHeader.Text = "Current sale";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnCheckout);
            this.pnlRight.Controls.Add(this.pnlTotalDivider);
            this.pnlRight.Controls.Add(this.btnClearCart);
            this.pnlRight.Controls.Add(this.btnRemoveItem);
            this.pnlRight.Controls.Add(this.lblTotalAmount);
            this.pnlRight.Controls.Add(this.lblTotalTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1219, 74);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(493, 789);
            this.pnlRight.TabIndex = 3;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 10;
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnCheckout.Location = new System.Drawing.Point(24, 677);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(447, 68);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // pnlTotalDivider
            // 
            this.pnlTotalDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTotalDivider.Location = new System.Drawing.Point(20, 540);
            this.pnlTotalDivider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pnlTotalDivider.Name = "pnlTotalDivider";
            this.pnlTotalDivider.Size = new System.Drawing.Size(447, 1);
            this.pnlTotalDivider.TabIndex = 7;
            // 
            // btnClearCart
            // 
            this.btnClearCart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClearCart.BorderRadius = 10;
            this.btnClearCart.BorderThickness = 1;
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FillColor = System.Drawing.Color.White;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnClearCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClearCart.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnClearCart.Location = new System.Drawing.Point(253, 26);
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(213, 49);
            this.btnClearCart.TabIndex = 3;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnRemoveItem.BorderRadius = 10;
            this.btnRemoveItem.BorderThickness = 1;
            this.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItem.FillColor = System.Drawing.Color.White;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnRemoveItem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnRemoveItem.Location = new System.Drawing.Point(20, 26);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(213, 49);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 584);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(447, 60);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "$0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 560);
            this.lblTotalTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(125, 25);
            this.lblTotalTitle.TabIndex = 4;
            this.lblTotalTitle.Text = "Total amount";
            // 
            // Sale_POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1712, 863);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sale_POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sale (POS)";
            this.Load += new System.EventHandler(this.Sale_POSForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlProductSearch.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlCartCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcodeScan;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Panel pnlProductSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;

        private System.Windows.Forms.Panel pnlMiddle;
        private Guna.UI2.WinForms.Guna2Panel pnlCartCard;
        private System.Windows.Forms.Label lblCartCardHeader;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewImageColumn colProductImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;

        private System.Windows.Forms.Panel pnlRight;
        //private Guna.UI2.WinForms.Guna2ComboBox cmbCustomer;
        private Guna.UI2.WinForms.Guna2Button btnRemoveItem;
        private Guna.UI2.WinForms.Guna2Button btnClearCart;
        private System.Windows.Forms.Panel pnlTotalDivider;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
    }
}