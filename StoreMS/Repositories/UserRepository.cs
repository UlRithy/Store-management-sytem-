using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StoreMS.Data;
using StoreMS.Models;

namespace StoreMS.Repositories
{
    public class UserRepository
    {
        // ១. ទាញយកបញ្ជីអ្នកប្រើប្រាស់ទាំងអស់
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            // ប្ដូរឈ្មោះតារាង និងបន្ថែម Column ឱ្យត្រូវជាមួយ Model
            string query = "SELECT UserId, EmployeeID, UserName, FullName, Role, Position, IsActive FROM tbUsers";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    UserName = row["UserName"]?.ToString() ?? "",
                    FullName = row["FullName"]?.ToString() ?? "",
                    Role = row["Role"]?.ToString() ?? "",
                    Position = row["Position"]?.ToString() ?? "",
                    IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"])
                });
            }
            return users;
        }

        // ២. ទាញយកព័ត៌មានអ្នកប្រើប្រាស់តាម UserId
        public User GetById(int userId)
        {
            User user = null;
            string query = "SELECT UserId, EmployeeID, UserName, FullName, Role, Position, IsActive FROM tbUsers WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", userId)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    UserName = row["UserName"]?.ToString() ?? "",
                    FullName = row["FullName"]?.ToString() ?? "",
                    Role = row["Role"]?.ToString() ?? "",
                    Position = row["Position"]?.ToString() ?? "",
                    IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"])
                };
            }
            return user;
        }

        // ៣. បន្ថែមអ្នកប្រើប្រាស់ថ្មី
        public bool Add(User entity)
        {
            string query = "INSERT INTO tbUsers (EmployeeID, UserName, Password, FullName, Role, Position, IsActive) VALUES (@EmployeeID, @UserName, @Password, @FullName, @Role, @Position, @IsActive)";
            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", entity.EmployeeID),
                new SqlParameter("@UserName", entity.UserName),
                new SqlParameter("@Password", entity.Password), // កត់សម្គាល់៖ គួរ Hash password មុនបញ្ចូល
                new SqlParameter("@FullName", entity.FullName),
                new SqlParameter("@Role", entity.Role),
                new SqlParameter("@Position", entity.Position),
                new SqlParameter("@IsActive", entity.IsActive)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៤. កែប្រែព័ត៌មានអ្នកប្រើប្រាស់
        public bool Update(User entity)
        {
            string query = "UPDATE tbUsers SET EmployeeID = @EmployeeID, UserName = @UserName, FullName = @FullName, Role = @Role, Position = @Position, IsActive = @IsActive WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", entity.UserId),
                new SqlParameter("@EmployeeID", entity.EmployeeID),
                new SqlParameter("@UserName", entity.UserName),
                new SqlParameter("@FullName", entity.FullName),
                new SqlParameter("@Role", entity.Role),
                new SqlParameter("@Position", entity.Position),
                new SqlParameter("@IsActive", entity.IsActive)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៥. លុបអ្នកប្រើប្រាស់
        public bool Delete(int userId)
        {
            string query = "DELETE FROM tbUsers WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", userId)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៦. មុខងារពិសេសសម្រាប់ Login (ផ្ទៀងផ្ទាត់គណនី)
        public User Authenticate(string userName, string password)
        {
            User user = null;
            string query = "SELECT UserId, EmployeeID, UserName, FullName, Role, Position, IsActive FROM tbUsers WHERE UserName = @UserName AND Password = @Password AND IsActive = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    UserName = row["UserName"]?.ToString() ?? "",
                    FullName = row["FullName"]?.ToString() ?? "",
                    Role = row["Role"]?.ToString() ?? "",
                    Position = row["Position"]?.ToString() ?? "",
                    IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"])
                };
            }
            return user;
        }
    }
}