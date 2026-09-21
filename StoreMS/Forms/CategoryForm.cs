using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreMS.Components;
using StoreMS.Models;
using StoreMS.Repositories;

namespace StoreMS.Forms
{
    public partial class FormCategory : Form
    {
        private CategoryRepository categoryRepo;

        public FormCategory()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepository();
        }

        // ១ពេល Form Load ឡើង ត្រូវទាញយកទិន្នន័យមកបង្ហាញក្នុង DataGridView

        private void FormCategory_Load_1(object sender, EventArgs e)
        {
            
            LoadCategories();
        }
        // មុខងារสำหรับ Load ទិន្នន័យ Category
        private void LoadCategories()
        {
            try
            {
                var categories = categoryRepo.GetAll();
                dgvCategories.DataSource = categories.ToList();

                // កែតម្រូវឈ្មោះ Header ឬលាក់ Column មិនចាំបាច់
                if (dgvCategories.Columns["CategoryID"] != null)
                {
                    dgvCategories.Columns["CategoryID"].Visible = false; // អាចលាក់ ID បានបើមិនចង់បង្ហាញ
                }

                if (dgvCategories.Columns["CategoryName"] != null)
                {
                    dgvCategories.Columns["CategoryName"].HeaderText = "Category Name";
                }

                if (dgvCategories.Columns["Description"] != null)
                {
                    dgvCategories.Columns["Description"].HeaderText = "Description";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ២. មុខងារពេលចុចប៊ូតុង Add (+ Add Category)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new Cate_AddEdit_From1())
            {
                // ប្រសិនបើរក្សាទុកជោគជ័យ (DialogResult.OK) វានឹង Refresh ទិន្នន័យភ្លាមៗ
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }

        // ៣. មុខងារពេលចុចប៊ូតុង Edit (កែប្រែ)
     
        

        // ៤. មុខងារពេលចុចប៊ូតុង Delete (លុប)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var selectedCategory = dgvCategories.SelectedRows[0].DataBoundItem as Category;
                        if (selectedCategory != null)
                        {
                            int id = selectedCategory.CategoryID;
                            bool success = categoryRepo.Delete(id);

                            if (success)
                            {
                                MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCategories();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                MessageBox.Show("Please select a category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvCategories.SelectedCells.Count > 0)
            {
                // យក Row នៃ Cell ដែលបានចុច
                int rowIndex = dgvCategories.SelectedCells[0].RowIndex;
                var selectedCategory = dgvCategories.Rows[rowIndex].DataBoundItem as Category;

                if (selectedCategory != null)
                {
                    int id = selectedCategory.CategoryID;
                    string name = selectedCategory.CategoryName;
                    string desc = selectedCategory.Description;

                    using (var editForm = new Cate_AddEdit_From1(id, name, desc))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadCategories();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                var allCategories = categoryRepo.GetAll();

                if (!string.IsNullOrEmpty(keyword))
                {
                    // ត្រងយក Category ណាដែលមានឈ្មោះត្រូវនឹងពាក្យស្វែងរក
                    var filtered = allCategories.Where(c => c.CategoryName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    dgvCategories.DataSource = filtered;
                }
                else
                {
                    dgvCategories.DataSource = allCategories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}