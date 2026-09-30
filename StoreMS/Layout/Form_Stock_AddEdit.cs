using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StoreMS.Components
{
    public partial class Form_Stock_AddEdit : Form
    {
        // TODO: replace with the real product list (e.g. loaded from the database).
        private readonly Dictionary<string, string> _productCategories = new Dictionary<string, string>
        {
            { "Coca-Cola 330ml", "Beverages" },
            { "Bottled Water 500ml", "Beverages" },
            { "Potato Chips", "Snacks" },
            { "Instant Noodles", "Snacks" },
            { "Dish Soap 500ml", "Household" },
            { "Tissue Box", "Household" },
            { "Croissant", "Bakery" },
            { "White Bread Loaf", "Bakery" },
        };

        /// <summary>
        /// The stock record id being edited, or null when adding a new one.
        /// </summary>
        public int? StockId { get; private set; }

        public Form_Stock_AddEdit()
        {
            InitializeComponent();
        }

        public Form_Stock_AddEdit(int stockId) : this()
        {
            // Editing an existing record.
            StockId = stockId;
            lblTitle.Text = "Edit Stock";
            // TODO: load the real stock record for stockId and populate the fields below.
        }

        private void Form_Stock_AddEdit_Load(object sender, EventArgs e)
        {
            cmbProduct.Items.Clear();
            foreach (var name in _productCategories.Keys)
            {
                cmbProduct.Items.Add(name);
            }

            if (cmbProduct.Items.Count > 0)
            {
                cmbProduct.SelectedIndex = 0;
            }

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null) return;

            string productName = cmbProduct.SelectedItem.ToString();
            if (_productCategories.TryGetValue(productName, out string category))
            {
                if (!cmbCategory.Items.Contains(category))
                {
                    cmbCategory.Items.Add(category);
                }
                cmbCategory.SelectedItem = category;
            }
        }

        private bool TryValidateInput(out int quantity, out int minStock)
        {
            quantity = 0;
            minStock = 0;

            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a product.", "Missing product",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
            {
                MessageBox.Show(this, "Enter a valid quantity (0 or more).", "Invalid quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtMinStock.Text, out minStock) || minStock < 0)
            {
                MessageBox.Show(this, "Enter a valid reorder threshold (0 or more).", "Invalid threshold",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!TryValidateInput(out int quantity, out int minStock)) return;

            // TODO: persist the stock record (insert or update, based on StockId) to the database.
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}