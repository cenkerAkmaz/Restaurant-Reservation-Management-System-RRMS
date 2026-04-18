using System.Collections.Generic;
using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestoranRezervasyonSistemi.Controllers
{
    public class TableController
    {
        private readonly DbConnection _db = new DbConnection();

        public List<Table> GetAllTables()
        {
            var tables = new List<Table>();

            using (var conn = _db.GetConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // NOTE: Some DBs use MasaDurumlari as a view; keep as-is to avoid breaking existing DB.
                const string sql = "SELECT id, table_name, capacity, location, Status, reservation_time FROM MasaDurumlari";

                using (var cmd = new SqlCommand(sql, conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var table = new Table
                        {
                            Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0,
                            TableName = dr["table_name"]?.ToString() ?? "İsimsiz",
                            Capacity = dr["capacity"] != DBNull.Value ? Convert.ToInt32(dr["capacity"]) : 0,
                            Location = dr["location"]?.ToString() ?? "",
                            Status = dr["status"] != DBNull.Value ? dr["status"].ToString().Trim() : "Bos",
                        };

                        if (dr["reservation_time"] != DBNull.Value)
                            table.ReservationTime = (TimeSpan)dr["reservation_time"];

                        tables.Add(table);
                    }
                }
            }

            return tables;
        }

        public bool AddTable(Table t)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string sql = "INSERT INTO tables (table_name, capacity, location, status) VALUES (@name, @cap, @loc, @status)";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", t.TableName);
                        cmd.Parameters.AddWithValue("@cap", t.Capacity);
                        cmd.Parameters.AddWithValue("@loc", t.Location);
                        cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(t.Status) ? "Bos" : t.Status);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }

        public bool DeleteTable(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string sql = "DELETE FROM tables WHERE id = @id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }

        public bool UpdateTable(Table t)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string sql = "UPDATE tables SET table_name=@name, capacity=@cap, location=@loc, status=@status WHERE id=@id";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", t.TableName);
                        cmd.Parameters.AddWithValue("@cap", t.Capacity);
                        cmd.Parameters.AddWithValue("@loc", t.Location);
                        cmd.Parameters.AddWithValue("@status", t.Status);
                        cmd.Parameters.AddWithValue("@id", t.Id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception) { return false; }
        }
    }
}