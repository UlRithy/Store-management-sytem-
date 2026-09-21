using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; } // តម្លៃលក់ក្នុងពេលធ្វើប្រតិបត្តិការ
        public int Quantity { get; set; }

        // Computed Property សម្រាប់គណនាទឹកប្រាក់សរុបតាមមុខទំនិញនីមួយៗ (Price * Quantity)
        public decimal SubTotal => Price * Quantity;
    }
}
