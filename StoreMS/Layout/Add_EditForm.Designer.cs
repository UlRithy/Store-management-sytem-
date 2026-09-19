namespace StoreMS.Components
{
    partial class Add_EditForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.txtCostPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.txtSellingPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.picProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Product";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDivider.Location = new System.Drawing.Point(30, 68);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(700, 1);
            this.pnlDivider.TabIndex = 19;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCode.Location = new System.Drawing.Point(36, 90);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(93, 19);
            this.lblCode.TabIndex = 18;
            this.lblCode.Text = "Product code";
            // 
            // txtCode
            // 
            this.txtCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtCode.BorderRadius = 10;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DefaultText = "";
            this.txtCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtCode.Location = new System.Drawing.Point(36, 114);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtCode.PlaceholderText = "e.g. SKU-1042";
            this.txtCode.SelectedText = "";
            this.txtCode.Size = new System.Drawing.Size(320, 36);
            this.txtCode.TabIndex = 17;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblName.Location = new System.Drawing.Point(36, 168);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 19);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Product name";
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtName.BorderRadius = 10;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtName.Location = new System.Drawing.Point(36, 192);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtName.PlaceholderText = "e.g. Coca-Cola 330ml";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(320, 36);
            this.txtName.TabIndex = 15;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCategory.Location = new System.Drawing.Point(36, 246);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(66, 19);
            this.lblCategory.TabIndex = 14;
            this.lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BorderRadius = 10;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.ItemHeight = 30;
            this.cmbCategory.Location = new System.Drawing.Point(36, 270);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(320, 36);
            this.cmbCategory.TabIndex = 13;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblQty.Location = new System.Drawing.Point(36, 324);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(63, 19);
            this.lblQty.TabIndex = 12;
            this.lblQty.Text = "Quantity";
            // 
            // txtQty
            // 
            this.txtQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtQty.BorderRadius = 10;
            this.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQty.DefaultText = "";
            this.txtQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtQty.Location = new System.Drawing.Point(36, 348);
            this.txtQty.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtQty.Name = "txtQty";
            this.txtQty.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtQty.PlaceholderText = "0";
            this.txtQty.SelectedText = "";
            this.txtQty.Size = new System.Drawing.Size(320, 36);
            this.txtQty.TabIndex = 11;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCostPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCostPrice.Location = new System.Drawing.Point(404, 90);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(76, 19);
            this.lblCostPrice.TabIndex = 10;
            this.lblCostPrice.Text = "Cost price";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtCostPrice.BorderRadius = 10;
            this.txtCostPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCostPrice.DefaultText = "";
            this.txtCostPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCostPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCostPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtCostPrice.Location = new System.Drawing.Point(404, 114);
            this.txtCostPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtCostPrice.PlaceholderText = "0.00";
            this.txtCostPrice.SelectedText = "";
            this.txtCostPrice.Size = new System.Drawing.Size(320, 36);
            this.txtCostPrice.TabIndex = 9;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSellingPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSellingPrice.Location = new System.Drawing.Point(404, 168);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(88, 19);
            this.lblSellingPrice.TabIndex = 8;
            this.lblSellingPrice.Text = "Selling price";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtSellingPrice.BorderRadius = 10;
            this.txtSellingPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSellingPrice.DefaultText = "";
            this.txtSellingPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSellingPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSellingPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtSellingPrice.Location = new System.Drawing.Point(404, 192);
            this.txtSellingPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtSellingPrice.PlaceholderText = "0.00";
            this.txtSellingPrice.SelectedText = "";
            this.txtSellingPrice.Size = new System.Drawing.Size(320, 36);
            this.txtSellingPrice.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDescription.Location = new System.Drawing.Point(404, 246);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 19);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtDescription.BorderRadius = 10;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtDescription.Location = new System.Drawing.Point(404, 270);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtDescription.PlaceholderText = "Optional notes about this product";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(320, 36);
            this.txtDescription.TabIndex = 5;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblImage.Location = new System.Drawing.Point(404, 324);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(53, 19);
            this.lblImage.TabIndex = 4;
            this.lblImage.Text = "Photo";
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.picProduct.BorderRadius = 10;
            this.picProduct.ImageRotate = 0F;
            this.picProduct.Location = new System.Drawing.Point(404, 353);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(130, 100);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 3;
            this.picProduct.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnBrowse.BorderRadius = 10;
            this.btnBrowse.BorderThickness = 1;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FillColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnBrowse.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnBrowse.Location = new System.Drawing.Point(404, 461);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(130, 36);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnSave.Location = new System.Drawing.Point(252, 527);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 44);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnCancel.Location = new System.Drawing.Point(388, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 44);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // Add_EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Product";
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private System.Windows.Forms.Label lblQty;
        private Guna.UI2.WinForms.Guna2TextBox txtQty;
        private System.Windows.Forms.Label lblCostPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtCostPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtSellingPrice;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.Label lblImage;
        private Guna.UI2.WinForms.Guna2PictureBox picProduct;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}