using System;
using System.Data;
using System.Data.SqlClient;

namespace StoreMS.Data
{
    public static class Database
    {
        // កំណត់ Connection String របស់អ្នកទីនេះ
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=StoreManagement;Integrated Security=True;TrustServerCertificate=True;ConnectRetryCount=3;ConnectRetryInterval=10;";

        // មុខងារសម្រាប់បើក Connection
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        // មុខងារសម្រាប់ Execute SELECT queries (ទាញយកទិន្នន័យមកបង្ហាញក្នុង DataTable)
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 60; 
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // មុខងារសម្រាប់ Execute INSERT, UPDATE, DELETE (រក្សាទុក កែប្រែ លុប)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 60; 
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        // មុខងារសម្រាប់ Execute Scalar (ទាញយកតម្លៃតែមួយ ឧទាហរណ៍: COUNT(*), SUM(Total))
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 60; 
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
    }
}