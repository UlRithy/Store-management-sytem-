using System;

namespace StoreMS.Models
{
    public class Employee : Person
    {
        // ប្រើប្រាស់ EmployeeID ដែល Map ទៅកាន់ Id របស់ Person
        public int EmployeeID
        {
            get => Id;
            set => Id = value;
        }

        // ប្រើប្រាស់ FullName ដែល Map ទៅកាន់ Name របស់ Person
        public string FullName
        {
            get => Name;
            set => Name = value;
        }

        public string Gender { get; set; } = "";
        public string Position { get; set; } = "";
        public decimal Salary { get; set; } = 0;
        public DateTime? HireDate { get; set; }
        public string Username { get; set; } = "";

        // Implementation យក Abstract Method មកសរសេរកូដបំពេញបន្ថែម (Override)
        public override string GetInfo()
        {
            return $"Employee ID: {EmployeeID}, Full Name: {FullName}, Position: {Position}, Salary: {Salary:C}";
        }
    }
}