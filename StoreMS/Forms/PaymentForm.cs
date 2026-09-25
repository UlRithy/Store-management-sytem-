using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class PaymentForm : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================

        private readonly decimal _totalDue;


        // =========================================================
        // PROPERTIES
        // =========================================================

        /// <summary>
        /// Payment method:
        /// Cash
        /// Card
        /// ABA QR
        /// </summary>
        public string SelectedPaymentMethod { get; private set; }
            = "Cash";


        /// <summary>
        /// Amount received from customer.
        /// </summary>
        public decimal AmountTendered { get; private set; }


        /// <summary>
        /// Change returned to customer.
        /// </summary>
        public decimal ChangeDue { get; private set; }


        /// <summary>
        /// Payment method used by Sale_POSForm.
        /// </summary>
        public string PaymentMethod
        {
            get
            {
                return SelectedPaymentMethod;
            }
        }


        /// <summary>
        /// Change amount used by Sale_POSForm.
        /// </summary>
        public decimal ChangeAmount
        {
            get
            {
                return ChangeDue;
            }
        }


        /// <summary>
        /// True when customer confirms payment.
        /// </summary>
        public bool IsConfirmed
        {
            get
            {
                return DialogResult == DialogResult.OK;
            }
        }


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public PaymentForm(decimal totalDue)
        {
            InitializeComponent();

            _totalDue = totalDue;
        }


        // =========================================================
        // FORM LOAD
        // =========================================================

        private void FormPayment_Load(
            object sender,
            EventArgs e)
        {
            // -----------------------------------------
            // Show Total
            // -----------------------------------------

            lblTotalDueValue.Text =
                _totalDue.ToString("$0.00");


            // -----------------------------------------
            // Default Amount
            // -----------------------------------------

            txtAmountTendered.Text =
                _totalDue.ToString(
                    "0.00",
                    CultureInfo.InvariantCulture
                );


            // -----------------------------------------
            // Default Payment Method
            // -----------------------------------------

            SelectedPaymentMethod =
                "Cash";


            // -----------------------------------------
            // Calculate Change
            // -----------------------------------------

            RecalculateChange();
        }


        // =========================================================
        // PAYMENT METHOD BUTTON
        // =========================================================

        private void PaymentMethod_Click(
            object sender,
            EventArgs e)
        {
            Button clickedButton =
                sender as Button;


            if (clickedButton == null)
            {
                return;
            }


            // -----------------------------------------
            // Get Payment Method
            // -----------------------------------------

            SelectedPaymentMethod =
                clickedButton.Text.Trim();


            // -----------------------------------------
            // Cash
            // -----------------------------------------

            bool isCash =
                SelectedPaymentMethod
                .Equals(
                    "Cash",
                    StringComparison.OrdinalIgnoreCase
                );


            txtAmountTendered.Enabled =
                isCash;


            // -----------------------------------------
            // Card / ABA QR
            // -----------------------------------------

            if (!isCash)
            {
                txtAmountTendered.Text =
                    _totalDue.ToString(
                        "0.00",
                        CultureInfo.InvariantCulture
                    );
            }


            // -----------------------------------------
            // Calculate
            // -----------------------------------------

            RecalculateChange();
        }


        // =========================================================
        // AMOUNT CHANGED
        // =========================================================

        private void txtAmountTendered_TextChanged(
            object sender,
            EventArgs e)
        {
            RecalculateChange();
        }


        // =========================================================
        // CALCULATE CHANGE
        // =========================================================

        private void RecalculateChange()
        {
            decimal tendered;


            // -----------------------------------------
            // Invalid input
            // -----------------------------------------

            if (
                !decimal.TryParse(
                    txtAmountTendered.Text,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out tendered
                )
            )
            {
                lblChangeDueValue.Text =
                    "$0.00";

                lblChangeDueValue.ForeColor =
                    Color.FromArgb(
                        15,
                        23,
                        42
                    );

                return;
            }


            // -----------------------------------------
            // Calculate
            // -----------------------------------------

            decimal change =
                tendered - _totalDue;


            lblChangeDueValue.Text =
                change.ToString("$0.00");


            // -----------------------------------------
            // Color
            // -----------------------------------------

            if (change < 0)
            {
                // Not enough money
                lblChangeDueValue.ForeColor =
                    Color.FromArgb(
                        220,
                        38,
                        38
                    );
            }
            else
            {
                // Enough money
                lblChangeDueValue.ForeColor =
                    Color.FromArgb(
                        15,
                        23,
                        42
                    );
            }
        }


        // =========================================================
        // CONFIRM PAYMENT
        // =========================================================

        private void btnConfirmPayment_Click(
            object sender,
            EventArgs e)
        {
            decimal tendered;


            // -----------------------------------------
            // Validate Amount
            // -----------------------------------------

            if (
                !decimal.TryParse(
                    txtAmountTendered.Text,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out tendered
                )
                ||
                tendered < 0
            )
            {
                MessageBox.Show(
                    this,
                    "Please enter a valid amount received.",
                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAmountTendered.Focus();

                return;
            }


            // -----------------------------------------
            // Cash must be enough
            // -----------------------------------------

            if (
                SelectedPaymentMethod
                    .Equals(
                        "Cash",
                        StringComparison.OrdinalIgnoreCase
                    )
                &&
                tendered < _totalDue
            )
            {
                MessageBox.Show(
                    this,
                    "Amount received is less than the total due.",
                    "Insufficient Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtAmountTendered.Focus();

                return;
            }


            // -----------------------------------------
            // Card / ABA QR
            // -----------------------------------------

            if (
                !SelectedPaymentMethod.Equals(
                    "Cash",
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                // For non-cash payment,
                // amount should equal total.
                tendered = _totalDue;
            }


            // -----------------------------------------
            // Save Payment Result
            // -----------------------------------------

            AmountTendered =
                tendered;


            ChangeDue =
                tendered - _totalDue;


            // -----------------------------------------
            // Close Successfully
            // -----------------------------------------

            DialogResult =
                DialogResult.OK;

            Close();
        }


        // =========================================================
        // CANCEL PAYMENT
        // =========================================================

        private void btnCancelPayment_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}