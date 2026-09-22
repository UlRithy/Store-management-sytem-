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
using StoreMS.Layout;

namespace StoreMS.Forms
{
    public partial class StockForm : Form
    {
        private StockRepository stockRepo;

        public StockForm()
        {
            InitializeComponent();
            stockRepo = new StockRepository();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }

        // មុខងារទាញយកទិន្នន័យស្តុកទាំងអស់មកបង្ហាញក្នុង DataGridView
        private void LoadStockData()
        {
            try
            {
                List<Stock> stockList = stockRepo.GetAllStock();
                dgvStock.DataSource = stockList;

                // កំណត់ឈ្មោះ Header ឱ្យបានស្រស់ស្អាត (បើចាំបាច់)
                if (dgvStock.Columns["StockId"] != null) dgvStock.Columns["StockId"].Visible = false; // ឬបង្ហាញតាមតម្រូវការ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // អាចទុកចោល ឬប្រើប្រាស់ពេលចុចលើ Cell ណាមួយក្នុង Grid
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // ស្វែងរកដោយស្វ័យប្រវត្តិពេលវាយអក្សរ
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    LoadStockData();
                    return;
                }

                List<Stock> searchResult = stockRepo.SearchStock(keyword);
                dgvStock.DataSource = searchResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadStockData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (Stock_AddEdit_Form addForm = new Stock_AddEdit_Form())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStockData(); // Refresh ទិន្នន័យក្រោយពេលបន្ថែមបានជោគជ័យ
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                // ទាញយកទិន្នន័យពីแถវដែលបានជ្រើសរើស (Selected Row)
                var selectedStock = (Stock)dgvStock.SelectedRows[0].DataBoundItem;

                using (Stock_AddEdit_Form editForm = new Stock_AddEdit_Form(selectedStock.StockId, selectedStock.ProductId, selectedStock.Quantity, selectedStock.MinStockLevel))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadStockData(); // Refresh ទិន្នន័យក្រោយពេលកែប្រែបានជោគជ័យ
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a stock item to update.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this stock record?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var selectedStock = (Stock)dgvStock.SelectedRows[0].DataBoundItem;
                        bool success = stockRepo.DeleteStock(selectedStock.StockId);

                        if (success)
                        {
                            MessageBox.Show("Stock deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStockData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a stock item to delete.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}