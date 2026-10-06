using System;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class SaleRepository
    {
        public bool Checkout(Sale sale)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. INSERT SALE HEADER
                        string insertSaleQuery = @"
                            INSERT INTO tbSales
                                (InvoiceNo, SaleDate, CustomerID, UserID, TotalAmount, PaymentMethod)
                            VALUES
                                (@InvoiceNo, @SaleDate, @CustomerID, @UserID, @TotalAmount, @PaymentMethod);

                            SELECT SCOPE_IDENTITY();";

                        int saleId;

                        using (SqlCommand cmd = new SqlCommand(insertSaleQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@InvoiceNo", sale.InvoiceNo);
                            cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                            cmd.Parameters.AddWithValue("@CustomerID",
                                sale.CustomerId > 0 ? (object)sale.CustomerId : DBNull.Value);
                            cmd.Parameters.AddWithValue("@UserID", sale.UserId);
                            cmd.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod);

                            saleId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. INSERT SALE DETAILS + REDUCE STOCK
                        foreach (var detail in sale.SaleDetails)
                        {
                            // 2.1 Check stock first
                            string stockQuery = @"
                                SELECT StockQty
                                FROM tbProducts WITH (UPDLOCK, ROWLOCK)
                                WHERE ProductID = @ProductID";

                            int currentStock;

                            using (SqlCommand cmdStock = new SqlCommand(stockQuery, conn, transaction))
                            {
                                cmdStock.Parameters.AddWithValue("@ProductID", detail.ProductId);

                                object result = cmdStock.ExecuteScalar();

                                if (result == null)
                                {
                                    throw new Exception("Product ID " + detail.ProductId + " was not found.");
                                }

                                currentStock = Convert.ToInt32(result);
                            }

                            if (currentStock < detail.Quantity)
                            {
                                throw new Exception(
                                    "Not enough stock for Product ID " + detail.ProductId +
                                    ". Available: " + currentStock);
                            }

                            // 2.2 Insert Sale Detail
                            string insertDetailQuery = @"
                                INSERT INTO tbSaleDetails (SaleID, ProductID, Quantity, Price)
                                VALUES (@SaleID, @ProductID, @Quantity, @Price)";

                            using (SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@SaleID", saleId);
                                cmdDetail.Parameters.AddWithValue("@ProductID", detail.ProductId);
                                cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdDetail.Parameters.AddWithValue("@Price", detail.Price);
                                cmdDetail.ExecuteNonQuery();
                            }

                            // 2.3 Reduce Product Stock (tbProducts)
                            string updateStockQuery = @"
                                UPDATE tbProducts
                                SET StockQty = StockQty - @Quantity
                                WHERE ProductID = @ProductID";

                            using (SqlCommand cmdUpdate = new SqlCommand(updateStockQuery, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdUpdate.Parameters.AddWithValue("@ProductID", detail.ProductId);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // 2.4 Reduce tbStock + recompute Status
                            //     (ក្នុង UPDATE ឈ្មោះ column ក្នុង CASE សំដៅតម្លៃចាស់ មុនកាត់)
                            string updateTbStockQuery = @"
                                UPDATE tbStock
                                SET Quantity = Quantity - @Quantity,
                                    LastUpdated = GETDATE(),
                                    Status = CASE
                                        WHEN Quantity - @Quantity <= 0 THEN 'Out of Stock'
                                        WHEN Quantity - @Quantity <= MinStockLevel THEN 'Low Stock'
                                        ELSE 'In Stock' END
                                WHERE ProductId = @ProductID";

                            using (SqlCommand cmdTbStock = new SqlCommand(updateTbStockQuery, conn, transaction))
                            {
                                cmdTbStock.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdTbStock.Parameters.AddWithValue("@ProductID", detail.ProductId);
                                cmdTbStock.ExecuteNonQuery();
                            }
                        }

                        // 3. COMMIT
                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        // 4. ROLLBACK
                        try
                        {
                            transaction.Rollback();
                        }
                        catch
                        {
                            // Ignore rollback error
                        }

                        throw new Exception("Checkout failed: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}