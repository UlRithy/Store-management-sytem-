using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
    public class Employee : Person
    {
        public int EmployeeId
        {
            get => Id;
            set => Id = value;
        }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";

        public override string GetInfo()
        {
            return $"Employee: {Name}, Role: {Role}";
        }
       

    }
}
