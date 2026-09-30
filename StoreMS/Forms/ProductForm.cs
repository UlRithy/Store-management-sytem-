using StoreMS.Components;
using StoreMS.Models;
using StoreMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMS.Forms
{
    public partial class FormProduct : Form
    {
        private ProductRepository productRepo;
        private readonly Dictionary<string, Image> productImageCache = new Dictionary<string, Image>();

        public FormProduct()
        {
            InitializeComponent();
            productRepo = new ProductRepository();
            colProductImage.DefaultCellStyle.NullValue = null;
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ClearProductImageCache();
            base.OnFormClosed(e);
        }

        // ពេល Form Load ឡើង ត្រូវទាញយកទិន្នន័យមកបង្ហាញក្នុង DataGridView ស្រាប់
        private void FormProduct_Load_1(object sender, EventArgs e)
        {
            LoadProductData();
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            if (User.CurrentUser != null && User.CurrentUser.Role != "Admin")
            {
                // លាក់ ឬបិទប៊ូតុង (Disable) មិនឱ្យ Cashier Add, Edit, Delete បាន
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }

        // មុខងារសម្រាប់ Load ទិន្នន័យ
        private void LoadProductData()
        {
            try
            {
                var products = productRepo.GetAll();
                ClearProductImageCache();
                dgvProducts.DataSource = products.ToList();

                // កែតម្រូវឈ្មោះ Header ក្នុង DataGridView ឱ្យស្អាត
                if (dgvProducts.Columns["ProductId"] != null) dgvProducts.Columns["ProductId"].Visible = false;
                if (dgvProducts.Columns["CategoryId"] != null) dgvProducts.Columns["CategoryId"].Visible = false;
                if (dgvProducts.Columns["ImagePath"] != null) dgvProducts.Columns["ImagePath"].Visible = false;
                if (dgvProducts.Columns["Description"] != null)
                {
                    dgvProducts.Columns["Description"].HeaderText = "Description";
                }
                if (dgvProducts.Columns["Barcode"] != null) dgvProducts.Columns["Barcode"].HeaderText = "Code";
                if (dgvProducts.Columns["ProductName"] != null) dgvProducts.Columns["ProductName"].HeaderText = "Product Name";
                if (dgvProducts.Columns["CategoryName"] != null) dgvProducts.Columns["CategoryName"].HeaderText = "Category";
                if (dgvProducts.Columns["StockQty"] != null) dgvProducts.Columns["StockQty"].HeaderText = "QTY";
                if (dgvProducts.Columns["CostPrice"] != null) dgvProducts.Columns["CostPrice"].HeaderText = "Cost Price";
                if (dgvProducts.Columns["Price"] != null) dgvProducts.Columns["Price"].HeaderText = "Selling Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ២. មុខងារពេលចុចប៊ូតុង Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProducts();
        }

        // មុខងារសម្រាប់ Filter ទំនិញតាម Keyword (ឈ្មោះ ឬ Barcode)
        private void FilterProducts()
        {
            string keyword = txtSearch.Text.Trim();
            var allProducts = productRepo.GetAll();

            if (string.IsNullOrEmpty(keyword))
            {
                ClearProductImageCache();
                dgvProducts.DataSource = allProducts.ToList();
                return;
            }

            var filtered = allProducts.Where(p =>
                (p.ProductName != null && p.ProductName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (p.Barcode != null && p.Barcode.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            ClearProductImageCache();
            dgvProducts.DataSource = filtered;
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProducts.Columns[e.ColumnIndex].Name != "colProductImage")
            {
                return;
            }

            Product product = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            e.Value = GetProductThumbnail(product?.ImagePath);
            e.FormattingApplied = true;
        }

        private Image GetProductThumbnail(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            if (productImageCache.ContainsKey(path))
            {
                return productImageCache[path];
            }

            using (Image productImage = Image.FromFile(path))
            {
                Bitmap thumbnail = new Bitmap(productImage);
                productImageCache[path] = thumbnail;
                return thumbnail;
            }
        }

        private void ClearProductImageCache()
        {
            foreach (Image image in productImageCache.Values)
            {
                image.Dispose();
            }

            productImageCache.Clear();
        }

        // ៣. មុខងារពេលវាយអត្ថបទក្នុង Textbox ស្វែងរក
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts(); // ហៅមុខងារ Filter ឱ្យដំណើរការស្វ័យប្រវត្តិពេលវាយអក្សរ
        }

        private void lblTitle_Click(object sender, EventArgs e) { }
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tableLayoutPanelMain_Paint(object sender, PaintEventArgs e) { }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // បង្កើត Instance របស់ Add_EditForm សម្រាប់បន្ថែមថ្មី
            Add_EditForm addForm = new Add_EditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProductData(); // Refresh ទិន្នន័យក្នុង DataGridView ឡើងវិញ
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // ទាញយក Product Object ពី Row ដែលបានជ្រើសរើស (Selected Row)
                Product selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;

                // បើក Add_EditForm ផ្ញើទិន្នន័យចាស់ទៅជាមួយដើម្បីកែប្រែ
                Add_EditForm editForm = new Add_EditForm(selectedProduct);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProductData();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // សួរបញ្ជាក់ជាមុនសិន មុននឹងលុប
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                                                             "Confirm Delete",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // យក ProductId ពី Row ដែលបានជ្រើសរើស
                        Product selectedProduct = (Product)dgvProducts.SelectedRows[0].DataBoundItem;

                        bool success = productRepo.Delete(selectedProduct.ProductID);
                        if (success)
                        {
                            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProductData(); // Refresh ទិន្នន័យឡើងវិញ
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProducts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}