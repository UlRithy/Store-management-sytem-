using System;
using System.Collections.Generic;

namespace StoreMS.Models
{
    public class Sale
    {
        // tbSales.SaleID
        public int SaleId { get; set; }

        // tbSales.InvoiceNo
        public string InvoiceNo { get; set; }

        // tbSales.SaleDate
        public DateTime SaleDate { get; set; }

        // tbSales.CustomerID
        public int CustomerId { get; set; }

        // ប្រើសម្រាប់បង្ហាញឈ្មោះ Customer ក្នុង POS
        // មិនមែន Column ផ្ទាល់ក្នុង tbSales
        public string CustomerName { get; set; }

        // tbSales.UserID
        // អ្នកគិតលុយ (Cashier)
        public int UserId { get; set; }

        // tbSales.TotalAmount
        public decimal TotalAmount { get; set; }

        // tbSales.PaymentMethod
        // Cash, ABA QR, Card...
        public string PaymentMethod { get; set; }

        // ទំនិញក្នុង Invoice
        public List<SaleDetail> SaleDetails { get; set; }

        public Sale()
        {
            InvoiceNo = "";
            SaleDate = DateTime.Now;
            CustomerName = "";
            PaymentMethod = "Cash";
            SaleDetails = new List<SaleDetail>();
        }
    }
}