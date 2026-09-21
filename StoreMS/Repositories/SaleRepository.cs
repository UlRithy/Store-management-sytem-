using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Interfaces;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {
        // ១. ទាញយកវិក្កយបត្រទាំងអស់
        public IEnumerable<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();
            string query = "SELECT SaleId, InvoiceNo, SaleDate, CustomerId, UserId, TotalAmount, PaymentMethod FROM Sales ORDER BY SaleDate DESC";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                sales.Add(new Sale
                {
                    SaleId = Convert.ToInt32(row["SaleId"]),
                    InvoiceNo = row["InvoiceNo"].ToString(),
                    SaleDate = Convert.ToDateTime(row["SaleDate"]),
                    CustomerId = Convert.ToInt32(row["CustomerId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    PaymentMethod = row["PaymentMethod"].ToString()
                });
            }
            return sales;
        }

        // ២. ទាញយកវិក្កយបត្រតាម ID (ព្រមទាំងទាញយក SaleDetails មកជាមួយផង)
        public Sale GetById(int id)
        {
            Sale sale = null;
            string query = "SELECT SaleId, InvoiceNo, SaleDate, CustomerId, UserId, TotalAmount, PaymentMethod FROM Sales WHERE SaleId = @SaleId";
            SqlParameter[] parameters = { new SqlParameter("@SaleId", id) };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                sale = new Sale
                {
                    SaleId = Convert.ToInt32(row["SaleId"]),
                    InvoiceNo = row["InvoiceNo"].ToString(),
                    SaleDate = Convert.ToDateTime(row["SaleDate"]),
                    CustomerId = Convert.ToInt32(row["CustomerId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    PaymentMethod = row["PaymentMethod"].ToString()
                };

                // ទាញយកបញ្ជីទំនិញក្នុងវិក្កយបត្រនេះ
                sale.SaleDetails = GetSaleDetailsBySaleId(sale.SaleId);
            }
            return sale;
        }

        // មុខងារជំនួយសម្រាប់ទាញយក SaleDetails តាម SaleId
        private List<SaleDetail> GetSaleDetailsBySaleId(int saleId)
        {
            List<SaleDetail> details = new List<SaleDetail>();
            string query = "SELECT SaleDetailId, SaleId, ProductId, Price, Quantity FROM SaleDetails WHERE SaleId = @SaleId";
            SqlParameter[] parameters = { new SqlParameter("@SaleId", saleId) };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                details.Add(new SaleDetail
                {
                    SaleDetailId = Convert.ToInt32(row["SaleDetailId"]),
                    SaleId = Convert.ToInt32(row["SaleId"]),
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                });
            }
            return details;
        }

        // ៣. បន្ថែមវិក្កយបត្រថ្មី (Checkout POS) ប្រើប្រាស់ Transaction
        public bool Add(Sale sale)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // ក. បញ្ចូលក្បាលវិក្កយបត្រ (Sales Header) និងទាញយក SaleId ដែលទើបនឹងបង្កើត
                        string insertSaleQuery = @"INSERT INTO Sales (InvoiceNo, SaleDate, CustomerId, UserId, TotalAmount, PaymentMethod) 
                                                 VALUES (@InvoiceNo, @SaleDate, @CustomerId, @UserId, @TotalAmount, @PaymentMethod);
                                                 SELECT SCOPE_IDENTITY();";

                        int saleId;
                        using (SqlCommand cmd = new SqlCommand(insertSaleQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@InvoiceNo", sale.InvoiceNo);
                            cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                            cmd.Parameters.AddWithValue("@CustomerId", sale.CustomerId);
                            cmd.Parameters.AddWithValue("@UserId", sale.UserId);
                            cmd.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                            cmd.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod);

                            saleId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // ខ. วนដកស្រង់បញ្ជីទំនិញ (Sale Details) និងកាត់ស្តុកទំនិញក្នុង Products
                        foreach (var detail in sale.SaleDetails)
                        {
                            // បញ្ចូលចូលតារាង SaleDetails
                            string insertDetailQuery = @"INSERT INTO SaleDetails (SaleId, ProductId, Price, Quantity) 
                                                       VALUES (@SaleId, @ProductId, @Price, @Quantity)";
                            using (SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, transaction))
                            {
                                cmdDetail.Parameters.AddWithValue("@SaleId", saleId);
                                cmdDetail.Parameters.AddWithValue("@ProductId", detail.ProductId);
                                cmdDetail.Parameters.AddWithValue("@Price", detail.Price);
                                cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdDetail.ExecuteNonQuery();
                            }

                            // កាត់បន្ថយស្តុកទំនិញក្នុងតារាង Products
                            string updateStockQuery = "UPDATE Products SET StockQty = StockQty - @Quantity WHERE ProductId = @ProductId";
                            using (SqlCommand cmdStock = new SqlCommand(updateStockQuery, conn, transaction))
                            {
                                cmdStock.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdStock.Parameters.AddWithValue("@ProductId", detail.ProductId);
                                cmdStock.ExecuteNonQuery();
                            }
                        }

                        // ប្រសិនបើគ្មានបញ្ហាអ្វីកើតឡើងទេ រក្សាទុកជាផ្លូវការ (Commit)
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        // ប្រសិនបើមានបញ្ហា ត្រូវបោះបង់ប្រតិបត្តិការទាំងអស់វិញ (Rollback)
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        // ៤. មុខងារ Update (ជាទូទៅវិក្កយបត្រលក់រួចមិនត្រូវបានកែប្រែទេ លើកលែងតែមានតម្រូវការពិសេស)
        public bool Update(Sale entity)
        {
            throw new NotImplementedException("Sales updates are typically restricted.");
        }

        // ៥. មុខងារ Delete (លុបវិក្កយបត្រ - ត្រូវសរសេរកូដសងស្តុកទំនិញវិញបើមានការលុបចោល)
        public bool Delete(int id)
        {
            throw new NotImplementedException("Sales deletions require stock reversion logic.");
        }
    }
}