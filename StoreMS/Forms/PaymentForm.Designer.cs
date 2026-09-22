namespace StoreMS.Forms
{
    partial class PaymentForm
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
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalToPay = new System.Windows.Forms.Label();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblMethodTitle = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PAYMENT CHECKOUT";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(32, 90);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(155, 25);
            this.lblTotalTitle.TabIndex = 1;
            this.lblTotalTitle.Text = "TOTAL AMOUNT:";
            // 
            // lblTotalToPay
            // 
            this.lblTotalToPay.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalToPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalToPay.Location = new System.Drawing.Point(30, 118);
            this.lblTotalToPay.Name = "lblTotalToPay";
            this.lblTotalToPay.Size = new System.Drawing.Size(420, 45);
            this.lblTotalToPay.TabIndex = 2;
            this.lblTotalToPay.Text = "$0.00";
            // 
            // lblCashTitle
            // 
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCashTitle.Location = new System.Drawing.Point(32, 180);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(168, 25);
            this.lblCashTitle.TabIndex = 3;
            this.lblCashTitle.Text = "CASH RECEIVED:";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.BorderRadius = 6;
            this.txtCashReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCashReceived.DefaultText = "";
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtCashReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.txtCashReceived.Location = new System.Drawing.Point(37, 210);
            this.txtCashReceived.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.PlaceholderText = "0.00";
            this.txtCashReceived.SelectedText = "";
            this.txtCashReceived.Size = new System.Drawing.Size(413, 50);
            this.txtCashReceived.TabIndex = 4;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            // 
            // lblChangeTitle
            // 
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChangeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChangeTitle.Location = new System.Drawing.Point(32, 280);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(101, 25);
            this.lblChangeTitle.TabIndex = 5;
            this.lblChangeTitle.Text = "CHANGE:";
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblChange.Location = new System.Drawing.Point(30, 310);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(420, 50);
            this.lblChange.TabIndex = 6;
            this.lblChange.Text = "$0.00";
            // 
            // lblMethodTitle
            // 
            this.lblMethodTitle.AutoSize = true;
            this.lblMethodTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMethodTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMethodTitle.Location = new System.Drawing.Point(32, 385);
            this.lblMethodTitle.Name = "lblMethodTitle";
            this.lblMethodTitle.Size = new System.Drawing.Size(175, 25);
            this.lblMethodTitle.TabIndex = 7;
            this.lblMethodTitle.Text = "PAYMENT METHOD:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbPaymentMethod.BorderRadius = 6;
            this.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPaymentMethod.ItemHeight = 35;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "ABA PayWay / QR",
            "Credit Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(37, 415);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(413, 41);
            this.cmbPaymentMethod.StartIndex = 0;
            this.cmbPaymentMethod.TabIndex = 8;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 6;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(37, 490);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(200, 60);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 60);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(490, 580);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblMethodTitle);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblChangeTitle);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.lblCashTitle);
            this.Controls.Add(this.lblTotalToPay);
            this.Controls.Add(this.lblTotalTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Checkout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalToPay;
        private System.Windows.Forms.Label lblCashTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblMethodTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPaymentMethod;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}