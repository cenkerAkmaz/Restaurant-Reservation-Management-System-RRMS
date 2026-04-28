using RestoranRezervasyonSistemi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestoranRezervasyonSistemi.Data
{
    public sealed class MenuRepository
    {
        private readonly DbConnection _db = new DbConnection();

        public List<MenuItem> GetAllMenuItems()
        {
            var items = new List<MenuItem>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT Id, Name, Description, Price, ImagePath, Category, IsAvailable, CreatedDate
                                   FROM MenuItems
                                   WHERE IsAvailable = 1
                                   ORDER BY Category, Name";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            items.Add(new MenuItem
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"]?.ToString(),
                                Description = dr["Description"]?.ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                ImagePath = dr["ImagePath"]?.ToString(),
                                Category = dr["Category"]?.ToString(),
                                IsAvailable = Convert.ToBoolean(dr["IsAvailable"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                            });
                        }
                    }
                }
            }

            return items;
        }

        public List<MenuItem> GetAllMenuItemsIncludingUnavailable()
        {
            var items = new List<MenuItem>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT Id, Name, Description, Price, ImagePath, Category, IsAvailable, CreatedDate
                                   FROM MenuItems
                                   ORDER BY Category, Name";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            items.Add(new MenuItem
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"]?.ToString(),
                                Description = dr["Description"]?.ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                ImagePath = dr["ImagePath"]?.ToString(),
                                Category = dr["Category"]?.ToString(),
                                IsAvailable = Convert.ToBoolean(dr["IsAvailable"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                            });
                        }
                    }
                }
            }

            return items;
        }

        public List<MenuItem> GetMenuItemsByCategory(string category)
        {
            var items = new List<MenuItem>();
            
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT Id, Name, Description, Price, ImagePath, Category, IsAvailable, CreatedDate 
                                   FROM MenuItems 
                                   WHERE Category = @category AND IsAvailable = 1
                                   ORDER BY Name";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            items.Add(new MenuItem
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"]?.ToString(),
                                Description = dr["Description"]?.ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                ImagePath = dr["ImagePath"]?.ToString(),
                                Category = dr["Category"]?.ToString(),
                                IsAvailable = Convert.ToBoolean(dr["IsAvailable"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                            });
                        }
                    }
                }
            }
            
            return items;
        }

        public MenuItem GetMenuItemById(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT Id, Name, Description, Price, ImagePath, Category, IsAvailable, CreatedDate 
                                   FROM MenuItems 
                                   WHERE Id = @id";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new MenuItem
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"]?.ToString(),
                                Description = dr["Description"]?.ToString(),
                                Price = Convert.ToDecimal(dr["Price"]),
                                ImagePath = dr["ImagePath"]?.ToString(),
                                Category = dr["Category"]?.ToString(),
                                IsAvailable = Convert.ToBoolean(dr["IsAvailable"]),
                                CreatedDate = Convert.ToDateTime(dr["CreatedDate"])
                            };
                        }
                    }
                }
            }
            
            return null;
        }

        public List<string> GetCategories()
        {
            var categories = new List<string>();
            
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT DISTINCT Category 
                                   FROM MenuItems 
                                   WHERE IsAvailable = 1 
                                   ORDER BY Category";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            categories.Add(dr["Category"]?.ToString());
                        }
                    }
                }
            }
            
            return categories;
        }

        public void AddMenuItem(MenuItem item)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"INSERT INTO MenuItems (Name, Description, Price, ImagePath, Category, IsAvailable, CreatedDate) 
                                   VALUES (@name, @desc, @price, @image, @category, @available, @created)";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.Parameters.AddWithValue("@image", item.ImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@category", item.Category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@available", item.IsAvailable);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMenuItem(MenuItem item)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"UPDATE MenuItems 
                                   SET Name = @name, Description = @desc, Price = @price, 
                                       ImagePath = @image, Category = @category, IsAvailable = @available 
                                   WHERE Id = @id";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.Parameters.AddWithValue("@image", item.ImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@category", item.Category ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@available", item.IsAvailable);
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool DeleteMenuItem(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "DELETE FROM MenuItems WHERE Id = @id";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public void AddReservationMenuItem(ReservationMenuItem rmi)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"INSERT INTO ReservationMenuItems (ReservationId, MenuItemId, Quantity, UnitPrice, TotalPrice) 
                                   VALUES (@resId, @menuId, @qty, @unitPrice, @totalPrice)";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@resId", rmi.ReservationId);
                    cmd.Parameters.AddWithValue("@menuId", rmi.MenuItemId);
                    cmd.Parameters.AddWithValue("@qty", rmi.Quantity);
                    cmd.Parameters.AddWithValue("@unitPrice", rmi.UnitPrice);
                    cmd.Parameters.AddWithValue("@totalPrice", rmi.TotalPrice);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ReservationMenuItem> GetReservationMenuItems(int reservationId)
        {
            var items = new List<ReservationMenuItem>();
            
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT Id, ReservationId, MenuItemId, Quantity, UnitPrice, TotalPrice 
                                   FROM ReservationMenuItems 
                                   WHERE ReservationId = @resId";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@resId", reservationId);
                    
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            items.Add(new ReservationMenuItem
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                ReservationId = Convert.ToInt32(dr["ReservationId"]),
                                MenuItemId = Convert.ToInt32(dr["MenuItemId"]),
                                Quantity = Convert.ToInt32(dr["Quantity"]),
                                UnitPrice = Convert.ToDecimal(dr["UnitPrice"]),
                                TotalPrice = Convert.ToDecimal(dr["TotalPrice"])
                            });
                        }
                    }
                }
            }
            
            return items;
        }

        public decimal GetReservationTotalPrice(int reservationId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = @"SELECT ISNULL(SUM(TotalPrice), 0) 
                                   FROM ReservationMenuItems 
                                   WHERE ReservationId = @resId";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@resId", reservationId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public bool DeleteReservationMenuItems(int reservationId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                const string sql = "DELETE FROM ReservationMenuItems WHERE ReservationId = @resId";
                
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@resId", reservationId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
