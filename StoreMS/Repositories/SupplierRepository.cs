using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Interfaces;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        // ១. ទាញយកបញ្ជីអ្នកផ្គត់ផ្គង់ទាំងអស់
        public IEnumerable<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = "SELECT SupplierID, SupplierName, Phone, ContactName FROM tbSuppliers";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                suppliers.Add(new Supplier
                {
                    SupplierId = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    ContactPerson = row["ContactName"] != DBNull.Value ? row["ContactName"].ToString() : ""
                });
            }
            return suppliers;
        }

        // ២. ទាញយកព័ត៌មានអ្នកផ្គត់ផ្គង់តាម ID
        public Supplier GetById(int id)
        {
            Supplier supplier = null;
            string query = "SELECT SupplierID, SupplierName, Phone, ContactName FROM tbSuppliers WHERE SupplierID = @SupplierID";
            SqlParameter[] parameters = {
                new SqlParameter("@SupplierID", id)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                supplier = new Supplier
                {
                    SupplierId = Convert.ToInt32(row["SupplierID"]),
                    SupplierName = row["SupplierName"].ToString(),
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    ContactPerson = row["ContactName"] != DBNull.Value ? row["ContactName"].ToString() : ""
                };
            }
            return supplier;
        }

        // ៣. បន្ថែមអ្នកផ្គត់ផ្គង់ថ្មី
        public bool Add(Supplier entity)
        {
            string query = "INSERT INTO tbSuppliers (SupplierName, Phone, ContactName) VALUES (@SupplierName, @Phone, @ContactName)";
            SqlParameter[] parameters = {
                new SqlParameter("@SupplierName", entity.SupplierName),
                new SqlParameter("@Phone", (object)entity.Phone ?? DBNull.Value),
                new SqlParameter("@ContactName", (object)entity.ContactPerson ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៤. កែប្រែព័ត៌មានអ្នកផ្គត់ផ្គង់
        public bool Update(Supplier entity)
        {
            string query = "UPDATE tbSuppliers SET SupplierName = @SupplierName, Phone = @Phone, ContactName = @ContactName WHERE SupplierID = @SupplierID";
            SqlParameter[] parameters = {
                new SqlParameter("@SupplierID", entity.SupplierId),
                new SqlParameter("@SupplierName", entity.SupplierName),
                new SqlParameter("@Phone", (object)entity.Phone ?? DBNull.Value),
                new SqlParameter("@ContactName", (object)entity.ContactPerson ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៥. លុបអ្នកផ្គត់ផ្គង់
        public bool Delete(int id)
        {
            string query = "DELETE FROM tbSuppliers WHERE SupplierID = @SupplierID";
            SqlParameter[] parameters = {
                new SqlParameter("@SupplierID", id)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
    }
}