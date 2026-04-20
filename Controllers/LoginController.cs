using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestoranRezervasyonSistemi.Controllers
{
    public class LoginController
    {
        private readonly DbConnection _db = new DbConnection();

        public User CheckLogin(string userOrFullName, string pass)
        {
            if (string.IsNullOrWhiteSpace(userOrFullName) || string.IsNullOrWhiteSpace(pass))
                return null;

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT id, username, role, email, full_name, phone, IsBanned FROM users WHERE (username=@u OR full_name=@u) AND password=@p";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", userOrFullName.Trim());
                        cmd.Parameters.AddWithValue("@p", pass);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // Ban kontrolü - eğer kullanıcı banlıysa null döndür
                                bool isBanned = Convert.ToBoolean(dr["IsBanned"]);
                                if (isBanned)
                                {
                                    return null;
                                }

                                return new User
                                {
                                    Id = Convert.ToInt32(dr["id"]),
                                    Username = dr["username"]?.ToString()?.Trim(),
                                    Role = dr["role"]?.ToString()?.Trim(),
                                    Email = dr["email"]?.ToString()?.Trim(),
                                    FullName = dr["full_name"]?.ToString()?.Trim(),
                                    Phone = dr["phone"]?.ToString()?.Trim(),
                                    IsBanned = isBanned
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Loglama burada yapılabilir
                throw new Exception("Giriş işlemi sırasında hata oluştu.", ex);
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT id, username, role, email, full_name, phone, IsBanned FROM users";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Username = dr["username"]?.ToString()?.Trim(),
                                Role = dr["role"]?.ToString()?.Trim(),
                                Email = dr["email"]?.ToString()?.Trim(),
                                FullName = dr["full_name"]?.ToString()?.Trim(),
                                Phone = dr["phone"]?.ToString()?.Trim(),
                                IsBanned = Convert.ToBoolean(dr["IsBanned"])
                            });
                        }
                    }
                }
            }
            
            return users;
        }
    }
}