using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Interfaces;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        // Get all customers including Phone and Email
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT CustomerID, CustomerName, ContactName, Phone, Email, Address, City, PostalCode, Country FROM tbCustomers";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                customers.Add(new Customer
                {
                    Id = Convert.ToInt32(row["CustomerID"]),
                    CustomerName = row["CustomerName"].ToString(),
                    ContactName = row["ContactName"] != DBNull.Value ? row["ContactName"].ToString() : "",
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    City = row["City"] != DBNull.Value ? row["City"].ToString() : "",
                    PostalCode = row["PostalCode"] != DBNull.Value ? row["PostalCode"].ToString() : "",
                    Country = row["Country"] != DBNull.Value ? row["Country"].ToString() : ""
                });
            }
            return customers;
        }

        // Get customer by ID including Phone and Email
        public Customer GetById(int id)
        {
            Customer customer = null;
            string query = "SELECT CustomerID, CustomerName, ContactName, Phone, Email, Address, City, PostalCode, Country FROM tbCustomers WHERE CustomerID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                customer = new Customer
                {
                    Id = Convert.ToInt32(row["CustomerID"]),
                    CustomerName = row["CustomerName"].ToString(),
                    ContactName = row["ContactName"] != DBNull.Value ? row["ContactName"].ToString() : "",
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    City = row["City"] != DBNull.Value ? row["City"].ToString() : "",
                    PostalCode = row["PostalCode"] != DBNull.Value ? row["PostalCode"].ToString() : "",
                    Country = row["Country"] != DBNull.Value ? row["Country"].ToString() : ""
                };
            }
            return customer;
        }

        // Add new customer including Phone and Email
        public bool Add(Customer entity)
        {
            string query = "INSERT INTO tbCustomers (CustomerName, ContactName, Phone, Email, Address, City, PostalCode, Country) " +
                           "VALUES (@CustomerName, @ContactName, @Phone, @Email, @Address, @City, @PostalCode, @Country)";
            SqlParameter[] parameters = {
                new SqlParameter("@CustomerName", entity.CustomerName),
                new SqlParameter("@ContactName", (object)entity.ContactName ?? DBNull.Value),
                new SqlParameter("@Phone", (object)entity.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)entity.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)entity.Address ?? DBNull.Value),
                new SqlParameter("@City", (object)entity.City ?? DBNull.Value),
                new SqlParameter("@PostalCode", (object)entity.PostalCode ?? DBNull.Value),
                new SqlParameter("@Country", (object)entity.Country ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // Update customer including Phone and Email
        public bool Update(Customer entity)
        {
            string query = "UPDATE tbCustomers SET CustomerName = @CustomerName, ContactName = @ContactName, " +
                           "Phone = @Phone, Email = @Email, Address = @Address, City = @City, PostalCode = @PostalCode, Country = @Country " +
                           "WHERE CustomerID = @CustomerID";
            SqlParameter[] parameters = {
                new SqlParameter("@CustomerID", entity.Id),
                new SqlParameter("@CustomerName", entity.CustomerName),
                new SqlParameter("@ContactName", (object)entity.ContactName ?? DBNull.Value),
                new SqlParameter("@Phone", (object)entity.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)entity.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)entity.Address ?? DBNull.Value),
                new SqlParameter("@City", (object)entity.City ?? DBNull.Value),
                new SqlParameter("@PostalCode", (object)entity.PostalCode ?? DBNull.Value),
                new SqlParameter("@Country", (object)entity.Country ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // Delete customer
        public bool Delete(int id)
        {
            string query = "DELETE FROM tbCustomers WHERE CustomerID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
    }
}