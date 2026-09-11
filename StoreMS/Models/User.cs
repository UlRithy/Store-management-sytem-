using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Models
{
    public class User
    {
        public string UserId {  get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role {  get; set; }
        public bool IsActive { get; set; }
    }
}
