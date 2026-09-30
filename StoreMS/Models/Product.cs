using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public int StockQty { get; set; }
        public string Barcode { get; set; }
        public string Image { get; set; }
        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
