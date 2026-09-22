using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class SupplierRepository
    {
        // ផ្លាស់ប្តូរ Connection String នេះទៅតាម Server របស់អ្នក (ឧ. localhost, .\SQLEXPRESS ឬ ឈ្មោះ Server ផ្ទាល់ខ្លួន)
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StoreManagement;Integrated Security=True";

        // ១. ទាញយកទិន្នន័យ Supplier ទាំងអស់ (សម្រាប់បង្ហាញជា DataTable ក្នុង DataGridView)
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            string query = "SELECT SupplierID, SupplierName, ContactName, Phone, Address, City, PostalCode, Country FROM tbSuppliers";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // ២. ស្វែងរក Supplier តាមឈ្មោះ លេខទូរស័ព្ទ ឬ ក្រុង (City)
        public DataTable SearchSuppliers(string keyword)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT SupplierID, SupplierName, ContactName, Phone, Address, City, PostalCode, Country 
                             FROM tbSuppliers 
                             WHERE SupplierName LIKE @Keyword OR Phone LIKE @Keyword OR City LIKE @Keyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // ៣. បន្ថែម Supplier ថ្មី (Insert)
        public bool InsertSupplier(Supplier supplier)
        {
            string query = @"INSERT INTO tbSuppliers (SupplierName, ContactName, Address, City, PostalCode, Country, Phone) 
                             VALUES (@SupplierName, @ContactName, @Address, @City, @PostalCode, @Country, @Phone)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", (object)supplier.SupplierName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactName", (object)supplier.ContactName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object)supplier.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostalCode", (object)supplier.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Country", (object)supplier.Country ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)supplier.Phone ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // ៤. កែប្រែទិន្នន័យ Supplier (Update)
        public bool UpdateSupplier(Supplier supplier)
        {
            string query = @"UPDATE tbSuppliers 
                             SET SupplierName = @SupplierName, 
                                 ContactName = @ContactName, 
                                 Address = @Address, 
                                 City = @City, 
                                 PostalCode = @PostalCode, 
                                 Country = @Country, 
                                 Phone = @Phone 
                             WHERE SupplierID = @SupplierID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierId);
                    cmd.Parameters.AddWithValue("@SupplierName", (object)supplier.SupplierName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactName", (object)supplier.ContactName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)supplier.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@City", (object)supplier.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostalCode", (object)supplier.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Country", (object)supplier.Country ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)supplier.Phone ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // ៥. លុប Supplier (Delete)
        public bool DeleteSupplier(int supplierId)
        {
            string query = "DELETE FROM tbSuppliers WHERE SupplierID = @SupplierID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}