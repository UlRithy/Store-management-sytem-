namespace StoreMS.Forms
{
    partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnSale = new Guna.UI2.WinForms.Guna2Button();
            this.btnProduct = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.btnStock = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMartName = new System.Windows.Forms.Label();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.headerBorder = new System.Windows.Forms.Panel();
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.dragHeader = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 862);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel1.Controls.Add(this.btnSale);
            this.flowLayoutPanel1.Controls.Add(this.btnProduct);
            this.flowLayoutPanel1.Controls.Add(this.btnCategories);
            this.flowLayoutPanel1.Controls.Add(this.btnStock);
            this.flowLayoutPanel1.Controls.Add(this.btnSupplier);
            this.flowLayoutPanel1.Controls.Add(this.btnCustomer);
            this.flowLayoutPanel1.Controls.Add(this.btnReport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 148);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 656);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BorderRadius = 8;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDashboard.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnDashboard.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnDashboard.ImageSize = new System.Drawing.Size(18, 18);
            this.btnDashboard.Location = new System.Drawing.Point(16, 16);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(277, 54);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(18, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDasboad_Click);
            // 
            // btnSale
            // 
            this.btnSale.BorderRadius = 8;
            this.btnSale.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSale.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSale.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSale.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSale.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSale.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSale.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnSale.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSale.Location = new System.Drawing.Point(16, 78);
            this.btnSale.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(277, 54);
            this.btnSale.TabIndex = 1;
            this.btnSale.Text = "Sale / POS";
            this.btnSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSale.TextOffset = new System.Drawing.Point(18, 0);
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BorderRadius = 8;
            this.btnProduct.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProduct.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnProduct.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnProduct.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnProduct.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnProduct.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnProduct.ImageSize = new System.Drawing.Size(18, 18);
            this.btnProduct.Location = new System.Drawing.Point(16, 140);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(277, 54);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "Product";
            this.btnProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProduct.TextOffset = new System.Drawing.Point(18, 0);
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BorderRadius = 8;
            this.btnCategories.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCategories.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCategories.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCategories.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCategories.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCategories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnCategories.ImageSize = new System.Drawing.Size(18, 18);
            this.btnCategories.Location = new System.Drawing.Point(16, 202);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(277, 54);
            this.btnCategories.TabIndex = 3;
            this.btnCategories.Text = "Categories";
            this.btnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.TextOffset = new System.Drawing.Point(18, 0);
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnStock
            // 
            this.btnStock.BorderRadius = 8;
            this.btnStock.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStock.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnStock.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnStock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnStock.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStock.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnStock.ImageSize = new System.Drawing.Size(18, 18);
            this.btnStock.Location = new System.Drawing.Point(16, 264);
            this.btnStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(277, 54);
            this.btnStock.TabIndex = 4;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStock.TextOffset = new System.Drawing.Point(18, 0);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BorderRadius = 8;
            this.btnSupplier.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSupplier.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSupplier.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSupplier.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSupplier.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupplier.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnSupplier.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSupplier.Location = new System.Drawing.Point(16, 326);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(277, 54);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupplier.TextOffset = new System.Drawing.Point(18, 0);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BorderRadius = 8;
            this.btnCustomer.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCustomer.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCustomer.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCustomer.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnCustomer.ImageSize = new System.Drawing.Size(18, 18);
            this.btnCustomer.Location = new System.Drawing.Point(16, 388);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(277, 54);
            this.btnCustomer.TabIndex = 6;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomer.TextOffset = new System.Drawing.Point(18, 0);
            // 
            // btnReport
            // 
            this.btnReport.BorderRadius = 8;
            this.btnReport.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReport.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnReport.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnReport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnReport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnReport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReport.ImageOffset = new System.Drawing.Point(12, 0);
            this.btnReport.ImageSize = new System.Drawing.Size(18, 18);
            this.btnReport.Location = new System.Drawing.Point(16, 450);
            this.btnReport.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(277, 54);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReport.TextOffset = new System.Drawing.Point(18, 0);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 804);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(320, 1);
            this.guna2Panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLogout.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 805);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(320, 57);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.TextOffset = new System.Drawing.Point(30, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMartName);
            this.panel2.Controls.Add(this.guna2PictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 148);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblMartName
            // 
            this.lblMartName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblMartName.ForeColor = System.Drawing.Color.White;
            this.lblMartName.Location = new System.Drawing.Point(0, 98);
            this.lblMartName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMartName.Name = "lblMartName";
            this.lblMartName.Size = new System.Drawing.Size(320, 32);
            this.lblMartName.TabIndex = 2;
            this.lblMartName.Text = "MARTKH24H";
            this.lblMartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblCurrentPage);
            this.headerPanel.Controls.Add(this.guna2TextBox1);
            this.headerPanel.Controls.Add(this.lblAdminName);
            this.headerPanel.Controls.Add(this.btnMinimize);
            this.headerPanel.Controls.Add(this.btnMaximize);
            this.headerPanel.Controls.Add(this.guna2ControlBox1);
            this.headerPanel.Controls.Add(this.headerBorder);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(320, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1280, 79);
            this.headerPanel.TabIndex = 2;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCurrentPage.Location = new System.Drawing.Point(32, 22);
            this.lblCurrentPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(141, 35);
            this.lblCurrentPage.TabIndex = 1;
            this.lblCurrentPage.Text = "Dashboard";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.guna2TextBox1.BorderRadius = 18;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.guna2TextBox1.IconLeft = global::StoreMS.Properties.Resources.search_interface_symbol;
            this.guna2TextBox1.IconLeftOffset = new System.Drawing.Point(8, 0);
            this.guna2TextBox1.IconLeftSize = new System.Drawing.Size(16, 16);
            this.guna2TextBox1.Location = new System.Drawing.Point(427, 17);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.guna2TextBox1.PlaceholderText = "Search products, customers, invoices";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(427, 44);
            this.guna2TextBox1.TabIndex = 2;
            this.guna2TextBox1.TextOffset = new System.Drawing.Point(12, 0);
            this.guna2TextBox1.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // lblAdminName
            // 
            this.lblAdminName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblAdminName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblAdminName.Location = new System.Drawing.Point(875, 25);
            this.lblAdminName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(213, 30);
            this.lblAdminName.TabIndex = 3;
            this.lblAdminName.Text = "Sok Dara (Admin)";
            this.lblAdminName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.White;
            this.btnMinimize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMinimize.Location = new System.Drawing.Point(1109, 20);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(43, 39);
            this.btnMinimize.TabIndex = 4;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximize.FillColor = System.Drawing.Color.White;
            this.btnMaximize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMaximize.Location = new System.Drawing.Point(1157, 20);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(43, 39);
            this.btnMaximize.TabIndex = 5;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1205, 20);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(43, 39);
            this.guna2ControlBox1.TabIndex = 6;
            // 
            // headerBorder
            // 
            this.headerBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.headerBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerBorder.Location = new System.Drawing.Point(0, 78);
            this.headerBorder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerBorder.Name = "headerBorder";
            this.headerBorder.Size = new System.Drawing.Size(1280, 1);
            this.headerBorder.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(320, 79);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.mainPanel.Size = new System.Drawing.Size(1280, 783);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // dragHeader
            // 
            this.dragHeader.DockIndicatorTransparencyValue = 0.6D;
            this.dragHeader.TargetControl = this.headerPanel;
            this.dragHeader.UseTransparentDrag = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 25;
            this.guna2PictureBox1.Image = global::StoreMS.Properties.Resources.logo_removebg_preview;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.InitialImage = global::StoreMS.Properties.Resources.logo_removebg_preview;
            this.guna2PictureBox1.Location = new System.Drawing.Point(77, -29);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(158, 170);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1365, 788);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MARTKH24H - Mart Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMartName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnSale;
        private Guna.UI2.WinForms.Guna2Button btnProduct;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnStock;
        private Guna.UI2.WinForms.Guna2Button btnSupplier;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private System.Windows.Forms.Panel headerBorder;
        private System.Windows.Forms.Label lblCurrentPage;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label lblAdminName;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2DragControl dragHeader;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}