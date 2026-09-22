using System;

namespace StoreMS.Models
{
    public class Supplier : Person
    {
        // Map ទៅកាន់ SupplierID ក្នុង Database
        public int SupplierId
        {
            get => Id;
            set => Id = value;
        }

        // Map ទៅកាន់ SupplierName ក្នុង Database
        public string SupplierName
        {
            get => Name;
            set => Name = value;
        }

        // Properties បន្ថែមស្របតាម SQL Table (tbSuppliers)
        public string ContactName { get; set; } = "";
        public new string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Country { get; set; } = "";

        // Properties របស់អ្នកបន្ថែម
        public string CompanyName { get; set; } = "";

        public override string GetInfo()
        {
            return $"Supplier: {SupplierName}, Contact: {ContactName}, Phone: {Phone}, City: {City}";
        }
    }
}