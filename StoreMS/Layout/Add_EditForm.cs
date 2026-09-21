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
using StoreMS.Models;
using StoreMS.Repositories;

namespace StoreMS.Components
{
    public partial class Add_EditForm : Form
    {
        private ProductRepository productRepo;
        private CategoryRepository categoryRepo;
        private SupplierRepository supplierRepo;

        private bool isEditMode = false;
        private int currentProductId = 0;
        private string imagePath = "";
        private string imageName = "";

        // Constructor ទី១៖ សម្រាប់ករណី Add (បន្ថែមថ្មី)
        public Add_EditForm()
        {
            InitializeComponent();
            productRepo = new ProductRepository();
            categoryRepo = new CategoryRepository();
            supplierRepo = new SupplierRepository();

            isEditMode = false;
            this.Text = "Add New Product";

            LoadCategoriesToComboBox();
            LoadSuppliersToComboBox();
        }

        // Constructor ទី២៖ សម្រាប់ករណី Edit (កែប្រែទំនិញចាស់)
        public Add_EditForm(Product product) : this()
        {
            if (product != null)
            {
                isEditMode = true;
                currentProductId = product.ProductID;
                this.Text = "Edit Product";

                txtName.Text = product.ProductName;
                txtBarCode.Text = product.Barcode;
                txtSellingPrice.Text = product.Price.ToString();
                txtCostPrice.Text = product.CostPrice.ToString();
                txtQty.Text = product.StockQty.ToString();
                txtUnit.Text = product.Unit;
                imageName = product.Image;
                imagePath = product.ImagePath;
                txtDescription.Text = product.Description;

                // កំណត់ Category ដែលបានជ្រើសរើសរួច
                if (product.CategoryID.HasValue)
                {
                    cmbCategory.SelectedValue = product.CategoryID.Value;
                }

                // កំណត់ Supplier ដែលបានជ្រើសរើសរួច
                if (product.SupplierID.HasValue)
                {
                    cmbSupplier.SelectedValue = product.SupplierID.Value;
                }

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    LoadProductImage(imagePath);
                }
            }
        }

        private void Add_EditForm_Load(object sender, EventArgs e)
        {
        }

        // មុខងារទាញយក Category មកដាក់ក្នុង ComboBox
        private void LoadCategoriesToComboBox()
        {
            try
            {
                var categories = categoryRepo.GetAll();
                cmbCategory.DataSource = categories.ToList();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // មុខងារទាញយក Supplier មកដាក់ក្នុង ComboBox (ប្រើ Name និង Id ឱ្យត្រូវនឹង Repository)
        private void LoadSuppliersToComboBox()
        {
            try
            {
                var suppliers = supplierRepo.GetAll();
                cmbSupplier.DataSource = suppliers.ToList();
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierId";  
                cmbSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // មុខងារជ្រើសរើសរូបភាព (Browse Image)
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    imageName = Path.GetFileName(imagePath);
                    LoadProductImage(imagePath);
                }
            }
        }

        private void LoadProductImage(string path)
        {
            if (pictureBoxProduct.Image != null)
            {
                pictureBoxProduct.Image.Dispose();
                pictureBoxProduct.Image = null;
            }

            using (Image selectedImage = Image.FromFile(path))
            {
                pictureBoxProduct.Image = new Bitmap(selectedImage);
            }
        }

        // មុខងាររក្សាទុក (Save - Add or Update)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // ពិនិត្យទិន្នន័យចាំបាច់ (Validation)
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSellingPrice.Text))
                {
                    MessageBox.Show("Please fill in all required fields (Product Name, Price).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product product = new Product
                {
                    ProductID = currentProductId,
                    ProductName = txtName.Text.Trim(),
                    Barcode = txtBarCode.Text.Trim(),
                    CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),

                    // ទាញយក SupplierID ផ្អែកលើ SelectedValue (ដែលជា Id)
                    SupplierID = cmbSupplier.SelectedValue != null ? Convert.ToInt32(cmbSupplier.SelectedValue) : (int?)null,
                    Unit = txtUnit.Text.Trim(),

                    Price = Convert.ToDecimal(txtSellingPrice.Text),
                    CostPrice = string.IsNullOrWhiteSpace(txtCostPrice.Text) ? 0 : Convert.ToDecimal(txtCostPrice.Text),
                    StockQty = string.IsNullOrWhiteSpace(txtQty.Text) ? 0 : Convert.ToInt32(txtQty.Text),
                    Image = imageName,
                    ImagePath = imagePath,
                    Description = txtDescription.Text.Trim()
                };

                bool success = false;
                if (isEditMode)
                {
                    success = productRepo.Update(product);
                }
                else
                {
                    success = productRepo.Add(product);
                }

                if (success)
                {
                    MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // មុខងារបោះបង់ (Cancel)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
