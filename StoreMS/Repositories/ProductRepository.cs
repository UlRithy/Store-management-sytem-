using StoreMS.Data;
using StoreMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoreMS.Repositories
{
    public class ProductRepository
    {
        // យកទំនិញទាំងអស់មកបង្ហាញ
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            string query = @"SELECT p.ProductID, p.ProductName, p.SupplierID, p.CategoryID, 
                      c.CategoryName, p.Unit, p.Price, p.CostPrice, p.StockQty, 
                      p.Barcode, p.Image, p.ImagePath, p.Description 
               FROM tbProducts p 
               LEFT JOIN tbCategory c ON p.CategoryID = c.CategoryID";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    SupplierID = row["SupplierID"] != DBNull.Value ? (int?)Convert.ToInt32(row["SupplierID"]) : null,
                    CategoryID = row["CategoryID"] != DBNull.Value ? (int?)Convert.ToInt32(row["CategoryID"]) : null,
                    CategoryName = row["CategoryName"]?.ToString(),
                    Unit = row["Unit"]?.ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    CostPrice = row["CostPrice"] != DBNull.Value ? Convert.ToDecimal(row["CostPrice"]) : 0,
                    StockQty = row["StockQty"] != DBNull.Value ? Convert.ToInt32(row["StockQty"]) : 0,
                    Barcode = row["Barcode"]?.ToString(),
                    Image = row["Image"]?.ToString(),
                    ImagePath = row["ImagePath"]?.ToString(),
                    Description = row["Description"]?.ToString()
                });
            }
            return products;
        }

        // បន្ថែមទំនិញថ្មី
        public bool Add(Product product)
        {
            string query = @"INSERT INTO tbProducts (ProductName, SupplierID, CategoryID, Unit, Price, CostPrice, StockQty, Barcode, Image, ImagePath, Description) 
                             VALUES (@ProductName, @SupplierID, @CategoryID, @Unit, @Price, @CostPrice, @StockQty, @Barcode, @Image, @ImagePath, @Description)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName", (object)product.ProductName ?? DBNull.Value),
                new SqlParameter("@SupplierID", (object)product.SupplierID ?? DBNull.Value),
                new SqlParameter("@CategoryID", (object)product.CategoryID ?? DBNull.Value),
                new SqlParameter("@Unit", (object)product.Unit ?? DBNull.Value),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CostPrice", product.CostPrice),
                new SqlParameter("@StockQty", product.StockQty),
                new SqlParameter("@Barcode", (object)product.Barcode ?? DBNull.Value),
                new SqlParameter("@Image", (object)product.Image ?? DBNull.Value),
                new SqlParameter("@ImagePath", (object)product.ImagePath ?? DBNull.Value),
                new SqlParameter("@Description", (object)product.Description ?? DBNull.Value)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // កែប្រែព័ត៌មានទំនិញ
        public bool Update(Product product)
        {
            string query = @"UPDATE tbProducts 
                             SET ProductName = @ProductName, 
                                 SupplierID = @SupplierID, 
                                 CategoryID = @CategoryID, 
                                 Unit = @Unit, 
                                 Price = @Price, 
                                 CostPrice = @CostPrice, 
                                 StockQty = @StockQty, 
                                 Barcode = @Barcode, 
                                 Image = @Image, 
                                 ImagePath = @ImagePath,
                                 Description = @Description
                             WHERE ProductID = @ProductID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductID", product.ProductID),
                new SqlParameter("@ProductName", (object)product.ProductName ?? DBNull.Value),
                new SqlParameter("@SupplierID", (object)product.SupplierID ?? DBNull.Value),
                new SqlParameter("@CategoryID", (object)product.CategoryID ?? DBNull.Value),
                new SqlParameter("@Unit", (object)product.Unit ?? DBNull.Value),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@CostPrice", product.CostPrice),
                new SqlParameter("@StockQty", product.StockQty),
                new SqlParameter("@Barcode", (object)product.Barcode ?? DBNull.Value),
                new SqlParameter("@Image", (object)product.Image ?? DBNull.Value),
                new SqlParameter("@ImagePath", (object)product.ImagePath ?? DBNull.Value),
                new SqlParameter("@Description", (object)product.Description ?? DBNull.Value)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // លុបទំនិញតាម ProductID
        public bool Delete(int productId)
        {
            string query = "DELETE FROM tbProducts WHERE ProductID = @ProductID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductID", productId)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
