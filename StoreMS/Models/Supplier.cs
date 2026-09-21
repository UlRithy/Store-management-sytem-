using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreMS.Models
{
    public class Supplier : Person
    {
        public int SupplierId
        {
            get => Id;
            set => Id = value;
        }

        public string SupplierName
        {
            get => Name;
            set => Name = value;
        }

       
        public string CompanyName { get; set; } = "";
        public string ContactPerson { get; set; } = "";

        public override string GetInfo()
        {
            return $"Supplier: {SupplierName}, Company: {CompanyName}, Phone: {Phone}";
        }
    }
}