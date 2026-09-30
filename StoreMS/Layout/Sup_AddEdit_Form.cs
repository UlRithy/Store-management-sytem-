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

namespace StoreMS.Layout
{
    public partial class Sup_AddEdit_Form : Form
    {
        private SupplierRepository supplierRepo;
        private int supplierId;
        private bool isEditMode = false;

        // ១. Constructor សម្រាប់ករណីបន្ថែមថ្មី (Add Mode)
        public Sup_AddEdit_Form()
        {
            InitializeComponent();
            supplierRepo = new SupplierRepository();
            isEditMode = false;
            lblTitle.Text = "Add New Supplier";
        }

        // ២. Constructor សម្រាប់ករណីកែប្រែ (Edit Mode)
        public Sup_AddEdit_Form(Supplier supplier) : this()
        {
            if (supplier != null)
            {
                isEditMode = true;
                lblTitle.Text = "Edit Supplier";
                supplierId = supplier.SupplierId;

                // បញ្ចូលទិន្នន័យចាស់ទៅក្នុង Textboxes
                txtSupplierName.Text = supplier.SupplierName;
                txtContactName.Text = supplier.ContactName;
                txtPhone.Text = supplier.Phone;
                txtAddress.Text = supplier.Address;
                txtCity.Text = supplier.City;
                txtPostalCode.Text = supplier.PostalCode;
                txtCountry.Text = supplier.Country;
            }
        }

        // ៣. ព្រឹត្តិការណ៍ពេលចុចប៊ូតុង Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation ត្រួតពិនិត្យទិន្នន័យចាំបាច់
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Please enter supplier name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                Supplier supplier = new Supplier
                {
                    SupplierId = this.supplierId,
                    SupplierName = txtSupplierName.Text.Trim(),
                    ContactName = txtContactName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    PostalCode = txtPostalCode.Text.Trim(),
                    Country = txtCountry.Text.Trim()
                };

                bool success = false;

                if (isEditMode)
                {
                    // ធ្វើបច្ចុប្បន្នភាព (Update)
                    success = supplierRepo.UpdateSupplier(supplier);
                    if (success)
                    {
                        MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // បន្ថែមថ្មី (Insert)
                    success = supplierRepo.InsertSupplier(supplier);
                    if (success)
                    {
                        MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ៤. ព្រឹត្តិការណ៍ពេលចុចប៊ូតុង Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}