namespace StoreMS.Components
{
    partial class Cus_AddEdit_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ADD CUSTOMER";

            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.lblCustomerName.Location = new System.Drawing.Point(32, 65);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(107, 17);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name";

            // txtCustomerName
            this.txtCustomerName.BorderRadius = 6;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(35, 87);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PlaceholderText = "Enter customer name...";
            this.txtCustomerName.Size = new System.Drawing.Size(380, 38);
            this.txtCustomerName.TabIndex = 2;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.lblPhone.Location = new System.Drawing.Point(32, 135);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(46, 17);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone";

            // txtPhone
            this.txtPhone.BorderRadius = 6;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(35, 157);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Enter phone number...";
            this.txtPhone.Size = new System.Drawing.Size(380, 38);
            this.txtPhone.TabIndex = 4;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.lblEmail.Location = new System.Drawing.Point(32, 205);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";

            // txtEmail
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(35, 227);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Enter email address...";
            this.txtEmail.Size = new System.Drawing.Size(380, 38);
            this.txtEmail.TabIndex = 6;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.lblAddress.Location = new System.Drawing.Point(32, 275);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 17);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address";

            // txtAddress
            this.txtAddress.BorderRadius = 6;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(35, 297);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "Enter address...";
            this.txtAddress.Size = new System.Drawing.Size(380, 65);
            this.txtAddress.TabIndex = 8;

            // btnSave
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(195, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";

            // btnCancel
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(310, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";

            // Cus_AddEdit_form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(454, 451);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cus_AddEdit_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}