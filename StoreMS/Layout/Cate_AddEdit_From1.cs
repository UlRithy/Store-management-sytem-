using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreMS.Models;
using StoreMS.Repositories;

namespace StoreMS.Components
{
    public partial class Cate_AddEdit_From1 : Form
    {
        private CategoryRepository categoryRepo;
        private int categoryId;
        private bool isEditMode;

        // Constructor សម្រាប់ករណី Add (បញ្ចូលប្រភេទថ្មី)
        public Cate_AddEdit_From1()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepository();
            isEditMode = false;
            this.Text = "Add New Category";
        }

        // Constructor សម្រាប់ករណី Edit (កែប្រែប្រភេទដែលមានស្រាប់)
        public Cate_AddEdit_From1(int id, string name, string description) : this()
        {
            categoryId = id;
            isEditMode = true;
            this.Text = "Edit Category";

            // បញ្ចូលទិន្នន័យចាស់មកកាន់ TextBox របស់អ្នក
            // (ចំណាំ៖ ប្រសិនបើ TextBox របស់អ្នកឈ្មោះផ្សេង សូមប្ដូរ txtCategoryName និង txtDescription តាមហ្វមរបស់អ្នក)
            txtCategoryName.Text = name;
            txtDescription.Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ទាញយកតម្លៃពី TextBox (សូមកែឈ្មោះ txtCategoryName និង txtDescription តាម Designer ជាក់ស្តែងរបស់អ្នក)
            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter category name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category category = new Category
            {
                CategoryID = categoryId, // ប្រសិនបើ Model របស់អ្នកប្រើ CategoryId ឬ Category_ID សូមផ្ទៀងផ្ទាត់អក្ខរាវិរុទ្ធឱ្យដូចគ្នា
                CategoryName = name,
                Description = desc
            };

            bool success = isEditMode ? categoryRepo.Update(category) : categoryRepo.Add(category);

            if (success)
            {
                MessageBox.Show(isEditMode ? "Category updated successfully!" : "Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}