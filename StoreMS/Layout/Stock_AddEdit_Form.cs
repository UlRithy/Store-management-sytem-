using System;
using System.Data;
using System.Windows.Forms;
using StoreMS.Repositories; // ហៅរក StockRepository របស់អ្នក

namespace StoreMS.Layout
{
    public partial class Stock_AddEdit_Form : Form
    {
        private StockRepository stockRepo;
        private int stockId;
        private bool isEditMode;

        // ១. Constructor សម្រាប់ករណី Add (បញ្ចូលស្តុកថ្មី)
        public Stock_AddEdit_Form()
        {
            InitializeComponent();
            stockRepo = new StockRepository();
            isEditMode = false;
            lblTitle.Text = "Add New Stock";
            LoadProductsComboBox();
        }

        // ២. Constructor សម្រាប់ករណី Edit (កែប្រែស្តុកដែលមានស្រាប់ - ទទួល 4 Arguments)
        public Stock_AddEdit_Form(int id, int productId, int quantity, int minStockLevel) : this()
        {
            stockId = id;
            isEditMode = true;
            lblTitle.Text = "Edit Stock Info";

            // បំពេញទិន្នន័យចាស់ចូលក្នុង Form សម្រាប់កែប្រែ
            cmbProduct.SelectedValue = productId;
            txtQuantity.Text = quantity.ToString();
            txtMinStock.Text = minStockLevel.ToString();
        }

        // មុខងារទាញយកទិន្នន័យ Products មកដាក់បញ្ចូលក្នុង ComboBox
        private void LoadProductsComboBox()
        {
            try
            {
                DataTable dt = stockRepo.GetProductsForComboBox();
                cmbProduct.DataSource = dt;
                cmbProduct.DisplayMember = "ProductName"; // បង្ហាញឈ្មោះទំនិញ
                cmbProduct.ValueMember = "ProductID";     // តម្លៃជា ProductID (អក្សរធំ I-D)
                cmbProduct.SelectedIndex = -1;            // មិនឱ្យរើសទុកមុន
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ព្រឹត្តិការណ៍ពេលចុចប៊ូតុង Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation ត្រួតពិនិត្យទិន្នន័យមុនរក្សាទុក
                if (cmbProduct.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a product.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProduct.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Please enter a valid quantity number.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMinStock.Text) || !int.TryParse(txtMinStock.Text, out int minStock))
                {
                    MessageBox.Show("Please enter a valid minimum stock level.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinStock.Focus();
                    return;
                }

                int productId = Convert.ToInt32(cmbProduct.SelectedValue);

                // កំណត់ Status ដោយស្វ័យប្រវត្តិផ្អែកលើ Quantity និង MinStock
                string status = "In Stock";
                if (quantity <= 0)
                {
                    status = "Out of Stock";
                }
                else if (quantity <= minStock)
                {
                    status = "Low Stock";
                }

                bool success = false;

                if (isEditMode)
                {
                    // Update ស្តុកដែលមានស្រាប់
                    success = stockRepo.UpdateStock(stockId, productId, quantity, minStock, status);
                    if (success)
                    {
                        MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Insert ស្តុកថ្មី
                    success = stockRepo.InsertStock(productId, quantity, minStock, status);
                    if (success)
                    {
                        MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving stock data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ព្រឹត្តិការណ៍ពេលចុចប៊ូតុង Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}