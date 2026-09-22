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
    public partial class SupplierForm : Form
    {
        private SupplierRepository supplierRepo;

        public SupplierForm()
        {
            InitializeComponent();
            supplierRepo = new SupplierRepository();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSupplierData();
        }

        public void LoadSupplierData()
        {
            try
            {
                DataTable dt = supplierRepo.GetAll();
                dgvSuppliers.DataSource = dt;

                if (dgvSuppliers.Columns["colSupplierId"] != null)
                    dgvSuppliers.Columns["colSupplierId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supplier data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                DataTable dt = supplierRepo.SearchSuppliers(keyword);
                dgvSuppliers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching supplier data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sup_AddEdit_Form addForm = new Sup_AddEdit_Form();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadSupplierData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSuppliers.SelectedRows[0];

                Supplier sup = new Supplier
                {
                    SupplierId = Convert.ToInt32(row.Cells["colSupplierId"].Value),
                    SupplierName = row.Cells["colSupplierName"].Value?.ToString() ?? "",
                    ContactName = row.Cells["colContactName"].Value?.ToString() ?? "",
                    Phone = row.Cells["colPhone"].Value?.ToString() ?? "",
                    Address = row.Cells["colAddress"].Value?.ToString() ?? "",
                    City = row.Cells["colCity"].Value?.ToString() ?? "",
                    PostalCode = row.Cells["colPostalCode"].Value?.ToString() ?? "",
                    Country = row.Cells["colCountry"].Value?.ToString() ?? ""
                };

                Sup_AddEdit_Form editForm = new Sup_AddEdit_Form(sup);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSupplierData();
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this supplier?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        int supplierId = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["colSupplierId"].Value);
                        bool success = supplierRepo.DeleteSupplier(supplierId);

                        if (success)
                        {
                            MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSupplierData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting supplier: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}