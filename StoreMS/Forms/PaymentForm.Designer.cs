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
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblTotalDueCaption = new System.Windows.Forms.Label();
            this.lblTotalDueValue = new System.Windows.Forms.Label();
            this.pnlDivider2 = new System.Windows.Forms.Panel();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.pnlPaymentChips = new System.Windows.Forms.Panel();
            this.btnPayQR = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayCard = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayCash = new Guna.UI2.WinForms.Guna2Button();
            this.lblAmountTendered = new System.Windows.Forms.Label();
            this.txtAmountTendered = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblChangeDueCaption = new System.Windows.Forms.Label();
            this.lblChangeDueValue = new System.Windows.Forms.Label();
            this.btnConfirmPayment = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelPayment = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPaymentChips.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payment";
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDivider.Location = new System.Drawing.Point(30, 64);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(394, 1);
            this.pnlDivider.TabIndex = 1;
            // 
            // lblTotalDueCaption
            // 
            this.lblTotalDueCaption.AutoSize = true;
            this.lblTotalDueCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTotalDueCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalDueCaption.Location = new System.Drawing.Point(35, 80);
            this.lblTotalDueCaption.Name = "lblTotalDueCaption";
            this.lblTotalDueCaption.Size = new System.Drawing.Size(61, 19);
            this.lblTotalDueCaption.TabIndex = 2;
            this.lblTotalDueCaption.Text = "Total due";
            // 
            // lblTotalDueValue
            // 
            this.lblTotalDueValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalDueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTotalDueValue.Location = new System.Drawing.Point(35, 100);
            this.lblTotalDueValue.Name = "lblTotalDueValue";
            this.lblTotalDueValue.Size = new System.Drawing.Size(384, 48);
            this.lblTotalDueValue.TabIndex = 3;
            this.lblTotalDueValue.Text = "$0.00";
            // 
            // pnlDivider2
            // 
            this.pnlDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDivider2.Location = new System.Drawing.Point(30, 156);
            this.pnlDivider2.Name = "pnlDivider2";
            this.pnlDivider2.Size = new System.Drawing.Size(394, 1);
            this.pnlDivider2.TabIndex = 4;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPaymentMethod.Location = new System.Drawing.Point(35, 172);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(104, 19);
            this.lblPaymentMethod.TabIndex = 5;
            this.lblPaymentMethod.Text = "Payment method";
            // 
            // pnlPaymentChips
            // 
            this.pnlPaymentChips.Controls.Add(this.btnPayQR);
            this.pnlPaymentChips.Controls.Add(this.btnPayCard);
            this.pnlPaymentChips.Controls.Add(this.btnPayCash);
            this.pnlPaymentChips.Location = new System.Drawing.Point(35, 196);
            this.pnlPaymentChips.Name = "pnlPaymentChips";
            this.pnlPaymentChips.Size = new System.Drawing.Size(384, 42);
            this.pnlPaymentChips.TabIndex = 6;
            // 
            // btnPayCash
            // 
            this.btnPayCash.BorderRadius = 10;
            this.btnPayCash.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPayCash.Checked = true;
            this.btnPayCash.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPayCash.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnPayCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayCash.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPayCash.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnPayCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPayCash.Location = new System.Drawing.Point(0, 0);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(120, 42);
            this.btnPayCash.TabIndex = 0;
            this.btnPayCash.Text = "Cash";
            this.btnPayCash.Click += new System.EventHandler(this.PaymentMethod_Click);
            // 
            // btnPayCard
            // 
            this.btnPayCard.BorderRadius = 10;
            this.btnPayCard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPayCard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPayCard.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnPayCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPayCard.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnPayCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPayCard.Location = new System.Drawing.Point(132, 0);
            this.btnPayCard.Name = "btnPayCard";
            this.btnPayCard.Size = new System.Drawing.Size(120, 42);
            this.btnPayCard.TabIndex = 1;
            this.btnPayCard.Text = "Card";
            this.btnPayCard.Click += new System.EventHandler(this.PaymentMethod_Click);
            // 
            // btnPayQR
            // 
            this.btnPayQR.BorderRadius = 10;
            this.btnPayQR.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPayQR.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPayQR.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnPayQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayQR.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPayQR.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnPayQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPayQR.Location = new System.Drawing.Point(264, 0);
            this.btnPayQR.Name = "btnPayQR";
            this.btnPayQR.Size = new System.Drawing.Size(120, 42);
            this.btnPayQR.TabIndex = 2;
            this.btnPayQR.Text = "QR Pay";
            this.btnPayQR.Click += new System.EventHandler(this.PaymentMethod_Click);
            // 
            // lblAmountTendered
            // 
            this.lblAmountTendered.AutoSize = true;
            this.lblAmountTendered.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAmountTendered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAmountTendered.Location = new System.Drawing.Point(35, 254);
            this.lblAmountTendered.Name = "lblAmountTendered";
            this.lblAmountTendered.Size = new System.Drawing.Size(114, 19);
            this.lblAmountTendered.TabIndex = 7;
            this.lblAmountTendered.Text = "Amount received";
            // 
            // txtAmountTendered
            // 
            this.txtAmountTendered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtAmountTendered.BorderRadius = 10;
            this.txtAmountTendered.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmountTendered.DefaultText = "";
            this.txtAmountTendered.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtAmountTendered.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAmountTendered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtAmountTendered.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtAmountTendered.Location = new System.Drawing.Point(35, 278);
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtAmountTendered.PlaceholderText = "0.00";
            this.txtAmountTendered.SelectedText = "";
            this.txtAmountTendered.Size = new System.Drawing.Size(384, 44);
            this.txtAmountTendered.TabIndex = 8;
            this.txtAmountTendered.TextChanged += new System.EventHandler(this.txtAmountTendered_TextChanged);
            // 
            // lblChangeDueCaption
            // 
            this.lblChangeDueCaption.AutoSize = true;
            this.lblChangeDueCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChangeDueCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChangeDueCaption.Location = new System.Drawing.Point(35, 336);
            this.lblChangeDueCaption.Name = "lblChangeDueCaption";
            this.lblChangeDueCaption.Size = new System.Drawing.Size(72, 19);
            this.lblChangeDueCaption.TabIndex = 9;
            this.lblChangeDueCaption.Text = "Change due";
            // 
            // lblChangeDueValue
            // 
            this.lblChangeDueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.lblChangeDueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChangeDueValue.Location = new System.Drawing.Point(35, 357);
            this.lblChangeDueValue.Name = "lblChangeDueValue";
            this.lblChangeDueValue.Size = new System.Drawing.Size(384, 28);
            this.lblChangeDueValue.TabIndex = 10;
            this.lblChangeDueValue.Text = "$0.00";
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BorderRadius = 10;
            this.btnConfirmPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnConfirmPayment.Location = new System.Drawing.Point(35, 410);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(384, 50);
            this.btnConfirmPayment.TabIndex = 11;
            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // btnCancelPayment
            // 
            this.btnCancelPayment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelPayment.BorderRadius = 10;
            this.btnCancelPayment.BorderThickness = 1;
            this.btnCancelPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPayment.FillColor = System.Drawing.Color.White;
            this.btnCancelPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancelPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCancelPayment.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnCancelPayment.Location = new System.Drawing.Point(35, 470);
            this.btnCancelPayment.Name = "btnCancelPayment";
            this.btnCancelPayment.Size = new System.Drawing.Size(384, 42);
            this.btnCancelPayment.TabIndex = 12;
            this.btnCancelPayment.Text = "Cancel";
            this.btnCancelPayment.Click += new System.EventHandler(this.btnCancelPayment_Click);
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 540);
            this.Controls.Add(this.btnCancelPayment);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.lblChangeDueValue);
            this.Controls.Add(this.lblChangeDueCaption);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.lblAmountTendered);
            this.Controls.Add(this.pnlPaymentChips);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.pnlDivider2);
            this.Controls.Add(this.lblTotalDueValue);
            this.Controls.Add(this.lblTotalDueCaption);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.FormPayment_Load);
            this.pnlPaymentChips.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblTotalDueCaption;
        private System.Windows.Forms.Label lblTotalDueValue;
        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Panel pnlPaymentChips;
        private Guna.UI2.WinForms.Guna2Button btnPayCash;
        private Guna.UI2.WinForms.Guna2Button btnPayCard;
        private Guna.UI2.WinForms.Guna2Button btnPayQR;
        private System.Windows.Forms.Label lblAmountTendered;
        private Guna.UI2.WinForms.Guna2TextBox txtAmountTendered;
        private System.Windows.Forms.Label lblChangeDueCaption;
        private System.Windows.Forms.Label lblChangeDueValue;
        private Guna.UI2.WinForms.Guna2Button btnConfirmPayment;
        private Guna.UI2.WinForms.Guna2Button btnCancelPayment;
    }
}

