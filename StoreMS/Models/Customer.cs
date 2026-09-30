using System;

namespace StoreMS.Models
{
    public class Customer : Person
    {
       
        public int CustomerID
        {
            get => Id;
            set => Id = value;
        }

        public string CustomerName
        {
            get => Name;
            set => Name = value;
        }

        public string ContactName { get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Country { get; set; } = "";

        // Loyalty Points សម្រាប់ប្រព័ន្ធលក់ដូរ (POS)
        public int LoyaltyPoints { get; set; } = 0;

        // Implementation យក Abstract Method មក Override ពី Person
        public override string GetInfo()
        {
            return $"Customer ID: {CustomerID}, Name: {CustomerName}, Phone: {Phone}, Points: {LoyaltyPoints}";
        }
    }
}