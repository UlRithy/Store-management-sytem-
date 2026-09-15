using System;

namespace StoreMS.Forms
{
    partial class ProductForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearchGroup = new System.Windows.Forms.Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.numCostPrice = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.numSellingPrice = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.numStockQty = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.numReorderLevel = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblImage = new System.Windows.Forms.Label();
            this.pnlImageGroup = new System.Windows.Forms.Panel();
            this.imgProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlButtonGroup = new System.Windows.Forms.Panel();
            this.btnInsert = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelMain.SuspendLayout();
            this.pnlSearchGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorderLevel)).BeginInit();
            this.pnlImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduct)).BeginInit();
            this.pnlButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pnlSearchGroup, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.lblCode, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.txtCode, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.lblName, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.txtName, 3, 2);
            this.tableLayoutPanelMain.Controls.Add(this.lblCategory, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.cboCategory, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.lblCostPrice, 2, 3);
            this.tableLayoutPanelMain.Controls.Add(this.numCostPrice, 3, 3);
            this.tableLayoutPanelMain.Controls.Add(this.lblSellingPrice, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.numSellingPrice, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.lblStockQty, 2, 4);
            this.tableLayoutPanelMain.Controls.Add(this.numStockQty, 3, 4);
            this.tableLayoutPanelMain.Controls.Add(this.lblReorderLevel, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.numReorderLevel, 1, 5);
            this.tableLayoutPanelMain.Controls.Add(this.lblImage, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.pnlImageGroup, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.lblDescription, 2, 6);
            this.tableLayoutPanelMain.Controls.Add(this.txtDescription, 3, 6);
            this.tableLayoutPanelMain.Controls.Add(this.pnlButtonGroup, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.dgvProducts, 0, 8);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 9;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(944, 561);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.lblTitle, 4);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(938, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Product Management System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlSearchGroup
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.pnlSearchGroup, 4);
            this.pnlSearchGroup.Controls.Add(this.txtSearch);
            this.pnlSearchGroup.Controls.Add(this.btnSearch);
            this.pnlSearchGroup.Controls.Add(this.btnRefresh);
            this.pnlSearchGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchGroup.Location = new System.Drawing.Point(3, 43);
            this.pnlSearchGroup.Name = "pnlSearchGroup";
            this.pnlSearchGroup.Size = new System.Drawing.Size(938, 49);
            this.pnlSearchGroup.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderRadius = 17;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(0, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search product...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(718, 36);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BorderRadius = 8;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(728, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 36);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.BorderThickness = 1;
            this.btnRefresh.FillColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRefresh.Location = new System.Drawing.Point(834, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCode.Location = new System.Drawing.Point(3, 110);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 15);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.BorderRadius = 8;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DefaultText = "";
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCode.Location = new System.Drawing.Point(103, 100);
            this.txtCode.Name = "txtCode";
            this.txtCode.PlaceholderText = "";
            this.txtCode.SelectedText = "";
            this.txtCode.Size = new System.Drawing.Size(366, 35);
            this.txtCode.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblName.Location = new System.Drawing.Point(475, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderRadius = 8;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(575, 100);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(366, 35);
            this.txtName.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(3, 155);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboCategory.BorderRadius = 8;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Location = new System.Drawing.Point(103, 144);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(366, 36);
            this.cboCategory.TabIndex = 7;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCostPrice.Location = new System.Drawing.Point(475, 155);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(60, 15);
            this.lblCostPrice.TabIndex = 8;
            this.lblCostPrice.Text = "Cost price";
            // 
            // numCostPrice
            // 
            this.numCostPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numCostPrice.BackColor = System.Drawing.Color.Transparent;
            this.numCostPrice.BorderRadius = 8;
            this.numCostPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numCostPrice.DecimalPlaces = 2;
            this.numCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCostPrice.Location = new System.Drawing.Point(575, 145);
            this.numCostPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCostPrice.Name = "numCostPrice";
            this.numCostPrice.Size = new System.Drawing.Size(366, 35);
            this.numCostPrice.TabIndex = 9;
            this.numCostPrice.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.numCostPrice.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSellingPrice.Location = new System.Drawing.Point(3, 200);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(71, 15);
            this.lblSellingPrice.TabIndex = 10;
            this.lblSellingPrice.Text = "Selling price";
            // 
            // numSellingPrice
            // 
            this.numSellingPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numSellingPrice.BackColor = System.Drawing.Color.Transparent;
            this.numSellingPrice.BorderRadius = 8;
            this.numSellingPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numSellingPrice.DecimalPlaces = 2;
            this.numSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSellingPrice.Location = new System.Drawing.Point(103, 190);
            this.numSellingPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSellingPrice.Name = "numSellingPrice";
            this.numSellingPrice.Size = new System.Drawing.Size(366, 35);
            this.numSellingPrice.TabIndex = 11;
            this.numSellingPrice.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.numSellingPrice.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // lblStockQty
            // 
            this.lblStockQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStockQty.AutoSize = true;
            this.lblStockQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockQty.Location = new System.Drawing.Point(475, 200);
            this.lblStockQty.Name = "lblStockQty";
            this.lblStockQty.Size = new System.Drawing.Size(61, 15);
            this.lblStockQty.TabIndex = 12;
            this.lblStockQty.Text = "Stock QTY";
            // 
            // numStockQty
            // 
            this.numStockQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numStockQty.BackColor = System.Drawing.Color.Transparent;
            this.numStockQty.BorderRadius = 8;
            this.numStockQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numStockQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numStockQty.Location = new System.Drawing.Point(575, 190);
            this.numStockQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numStockQty.Name = "numStockQty";
            this.numStockQty.Size = new System.Drawing.Size(366, 35);
            this.numStockQty.TabIndex = 13;
            this.numStockQty.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.numStockQty.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // lblReorderLevel
            // 
            this.lblReorderLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReorderLevel.AutoSize = true;
            this.lblReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReorderLevel.Location = new System.Drawing.Point(3, 245);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Size = new System.Drawing.Size(78, 15);
            this.lblReorderLevel.TabIndex = 14;
            this.lblReorderLevel.Text = "Reorder Level";
            // 
            // numReorderLevel
            // 
            this.numReorderLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numReorderLevel.BackColor = System.Drawing.Color.Transparent;
            this.numReorderLevel.BorderRadius = 8;
            this.numReorderLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numReorderLevel.Location = new System.Drawing.Point(103, 235);
            this.numReorderLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numReorderLevel.Name = "numReorderLevel";
            this.numReorderLevel.Size = new System.Drawing.Size(366, 35);
            this.numReorderLevel.TabIndex = 15;
            this.numReorderLevel.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.numReorderLevel.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImage.Location = new System.Drawing.Point(3, 280);
            this.lblImage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(40, 15);
            this.lblImage.TabIndex = 16;
            this.lblImage.Text = "Image";
            // 
            // pnlImageGroup
            // 
            this.pnlImageGroup.Controls.Add(this.imgProduct);
            this.pnlImageGroup.Controls.Add(this.btnBrowse);
            this.pnlImageGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageGroup.Location = new System.Drawing.Point(103, 278);
            this.pnlImageGroup.Name = "pnlImageGroup";
            this.pnlImageGroup.Size = new System.Drawing.Size(366, 114);
            this.pnlImageGroup.TabIndex = 17;
            // 
            // imgProduct
            // 
            this.imgProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgProduct.BorderRadius = 8;
            this.imgProduct.ImageRotate = 0F;
            this.imgProduct.Location = new System.Drawing.Point(0, 0);
            this.imgProduct.Name = "imgProduct";
            this.imgProduct.Size = new System.Drawing.Size(165, 114);
            this.imgProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgProduct.TabIndex = 0;
            this.imgProduct.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BorderRadius = 8;
            this.btnBrowse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(206, 75);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 36);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(475, 280);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 8;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(575, 278);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(366, 114);
            this.txtDescription.TabIndex = 19;
            // 
            // pnlButtonGroup
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.pnlButtonGroup, 4);
            this.pnlButtonGroup.Controls.Add(this.btnInsert);
            this.pnlButtonGroup.Controls.Add(this.btnUpdate);
            this.pnlButtonGroup.Controls.Add(this.btnDelete);
            this.pnlButtonGroup.Controls.Add(this.btnClear);
            this.pnlButtonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtonGroup.Location = new System.Drawing.Point(3, 398);
            this.pnlButtonGroup.Name = "pnlButtonGroup";
            this.pnlButtonGroup.Size = new System.Drawing.Size(938, 44);
            this.pnlButtonGroup.TabIndex = 20;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BorderRadius = 8;
            this.btnInsert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(510, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 36);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BorderRadius = 8;
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(618, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BorderRadius = 8;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(726, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClear.BorderRadius = 8;
            this.btnClear.BorderThickness = 1;
            this.btnClear.FillColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClear.Location = new System.Drawing.Point(834, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 36);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductImage,
            this.colProductCode,
            this.colProductName,
            this.colCategoryName,
            this.colQuantity,
            this.colCostPrice,
            this.colSellingPrice,
            this.colReorderLevel,
            this.colDescription});
            this.tableLayoutPanelMain.SetColumnSpan(this.dgvProducts, 4);
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProducts.Location = new System.Drawing.Point(3, 448);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 50;
            this.dgvProducts.Size = new System.Drawing.Size(938, 110);
            this.dgvProducts.TabIndex = 21;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProducts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.dgvProducts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvProducts.ThemeStyle.ReadOnly = true;
            this.dgvProducts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.ThemeStyle.RowsStyle.Height = 50;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ID";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            // 
            // colProductImage
            // 
            this.colProductImage.DataPropertyName = "ProductImage";
            this.colProductImage.HeaderText = "Image";
            this.colProductImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colProductImage.Name = "colProductImage";
            this.colProductImage.ReadOnly = true;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colCategoryName
            // 
            this.colCategoryName.DataPropertyName = "CategoryName";
            this.colCategoryName.HeaderText = "Category";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "QTY";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colCostPrice
            // 
            this.colCostPrice.DataPropertyName = "CostPrice";
            this.colCostPrice.HeaderText = "Cost Price";
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.ReadOnly = true;
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.DataPropertyName = "SellingPrice";
            this.colSellingPrice.HeaderText = "Selling Price";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.ReadOnly = true;
            // 
            // colReorderLevel
            // 
            this.colReorderLevel.DataPropertyName = "ReorderLevel";
            this.colReorderLevel.HeaderText = "Reorder Level";
            this.colReorderLevel.Name = "colReorderLevel";
            this.colReorderLevel.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "ProductForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management System";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.pnlSearchGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorderLevel)).EndInit();
            this.pnlImageGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgProduct)).EndInit();
            this.pnlButtonGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearchGroup;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.Label lblCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategory;
        private System.Windows.Forms.Label lblCostPrice;
        private Guna.UI2.WinForms.Guna2NumericUpDown numCostPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSellingPrice;
        private System.Windows.Forms.Label lblStockQty;
        private Guna.UI2.WinForms.Guna2NumericUpDown numStockQty;
        private System.Windows.Forms.Label lblReorderLevel;
        private Guna.UI2.WinForms.Guna2NumericUpDown numReorderLevel;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Panel pnlImageGroup;
        private Guna.UI2.WinForms.Guna2PictureBox imgProduct;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.Panel pnlButtonGroup;
        private Guna.UI2.WinForms.Guna2Button btnInsert;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewImageColumn colProductImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorderLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}