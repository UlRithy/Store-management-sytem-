using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StoreMS.Components;
using StoreMS.Data;

namespace StoreMS.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData(string searchKeyword = "")
        {
            try
            {
                string query = "SELECT CustomerID, CustomerName, Phone, Email, Address, City, PostalCode, Country FROM tbCustomers";
                SqlParameter[] parameters = null;

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query += " WHERE CustomerName LIKE @search OR Phone LIKE @search OR Email LIKE @search OR City LIKE @search";
                    parameters = new SqlParameter[] {
                        new SqlParameter("@search", "%" + searchKeyword + "%")
                    };
                }

                DataTable dt = Database.ExecuteQuery(query, parameters);
                dgvCustomers.DataSource = dt;

                if (dgvCustomers.Columns["CustomerID"] != null)
                {
                    dgvCustomers.Columns["CustomerID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using (Cus_AddEdit_Form addForm = new Cus_AddEdit_Form())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                using (Cus_AddEdit_Form editForm = new Cus_AddEdit_Form(customerID))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomerData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?",
                                                     "Confirm Deletion",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM tbCustomers WHERE CustomerID = @ID";
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@ID", customerID)
                        };

                        int rowsAffected = Database.ExecuteNonQuery(query, parameters);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomerData(txtSearch.Text.Trim());
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadCustomerData(txtSearch.Text.Trim());
        }
    }
}