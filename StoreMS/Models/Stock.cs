using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
 
     public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }

        // Properties បន្ថែមសម្រាប់ការ Join ទិន្នន័យមកបង្ហាញ
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        public int Quantity { get; set; }
        public int MinStockLevel { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
