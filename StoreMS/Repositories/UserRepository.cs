using StoreMS.Data;
using StoreMS.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StoreMS.Repositories
{
    public class UserRepository
    {
        // ១. បន្ថែម User ថ្មី
        public bool Add(User user)
        {
            string query = @"INSERT INTO tbUsers (EmployeeID, Username, Password, Position, Role, FullName, IsActive) 
                             VALUES (@EmployeeID, @Username, @Password, @Position, @Role, @FullName, @IsActive)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", user.EmployeeID.HasValue ? (object)user.EmployeeID.Value : DBNull.Value),
                new SqlParameter("@Username", user.UserName ?? (object)DBNull.Value),
                new SqlParameter("@Password", user.Password ?? (object)DBNull.Value),
                new SqlParameter("@Position", user.Position ?? (object)DBNull.Value),
                new SqlParameter("@Role", user.Role ?? (object)DBNull.Value),
                new SqlParameter("@FullName", user.FullName ?? (object)DBNull.Value),
                new SqlParameter("@IsActive", user.IsActive)
            };

            try
            {
                int rowsAffected = Database.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ២. ស្វែងរក User តាម Username (សម្រាប់យកមក Edit)
        public User GetByUsername(string username)
        {
            User user = null;
            string query = "SELECT * FROM tbUsers WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : (int?)null,
                                    UserName = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Position = reader["Position"]?.ToString(),
                                    Role = reader["Role"]?.ToString(),
                                    FullName = reader["FullName"]?.ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting user by username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;
        }

        // ៣. ធ្វើបច្ចុប្បន្នភាព (Update) ព័ត៌មាន User និង Password
        public bool Update(User user)
        {
            string query = @"UPDATE tbUsers 
                             SET Password = @Password, 
                                 FullName = @FullName, 
                                 Position = @Position, 
                                 Role = @Role, 
                                 IsActive = @IsActive 
                             WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", user.UserName ?? (object)DBNull.Value),
                new SqlParameter("@Password", user.Password ?? (object)DBNull.Value),
                new SqlParameter("@FullName", user.FullName ?? (object)DBNull.Value),
                new SqlParameter("@Position", user.Position ?? (object)DBNull.Value),
                new SqlParameter("@Role", user.Role ?? (object)DBNull.Value),
                new SqlParameter("@IsActive", user.IsActive)
            };

            try
            {
                int rowsAffected = Database.ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ៤. មុខងារសម្រាប់ផ្ទៀងផ្ទាត់ការ Login (Authenticate)
        public User Authenticate(string username, string password)
        {
            User user = null;
            string query = "SELECT * FROM tbUsers WHERE Username = @Username AND Password = @Password AND IsActive = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : (int?)null,
                                    UserName = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Position = reader["Position"]?.ToString(),
                                    Role = reader["Role"]?.ToString(),
                                    FullName = reader["FullName"]?.ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during authentication: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;
        }
    }
}