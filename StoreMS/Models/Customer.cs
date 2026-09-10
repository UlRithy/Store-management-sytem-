using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
    public class Customer:Person
    {
        public int CustomerID
        {
            get => Id;
            set => Id= value;
        }
        public String CustomerName
        {
            get => Name;
            set => Name= value;
        }

        public override string GetInfo()
        {
            return $"Customer :{CustomerName}, Phone: {Phone}";
        }
    }
}
