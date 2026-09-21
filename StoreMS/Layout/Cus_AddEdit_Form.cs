using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StoreMS.Data;

namespace StoreMS.Components
{
    public partial class Cus_AddEdit_Form : Form
    {
        private int? customerId = null;

        public Cus_AddEdit_Form()
        {
            InitializeComponent();
            lblTitle.Text = "ADD CUSTOMER";
        }

        public Cus_AddEdit_Form(int id)
        {
            InitializeComponent();
            customerId = id;
            lblTitle.Text = "EDIT CUSTOMER";
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            if (customerId == null) return;

            try
            {
                string query = "SELECT CustomerID, CustomerName, Address, City, PostalCode, Country, Phone, Email FROM tbCustomers WHERE CustomerID = @ID";
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID", customerId.Value)
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtCustomerName.Text = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : "";
                    txtPhone.Text = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "";
                    txtEmail.Text = row["Email"] != DBNull.Value ? row["Email"].ToString() : "";
                    txtCity.Text = row["City"] != DBNull.Value ? row["City"].ToString() : "";
                    txtPostalCode.Text = row["PostalCode"] != DBNull.Value ? row["PostalCode"].ToString() : "";
                    txtCountry.Text = row["Country"] != DBNull.Value ? row["Country"].ToString() : "";
                    txtAddress.Text = row["Address"] != DBNull.Value ? row["Address"].ToString() : "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string city = txtCity.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string country = txtCountry.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Please enter the customer name!", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            try
            {
                string query = "";
                SqlParameter[] parameters;

                if (customerId == null)
                {
                    query = "INSERT INTO tbCustomers (CustomerName, Address, City, PostalCode, Country, Phone, Email) " +
                            "VALUES (@CustomerName, @Address, @City, @PostalCode, @Country, @Phone, @Email)";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@CustomerName", customerName),
                        new SqlParameter("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address),
                        new SqlParameter("@City", string.IsNullOrEmpty(city) ? (object)DBNull.Value : city),
                        new SqlParameter("@PostalCode", string.IsNullOrEmpty(postalCode) ? (object)DBNull.Value : postalCode),
                        new SqlParameter("@Country", string.IsNullOrEmpty(country) ? (object)DBNull.Value : country),
                        new SqlParameter("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone),
                        new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email)
                    };
                }
                else
                {
                    query = "UPDATE tbCustomers SET CustomerName = @CustomerName, " +
                            "Address = @Address, City = @City, PostalCode = @PostalCode, Country = @Country, " +
                            "Phone = @Phone, Email = @Email WHERE CustomerID = @CustomerID";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@CustomerName", customerName),
                        new SqlParameter("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address),
                        new SqlParameter("@City", string.IsNullOrEmpty(city) ? (object)DBNull.Value : city),
                        new SqlParameter("@PostalCode", string.IsNullOrEmpty(postalCode) ? (object)DBNull.Value : postalCode),
                        new SqlParameter("@Country", string.IsNullOrEmpty(country) ? (object)DBNull.Value : country),
                        new SqlParameter("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone),
                        new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                        new SqlParameter("@CustomerID", customerId.Value)
                    };
                }

                int rowsAffected = Database.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show(customerId == null ? "Customer added successfully!" : "Customer updated successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}