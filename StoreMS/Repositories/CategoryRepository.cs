using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Interfaces;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        //  ទាញយកប្រភេទមុខទំនិញទាំងអស់
        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT CategoryID, CategoryName, Description FROM tbCategory"; // ប្ដូរទៅ tbCategory និងបន្ថែម Description បើត្រូវការ

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new Category
                {
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"]?.ToString() // បន្ថែម Description បើមានក្នុង Model
                });
            }
            return categories;
        }

        //  ទាញយកប្រភេទមុខទំនិញតាម ID
        public Category GetById(int id)
        {
            Category category = null;
            string query = "SELECT CategoryID, CategoryName, Description FROM tbCategory WHERE CategoryID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                category = new Category
                {
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"]?.ToString()
                };
            }
            return category;
        }

        // បន្ថែមប្រភេទមុខទំនិញថ្មី (រួមទាំង Description ប្រសិនបើមាន)
        public bool Add(Category entity)
        {
            string query = "INSERT INTO tbCategory (CategoryName, Description) VALUES (@CategoryName, @Description)";
            SqlParameter[] parameters = {
                new SqlParameter("@CategoryName", (object)entity.CategoryName ?? DBNull.Value),
                new SqlParameter("@Description", (object)entity.Description ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        //  កែប្រែឈ្មោះប្រភេទមុខទំនិញ
        public bool Update(Category entity)
        {
            string query = "UPDATE tbCategory SET CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID";
            SqlParameter[] parameters = {
                new SqlParameter("@CategoryID", entity.CategoryID),
                new SqlParameter("@CategoryName", (object)entity.CategoryName ?? DBNull.Value),
                new SqlParameter("@Description", (object)entity.Description ?? DBNull.Value)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        //  លុបប្រភេទមុខទំនិញ
        public bool Delete(int id)
        {
            string query = "DELETE FROM tbCategory WHERE CategoryID = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }
    }
}