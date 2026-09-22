using System.Drawing;

namespace StoreMS.Models
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        // សម្រាប់បង្ហាញក្នុង Cart
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // សម្រាប់បង្ហាញរូបភាពក្នុង Cart
        public Image ProductImage { get; set; }

        // សរុប = Price × Quantity
        public decimal SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}