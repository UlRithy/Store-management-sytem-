using System;
using System.Drawing;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class PaymentForm : Form
    {
        public decimal TotalAmount { get; set; }
        public decimal CashReceived { get; set; }
        public decimal ChangeAmount { get; set; }
        public string PaymentMethod { get; set; } = "Cash";
        public bool IsConfirmed { get; private set; } = false;

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // បង្ហាញទឹកប្រាក់សរុប និងកំណត់តម្លៃស្វ័យប្រវត្តិក្នុងប្រអប់ទទួលប្រាក់
            lblTotalToPay.Text = "$" + TotalAmount.ToString("N2");
            txtCashReceived.Text = TotalAmount.ToString("N2");
            txtCashReceived.SelectAll();
            txtCashReceived.Focus();
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // មុខងារគណនាប្រាក់អាប់ស្វ័យប្រវត្តិ
        private void CalculateChange()
        {
            if (decimal.TryParse(txtCashReceived.Text, out decimal cash))
            {
                CashReceived = cash;
                ChangeAmount = CashReceived - TotalAmount;

                if (ChangeAmount >= 0)
                {
                    lblChange.Text = "$" + ChangeAmount.ToString("N2");
                    lblChange.ForeColor = Color.FromArgb(40, 167, 69); // ពណ៌បៃតង (គ្រប់គ្រាន់)
                }
                else
                {
                    lblChange.Text = "$0.00";
                    lblChange.ForeColor = Color.FromArgb(220, 53, 69); // ពណ៌ក្រហម (ខ្វះលុយ)
                }
            }
            else
            {
                CashReceived = 0;
                ChangeAmount = 0;
                lblChange.Text = "$0.00";
                lblChange.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CashReceived < TotalAmount)
            {
                MessageBox.Show("ចំនួនទឹកប្រាក់ទទួលបានមិនទាន់គ្រប់គ្រាន់តាមតម្លៃសរុបទេ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                txtCashReceived.SelectAll();
                return;
            }

            // យកប្រភេទនៃការបង់ប្រាក់ពី ComboBox
            if (cmbPaymentMethod.SelectedItem != null)
            {
                PaymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            }

            IsConfirmed = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }
    }
}