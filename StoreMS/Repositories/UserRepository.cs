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
            string query = "SELECT UserId, UserName, FullName, Role, IsActive FROM Users";

            DataTable dt = Database.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserId = row["UserId"].ToString(),
                    UserName = row["UserName"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Role = row["Role"].ToString(),
                    IsActive = Convert.ToBoolean(row["IsActive"])
                });
            }
            return users;
        }

        // ២. ទាញយកព័ត៌មានអ្នកប្រើប្រាស់តាម UserId
        public User GetById(string userId)
        {
            User user = null;
            string query = "SELECT UserId, UserName, FullName, Role, IsActive FROM Users WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", userId)
            };

            DataTable dt = Database.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                user = new User
                {
                    UserId = row["UserId"].ToString(),
                    UserName = row["UserName"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Role = row["Role"].ToString(),
                    IsActive = Convert.ToBoolean(row["IsActive"])
                };
            }
            return user;
        }

        // ៣. បន្ថែមអ្នកប្រើប្រាស់ថ្មី
        public bool Add(User entity)
        {
            string query = "INSERT INTO Users (UserId, UserName, FullName, Role, IsActive) VALUES (@UserId, @UserName, @FullName, @Role, @IsActive)";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", entity.UserId),
                new SqlParameter("@UserName", entity.UserName),
                new SqlParameter("@FullName", entity.FullName),
                new SqlParameter("@Role", entity.Role),
                new SqlParameter("@IsActive", entity.IsActive)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៤. កែប្រែព័ត៌មានអ្នកប្រើប្រាស់
        public bool Update(User entity)
        {
            string query = "UPDATE Users SET UserName = @UserName, FullName = @FullName, Role = @Role, IsActive = @IsActive WHERE UserId = @UserId";
            SqlParameter[] parameters = {
                new SqlParameter("@UserId", entity.UserId),
                new SqlParameter("@UserName", entity.UserName),
                new SqlParameter("@FullName", entity.FullName),
                new SqlParameter("@Role", entity.Role),
                new SqlParameter("@IsActive", entity.IsActive)
            };

            int rows = Database.ExecuteNonQuery(query, parameters);
            return rows > 0;
        }

        // ៥. លុបអ្នកប្រើប្រាស់
        public bool Delete(string userId)
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";
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
            //បញ្ជាក់៖ ក្នុងប្រព័ន្ធពិត អ្នកគួរតែប្រើប្រាស់ Password Hashing (SHA256 ឬ BCrypt) ជំនួសការឆែកអត្ថបទផ្ទាល់
            string query = "SELECT UserId, UserName, FullName, Role, IsActive FROM Users WHERE UserName = @UserName AND Password = @Password AND IsActive = 1";
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
                    UserId = row["UserId"].ToString(),
                    UserName = row["UserName"].ToString(),
                    FullName = row["FullName"].ToString(),
                    Role = row["Role"].ToString(),
                    IsActive = Convert.ToBoolean(row["IsActive"])
                };
            }
            return user;
        }
    }
}