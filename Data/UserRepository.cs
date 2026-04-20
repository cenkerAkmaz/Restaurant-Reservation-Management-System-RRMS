using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RestoranRezervasyonSistemi.Models;

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
            InsertUser(username, password, email, username, null);
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

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT id, username, email, full_name, phone, role, IsBanned FROM users ORDER BY full_name";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Username = dr["username"]?.ToString(),
                                Email = dr["email"]?.ToString(),
                                FullName = dr["full_name"]?.ToString(),
                                Phone = dr["phone"]?.ToString(),
                                Role = dr["role"]?.ToString(),
                                IsBanned = Convert.ToBoolean(dr["IsBanned"])
                            });
                        }
                    }
                }
            }
            
            return users;
        }

        public bool BanUser(int userId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "UPDATE users SET IsBanned = 1 WHERE id = @userId";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
        }

        public bool UnbanUser(int userId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "UPDATE users SET IsBanned = 0 WHERE id = @userId";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
        }
    }
}

