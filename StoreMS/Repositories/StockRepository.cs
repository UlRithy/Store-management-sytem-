using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Models;
using StoreMS.Data;

namespace StoreMS.Repositories
{
    public class StockRepository
    {
        // ១. ទាញយកទិន្នន័យស្តុកទាំងអស់ជា List<Stock>
        public List<Stock> GetAllStock()
        {
            List<Stock> stockList = new List<Stock>();
            string query = @"SELECT s.StockId, 
                                    p.ProductId,
                                    p.ProductName, 
                                    ISNULL(c.CategoryName, 'N/A') AS CategoryName, 
                                    s.Quantity, 
                                    s.MinStockLevel, 
                                    s.Status, 
                                    s.LastUpdated 
                             FROM tbStock s
                             INNER JOIN tbProducts p ON s.ProductId = p.ProductId
                             LEFT JOIN tbCategory c ON p.CategoryId = c.CategoryId";

            DataTable dt = Database.ExecuteQuery(query, null);
            foreach (DataRow row in dt.Rows)
            {
                stockList.Add(new Stock
                {
                    StockId = Convert.ToInt32(row["StockId"]),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    MinStockLevel = Convert.ToInt32(row["MinStockLevel"]),
                    Status = row["Status"].ToString(),
                    LastUpdated = Convert.ToDateTime(row["LastUpdated"])
                });
            }

            return stockList;
        }

        // ២. ស្វែងរកស្តុកតាមពាក្យគន្លឹះ (ProductName ឬ Status) ជា List<Stock>
        public List<Stock> SearchStock(string keyword)
        {
            List<Stock> stockList = new List<Stock>();
            string query = @"SELECT s.StockId, 
                                    p.ProductId,
                                    p.ProductName, 
                                    ISNULL(c.CategoryName, 'N/A') AS CategoryName, 
                                    s.Quantity, 
                                    s.MinStockLevel, 
                                    s.Status, 
                                    s.LastUpdated 
                             FROM tbStock s
                             INNER JOIN tbProducts p ON s.ProductId = p.ProductId
                             LEFT JOIN tbCategory c ON p.CategoryId = c.CategoryId
                             WHERE p.ProductName LIKE @Keyword OR s.Status LIKE @Keyword";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                stockList.Add(new Stock
                {
                    StockId = Convert.ToInt32(row["StockId"]),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    MinStockLevel = Convert.ToInt32(row["MinStockLevel"]),
                    Status = row["Status"].ToString(),
                    LastUpdated = Convert.ToDateTime(row["LastUpdated"])
                });
            }

            return stockList;
        }

        // ៣. បញ្ចូលស្តុកថ្មី (Insert) + បូកបន្ថែម StockQty ក្នុង tbProducts ដោយស្វ័យប្រវត្តិ
        public bool InsertStock(int productId, int quantity, int minStockLevel, string status)
        {
            // បើក Connection ផ្ទាល់ដើម្បីប្រើ Transaction ធានាថាការ Insert និង Update ត្រូវជោគជ័យទាំងពីរ
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StoreManagement;Integrated Security=True"; // ជំនួសតាម Connection String របស់អ្នក

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ៣.១ បញ្ចូលចូល tbStock
                        string insertQuery = @"INSERT INTO tbStock (ProductId, Quantity, MinStockLevel, Status, LastUpdated) 
                                               VALUES (@ProductId, @Quantity, @MinStockLevel, @Status, GETDATE())";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@MinStockLevel", minStockLevel);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.ExecuteNonQuery();
                        }

                        // ៣.២ អាប់ដេតបូកបន្ថែម StockQty ក្នុង tbProducts ភ្លាមៗ
                        string updateProductQuery = "UPDATE tbProducts SET StockQty = StockQty + @Quantity WHERE ProductID = @ProductId";
                        using (SqlCommand cmd = new SqlCommand(updateProductQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ៤. កែប្រែស្តុក (Update) - (គិតគូរពីការប្តូរចំនួនស្តុកចាស់និងថ្មី)
        public bool UpdateStock(int stockId, int productId, int newQuantity, int minStockLevel, string status)
        {
            // ទាញយក Quantity ចាស់មកផ្ទៀងផ្ទាត់សិន
            int oldQuantity = 0;
            string getOldQtyQuery = "SELECT Quantity FROM tbStock WHERE StockId = @StockId";
            SqlParameter[] pOld = { new SqlParameter("@StockId", stockId) };
            DataTable dtOld = Database.ExecuteQuery(getOldQtyQuery, pOld);
            if (dtOld.Rows.Count > 0)
            {
                oldQuantity = Convert.ToInt32(dtOld.Rows[0]["Quantity"]);
            }

            int diffQuantity = newQuantity - oldQuantity; // ចំនួនដែលត្រូវបន្ថែម ឬដកបន្ថែមលើ Product

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StoreManagement;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ៤.១ អាប់ដេត tbStock
                        string updateStockQuery = @"UPDATE tbStock 
                                                 SET ProductId = @ProductId, 
                                                     Quantity = @Quantity, 
                                                     MinStockLevel = @MinStockLevel, 
                                                     Status = @Status, 
                                                     LastUpdated = GETDATE() 
                                                 WHERE StockId = @StockId";
                        using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@StockId", stockId);
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                            cmd.Parameters.AddWithValue("@MinStockLevel", minStockLevel);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.ExecuteNonQuery();
                        }

                        // ៤.២ អាប់ដេត StockQty ក្នុង tbProducts តាមរយៈផលសង (Diff)
                        string updateProductQuery = "UPDATE tbProducts SET StockQty = StockQty + @Diff WHERE ProductID = @ProductId";
                        using (SqlCommand cmd = new SqlCommand(updateProductQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Diff", diffQuantity);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ៥. លុបស្តុក (Delete) - ដកចំនួនស្តុកចេញពី tbProducts វិញពេលលុបចោល
        public bool DeleteStock(int stockId)
        {
            // យក ProductId និង Quantity មុននឹងលុប
            int productId = 0;
            int quantity = 0;
            string getInfoQuery = "SELECT ProductId, Quantity FROM tbStock WHERE StockId = @StockId";
            SqlParameter[] pInfo = { new SqlParameter("@StockId", stockId) };
            DataTable dtInfo = Database.ExecuteQuery(getInfoQuery, pInfo);
            if (dtInfo.Rows.Count > 0)
            {
                productId = Convert.ToInt32(dtInfo.Rows[0]["ProductId"]);
                quantity = Convert.ToInt32(dtInfo.Rows[0]["Quantity"]);
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StoreManagement;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ៥.១ លុបចេញពី tbStock
                        string deleteQuery = "DELETE FROM tbStock WHERE StockId = @StockId";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@StockId", stockId);
                            cmd.ExecuteNonQuery();
                        }

                        // ៥.២ ដក Quantity ចេញពី StockQty ក្នុង tbProducts វិញ
                        string updateProductQuery = "UPDATE tbProducts SET StockQty = StockQty - @Quantity WHERE ProductID = @ProductId";
                        using (SqlCommand cmd = new SqlCommand(updateProductQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ៦. ទាញយកបញ្ជី Product សម្រាប់ដាក់ចូលក្នុង ComboBox (របស់ Stock_AddEdit_Form)
        public DataTable GetProductsForComboBox()
        {
            string query = "SELECT ProductId, ProductName FROM tbProducts";
            return Database.ExecuteQuery(query, null);
        }
    }
}