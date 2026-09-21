using System;
using System.Collections.Generic;

namespace StoreMS.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string InvoiceNo { get; set; } = "";
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public int UserId { get; set; } // អ្នកគិតលុយ (Cashier)
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = "Cash"; // Cash, ABA QR, Card, etc.

        // បញ្ជីទំនិញទាំងអស់ដែលបានទិញក្នុងវិក្កយបត្រនេះ
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}