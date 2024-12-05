using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class StatisticDAL
    {
        private static readonly string _connectionString = "Data Source=IDEAPAD5PRO;Initial Catalog=FinanceManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public static List<DateOnly> GetDateHasData(DateTime startDate, DateTime endDate)
        {
            List<DateOnly > dates = new List<DateOnly>();
            string query = @"SELECT TransactionDate FROM [Transaction] WHERE TransactionDate BETWEEN @StartDate AND @EndDate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateOnly date = DateOnly.FromDateTime(reader.GetDateTime(0));
                            dates.Add(date);
                        }
                    }
                    connection.Close();
                }
            }
            return dates;
        }

        public static List<Tuple<string, double>> GetDataByCatalog(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            List<Tuple<string,double>> result = new List<Tuple<string,double>>();
            string query = @"SELECT TransactionCatalog, SUM(Money)
                 FROM [Transaction]
                 WHERE TransactionMoneyFlow = @MoneyFlow 
                 AND (TransactionDate BETWEEN @StartDate AND @EndDate)
                 GROUP BY TransactionCatalog";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MoneyFlow", moneyFlow);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            string catalog = reader.GetString(0);
                            double sumMoney = (double)reader.GetDecimal(1);
                            result.Add(new Tuple<string, double>(catalog, sumMoney));
                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }

        public static List<Tuple<DateOnly, double>> GetDataByDate(string moneyFlow, DateTime? startDate, DateTime? endDate)
        {
            List<Tuple<DateOnly, double>> result = new List<Tuple<DateOnly, double>>();
            string query = @"SELECT TransactionDate, SUM(Money)
                 FROM [Transaction]
                 WHERE TransactionMoneyFlow = @MoneyFlow 
                 AND (TransactionDate BETWEEN @StartDate AND @EndDate)
                 GROUP BY TransactionDate
                 ORDER BY TransactionDate ASC";
            string queryIfNull = @"SELECT TransactionDate, SUM(Money)
                 FROM [Transaction]
                 WHERE TransactionMoneyFlow = @MoneyFlow 
                 GROUP BY TransactionDate
                 ORDER BY TransactionDate ASC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                if (startDate != null && endDate != null)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MoneyFlow", moneyFlow);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateOnly date = DateOnly.FromDateTime(reader.GetDateTime(0));
                                double sumMoney = (double)reader.GetDecimal(1);
                                result.Add(new Tuple<DateOnly, double>(date, sumMoney));
                            }
                        }
                        connection.Close();
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(queryIfNull, connection))
                    {
                        command.Parameters.AddWithValue("@MoneyFlow", moneyFlow);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateOnly date = DateOnly.FromDateTime(reader.GetDateTime(0));
                                double sumMoney = (double)reader.GetDecimal(1);
                                result.Add(new Tuple<DateOnly, double>(date, sumMoney));
                            }
                        }
                        connection.Close();
                    }
                }
            }
            return result;
        }
    }
}
