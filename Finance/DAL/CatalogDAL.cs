using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public class CatalogDAL
    {
        private static readonly string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=IT008_Project;Integrated Security=True;Trust Server Certificate=True";

        public static List<Catalog> GetAllCatalog()
        {
            List<Catalog> _catalogs = new List<Catalog>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM [Catalog]";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Catalog catalog = new Catalog()
                        {
                            CatalogMoneyFlow = reader.GetString(0),
                            CatalogName = reader.GetString(1),
                        };
                        _catalogs.Add(catalog);
                    }
                }
                conn.Close();
            }
            return _catalogs;
        }
    }
}
