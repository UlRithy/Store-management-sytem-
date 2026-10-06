using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class StockRepository
    {
        // ------------------------------------------------------------
        // SQL ដែលប្រើរួមគ្នា (GetAll និង Search)
        // ------------------------------------------------------------
        private const string SelectStockSql = @"
            SELECT s.StockId,
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

        // ------------------------------------------------------------
        // គណនា Status ស្វ័យប្រវត្តិ ពី Quantity និង MinStockLevel
        // ------------------------------------------------------------
        public static string ComputeStatus(int quantity, int minStockLevel)
        {
            if (quantity <= 0) return "Out of Stock";
            if (quantity <= minStockLevel) return "Low Stock";
            return "In Stock";
        }

        // ------------------------------------------------------------
        // ១. ទាញយកស្តុកទាំងអស់
        // ------------------------------------------------------------
        public List<Stock> GetAllStock()
        {
            DataTable dt = Database.ExecuteQuery(SelectStockSql, null);
            return MapStock(dt);
        }

        // ------------------------------------------------------------
        // ២. ស្វែងរកតាម ProductName ឬ Status
        // ------------------------------------------------------------
        public List<Stock> SearchStock(string keyword)
        {
            string query = SelectStockSql +
                           " WHERE p.ProductName LIKE @Keyword OR s.Status LIKE @Keyword";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            return MapStock(dt);
        }

        // ------------------------------------------------------------
        // ៣. បញ្ចូលស្តុក + បូក StockQty ក្នុង tbProducts (Transaction)
        //    ចំណាំ៖ parameter "status" ត្រូវបានរក្សាទុកដើម្បីឱ្យ Form ចាស់
        //    ដំណើរការបាន ប៉ុន្តែ Status ត្រូវបានគណនាស្វ័យប្រវត្តិជំនួស។
        // ------------------------------------------------------------
        public bool InsertStock(int productId, int quantity, int minStockLevel, string status)
        {
            string finalStatus = ComputeStatus(quantity, minStockLevel);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        Exec(conn, tx,
                            @"INSERT INTO tbStock (ProductId, Quantity, MinStockLevel, Status, LastUpdated)
                              VALUES (@ProductId, @Quantity, @MinStockLevel, @Status, GETDATE())",
                            new SqlParameter("@ProductId", productId),
                            new SqlParameter("@Quantity", quantity),
                            new SqlParameter("@MinStockLevel", minStockLevel),
                            new SqlParameter("@Status", finalStatus));

                        Exec(conn, tx,
                            "UPDATE tbProducts SET StockQty = StockQty + @Quantity WHERE ProductID = @ProductId",
                            new SqlParameter("@ProductId", productId),
                            new SqlParameter("@Quantity", quantity));

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ------------------------------------------------------------
        // ៤. កែប្រែស្តុក
        //    - អានតម្លៃចាស់ក្នុង Transaction ដើម្បីជៀសវាងទិន្នន័យលែងទាន់សម័យ
        //    - បើប្តូរ Product: ដកពី Product ចាស់ ហើយបូកទៅ Product ថ្មី
        // ------------------------------------------------------------
        public bool UpdateStock(int stockId, int productId, int newQuantity, int minStockLevel, string status)
        {
            string finalStatus = ComputeStatus(newQuantity, minStockLevel);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int oldProductId;
                        int oldQuantity;

                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT ProductId, Quantity FROM tbStock WITH (UPDLOCK, ROWLOCK) WHERE StockId = @StockId",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@StockId", stockId);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new Exception("Stock record not found.");

                                oldProductId = r.GetInt32(0);
                                oldQuantity = r.GetInt32(1);
                            }
                        }

                        Exec(conn, tx,
                            @"UPDATE tbStock
                              SET ProductId = @ProductId,
                                  Quantity = @Quantity,
                                  MinStockLevel = @MinStockLevel,
                                  Status = @Status,
                                  LastUpdated = GETDATE()
                              WHERE StockId = @StockId",
                            new SqlParameter("@StockId", stockId),
                            new SqlParameter("@ProductId", productId),
                            new SqlParameter("@Quantity", newQuantity),
                            new SqlParameter("@MinStockLevel", minStockLevel),
                            new SqlParameter("@Status", finalStatus));

                        if (oldProductId == productId)
                        {
                            // Product ដដែល: បូក/ដកតែផលសង
                            Exec(conn, tx,
                                "UPDATE tbProducts SET StockQty = StockQty + @Diff WHERE ProductID = @ProductId",
                                new SqlParameter("@ProductId", productId),
                                new SqlParameter("@Diff", newQuantity - oldQuantity));
                        }
                        else
                        {
                            // ប្តូរ Product: ដកពីចាស់ បូកទៅថ្មី
                            Exec(conn, tx,
                                "UPDATE tbProducts SET StockQty = StockQty - @Qty WHERE ProductID = @ProductId",
                                new SqlParameter("@ProductId", oldProductId),
                                new SqlParameter("@Qty", oldQuantity));

                            Exec(conn, tx,
                                "UPDATE tbProducts SET StockQty = StockQty + @Qty WHERE ProductID = @ProductId",
                                new SqlParameter("@ProductId", productId),
                                new SqlParameter("@Qty", newQuantity));
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ------------------------------------------------------------
        // ៥. លុបស្តុក + ដក Quantity ចេញពី tbProducts វិញ
        // ------------------------------------------------------------
        public bool DeleteStock(int stockId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int productId;
                        int quantity;

                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT ProductId, Quantity FROM tbStock WITH (UPDLOCK, ROWLOCK) WHERE StockId = @StockId",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@StockId", stockId);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                if (!r.Read())
                                {
                                    tx.Rollback();
                                    return false; // រកមិនឃើញកំណត់ត្រា
                                }

                                productId = r.GetInt32(0);
                                quantity = r.GetInt32(1);
                            }
                        }

                        Exec(conn, tx,
                            "DELETE FROM tbStock WHERE StockId = @StockId",
                            new SqlParameter("@StockId", stockId));

                        Exec(conn, tx,
                            "UPDATE tbProducts SET StockQty = StockQty - @Quantity WHERE ProductID = @ProductId",
                            new SqlParameter("@ProductId", productId),
                            new SqlParameter("@Quantity", quantity));

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ------------------------------------------------------------
        // ៦. បញ្ជី Product សម្រាប់ ComboBox (Stock_AddEdit_Form)
        // ------------------------------------------------------------
        public DataTable GetProductsForComboBox()
        {
            return Database.ExecuteQuery("SELECT ProductId, ProductName FROM tbProducts", null);
        }

        // ============================================================
        // Helpers
        // ============================================================
        private static List<Stock> MapStock(DataTable dt)
        {
            List<Stock> list = new List<Stock>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Stock
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
            return list;
        }

        private static void Exec(SqlConnection conn, SqlTransaction tx, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }
    }
}