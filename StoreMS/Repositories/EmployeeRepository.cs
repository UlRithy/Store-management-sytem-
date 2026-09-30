using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class EmployeeRepository
    {
        // 1. ទាញយកទិន្នន័យបុគ្គលិកទាំងអស់ (GetAll)
        public IEnumerable<Employee> GetAll()
        {
            var employees = new List<Employee>();
            string query = "SELECT EmployeeID, FullName, Gender, Phone, Email, Address, Position, Salary, HireDate, Username FROM tbEmployees";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var employee = new Employee
                {
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    FullName = row["FullName"].ToString(),
                    Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : "",
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    Position = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                    Salary = row["Salary"] != DBNull.Value ? Convert.ToDecimal(row["Salary"]) : 0,
                    HireDate = row["HireDate"] != DBNull.Value ? Convert.ToDateTime(row["HireDate"]) : (DateTime?)null,
                    Username = row["Username"] != DBNull.Value ? row["Username"].ToString() : ""
                };
                employees.Add(employee);
            }
            return employees;
        }

        // 2. បន្ថែមបុគ្គលិកថ្មី (Add)
        public bool Add(Employee employee)
        {
            string query = @"INSERT INTO tbEmployees (FullName, Gender, Phone, Email, Address, Position, Salary, HireDate, Username) 
                             VALUES (@FullName, @Gender, @Phone, @Email, @Address, @Position, @Salary, @HireDate, @Username)";

            SqlParameter[] parameters = {
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Gender", (object)employee.Gender ?? DBNull.Value),
                new SqlParameter("@Phone", (object)employee.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)employee.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)employee.Address ?? DBNull.Value),
                new SqlParameter("@Position", (object)employee.Position ?? DBNull.Value),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", (object)employee.HireDate ?? DBNull.Value),
                new SqlParameter("@Username", (object)employee.Username ?? DBNull.Value)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // 3. កែប្រែទិន្នន័យបុគ្គលិក (Update)
        public bool Update(Employee employee)
        {
            string query = @"UPDATE tbEmployees 
                             SET FullName = @FullName, 
                                 Gender = @Gender, 
                                 Phone = @Phone, 
                                 Email = @Email, 
                                 Address = @Address, 
                                 Position = @Position, 
                                 Salary = @Salary, 
                                 HireDate = @HireDate, 
                                 Username = @Username 
                             WHERE EmployeeID = @EmployeeID";

            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Gender", (object)employee.Gender ?? DBNull.Value),
                new SqlParameter("@Phone", (object)employee.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)employee.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)employee.Address ?? DBNull.Value),
                new SqlParameter("@Position", (object)employee.Position ?? DBNull.Value),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@HireDate", (object)employee.HireDate ?? DBNull.Value),
                new SqlParameter("@Username", (object)employee.Username ?? DBNull.Value)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }

        // 4. លុបបុគ្គលិក (Delete)
        public bool Delete(int employeeId)
        {
            string query = "DELETE FROM tbEmployees WHERE EmployeeID = @EmployeeID";
            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", employeeId)
            };

            int rowsAffected = Database.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}