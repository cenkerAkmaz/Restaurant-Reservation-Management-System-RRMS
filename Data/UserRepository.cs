using System;
using System.Data.SqlClient;

namespace RestoranRezervasyonSistemi.Data
{
    public sealed class UserRepository
    {
        private readonly DbConnection _db = new DbConnection();

        public bool EmailExists(string email)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT COUNT(1) FROM users WHERE email=@mail";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mail", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public void UpdateVerificationCode(string email, string code)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "UPDATE users SET verification_code=@code WHERE email=@mail";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", (object)code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertUser(string username, string password, string email)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "INSERT INTO users (username, password, email, full_name, phone) VALUES (@user, @pass, @mail, @fullName, @phone)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@mail", email);
                    // If full name isn't collected explicitly, default to username to keep UI working.
                    cmd.Parameters.AddWithValue("@fullName", username);
                    cmd.Parameters.AddWithValue("@phone", DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertUser(string username, string password, string email, string fullName, string phone)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "INSERT INTO users (username, password, email, full_name, phone) VALUES (@user, @pass, @mail, @fullName, @phone)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@fullName", string.IsNullOrWhiteSpace(fullName) ? username : fullName);
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePasswordByEmail(string email, string newPassword)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "UPDATE users SET password=@newpass WHERE email=@mail";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@newpass", newPassword);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

