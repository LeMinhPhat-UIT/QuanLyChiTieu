using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class WalletDAL
    {
        private List<Wallet> _wallets = new List<Wallet>();
        private static readonly string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=IT008_Project;Integrated Security=True;Trust Server Certificate=True";
        public static void AddWallet(Wallet wallet)
        {
            string query = @"
            INSERT INTO Wallet (WalletName, WalletType, Money, UpdateDate)
            VALUES (@WalletName, @WalletType, @Money, @UpdateDate);
        ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WalletName", wallet.WalletName);
                    command.Parameters.AddWithValue("@WalletType", wallet.WalletType);
                    command.Parameters.AddWithValue("@Money", wallet.Money);
                    command.Parameters.AddWithValue("@UpdateDate", wallet.UpdateDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static Wallet GetWalletByID(int walletID)
        {
            Wallet wallet = null;

            string query = @"
                SELECT ID, WalletName, WalletType, Money, UpdateDate
                FROM Wallet
                WHERE ID = @WalletID;
            ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WalletID", walletID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            wallet = new Wallet
                            {
                                ID = reader.GetInt32(0), 
                                WalletName = reader.GetString(1), 
                                WalletType = reader.GetString(2), 
                                Money = (double)reader.GetDecimal(3), 
                                UpdateDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                            };
                        }
                    }
                }
            }

            return wallet;
        }

        public static void DeleteWallet(int id)
        {
            string query = @"
                DELETE FROM Wallet 
                WHERE ID = @WalletID;
            ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WalletID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateWallet(Wallet wallet)
        {

            string query = @"
                UPDATE Wallet
                SET 
                    WalletName = @WalletName,
                    WalletType = @WalletType,
                    Money = @Money,
                    UpdateDate = @UpdateDate
                WHERE ID = @ID;
            ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", wallet.ID);
                    command.Parameters.AddWithValue("@WalletName", wallet.WalletName);
                    command.Parameters.AddWithValue("@WalletType", wallet.WalletType);
                    command.Parameters.AddWithValue("@Money", wallet.Money);
                    command.Parameters.AddWithValue("@UpdateDate", wallet.UpdateDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Wallet> GetAllWallets()
        {
            List<Wallet> wallets = new List<Wallet>();

            string query = @"
                SELECT ID, WalletName, WalletType, Money, UpdateDate
                FROM Wallet;
            ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wallet wallet = new Wallet
                            {
                                ID = reader.GetInt32(0),
                                WalletName = reader.GetString(1),
                                WalletType = reader.GetString(2),
                                Money = (double)reader.GetDecimal(3),
                                UpdateDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                            };
                            wallets.Add(wallet);
                        }
                    }
                }
            }

            return wallets;
        }

    }
}
