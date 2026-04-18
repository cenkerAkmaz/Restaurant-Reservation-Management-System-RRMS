using System.Configuration;
using System.Data.SqlClient;

namespace RestoranRezervasyonSistemi.Data
{
    public sealed class DbConnection
    {
        private const string ConnectionStringName = "MyDbConn";

        public SqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(cs))
            {
                // Backward-compat fallback (project previously hardcoded this value in multiple forms).
                cs = @"Data Source=127.0.0.1,1433;Initial Catalog=rrms_db;Integrated Security=True;TrustServerCertificate=True";
            }

            return new SqlConnection(cs);
        }
    }
}