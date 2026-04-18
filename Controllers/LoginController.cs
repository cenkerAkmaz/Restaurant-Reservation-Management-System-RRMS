using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using System;
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

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "SELECT username, role, email, full_name, phone FROM users WHERE (username=@u OR full_name=@u) AND password=@p";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", userOrFullName);
                    cmd.Parameters.AddWithValue("@p", pass);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new User
                            {
                                Username = dr["username"]?.ToString(),
                                Role = dr["role"]?.ToString(),
                                Email = dr["email"]?.ToString(),
                                FullName = dr["full_name"]?.ToString(),
                                Phone = dr["phone"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}