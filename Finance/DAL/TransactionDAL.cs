using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public static class TransactionDAL
    {
        private static readonly string connectionString = "Data Source=AAAAA;Initial Catalog=IT008_Project;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public static int CreateTransaction(string transactionName, decimal money, string moneyFlow, string catalog, string walletID, DateTime date)
        {
            int transactionId;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO [Transaction] 
                                 (TransactionName, Money, TransactionMoneyFlow, TransactionCatalog, WalletID, TransactionDate)
                                 OUTPUT INSERTED.ID
                                 VALUES (@TransactionName, @Money, @MoneyFlow, @Catalog, @WalletID, @TransactionDate)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TransactionName", transactionName);
                cmd.Parameters.AddWithValue("@Money", money);
                cmd.Parameters.AddWithValue("@MoneyFlow", moneyFlow);
                cmd.Parameters.AddWithValue("@Catalog", catalog ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@WalletID", walletID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TransactionDate", date);

                conn.Open();
                transactionId = (int)cmd.ExecuteScalar();
            }

            return transactionId;
        }

        public static void AddTransaction(int transactionID, int walletID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //lay thong tin transaction
                string transactionQuery = @"SELECT Money, TransactionMoneyFlow FROM [Transaction] WHERE ID = @TransactionID";
                SqlCommand transactionCmd = new SqlCommand(transactionQuery, conn);
                transactionCmd.Parameters.AddWithValue("@TransactionID", transactionID);

                SqlDataReader transactionReader = transactionCmd.ExecuteReader();
                if (!transactionReader.Read())
                {
                    throw new Exception("Giao dịch không tồn tại.");
                }

                double transactionMoney = (double)(decimal)transactionReader["Money"];
                string transactionMoneyFlow = transactionReader["TransactionMoneyFlow"].ToString();
                transactionReader.Close();

                // lay thong wallet
                string walletQuery = @"SELECT Money FROM [Wallet] WHERE ID = @WalletID";
                SqlCommand walletCmd = new SqlCommand(walletQuery, conn);
                walletCmd.Parameters.AddWithValue("@WalletID", walletID);

                SqlDataReader walletReader = walletCmd.ExecuteReader();
                if (!walletReader.Read())
                {
                    throw new Exception("Ví tiền không tồn tại.");
                }

                double walletMoney = (double)(decimal)walletReader["Money"];
                walletReader.Close();

                // kiem tra so du neu la chi tieu
                if (transactionMoneyFlow == "Chi tiêu" && walletMoney < transactionMoney)
                {
                    throw new Exception("Số dư ví không đủ để thực hiện giao dịch.");
                }

                // cap nhat so tien
                string updateWalletQuery = @"UPDATE Wallet
                                     SET Wallet.Money = Wallet.Money + 
                                        (CASE 
                                           WHEN @MoneyFlow = 'Chi tiêu' THEN -@TransactionMoney
                                           ELSE @TransactionMoney
                                        END),
                                         UpdateDate = GETDATE()
                                     WHERE ID = @WalletID";

                SqlCommand updateCmd = new SqlCommand(updateWalletQuery, conn);
                updateCmd.Parameters.AddWithValue("@MoneyFlow", transactionMoneyFlow);
                updateCmd.Parameters.AddWithValue("@TransactionMoney", transactionMoney);
                updateCmd.Parameters.AddWithValue("@WalletID", walletID);
                updateCmd.ExecuteNonQuery();
            }
        }

        public static void DeleteTransaction(List<int> transactionIDs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // truy van thong tin transaction
                string selectQuery = @"SELECT t.ID AS TransactionID, 
                                      t.Money, 
                                      t.TransactionMoneyFlow, 
                                      CAST(t.WalletID AS INT) AS WalletID
                               FROM [Transaction] t
                               WHERE t.ID IN (" + string.Join(",", transactionIDs) + ")";

                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectCmd.ExecuteReader();

                var walletAdjustments = new Dictionary<int, double>(); // WalletID => AdjustmentAmount

                while (reader.Read())
                {
                    int walletID = reader.GetInt32(reader.GetOrdinal("WalletID"));
                    decimal transactionMoneyTemp = reader.GetDecimal(reader.GetOrdinal("Money"));
                    double transactionMoney = (double)transactionMoneyTemp;
                    string moneyFlow = reader.GetString(reader.GetOrdinal("TransactionMoneyFlow"));

                    // xac dinh so tien can dieu chinh
                    double adjustment = moneyFlow == "Chi tiêu" ? transactionMoney : -transactionMoney;

                    // dieu chinh cho tung wallet
                    if (walletAdjustments.ContainsKey(walletID))
                    {
                        walletAdjustments[walletID] += adjustment;
                    }
                    else
                    {
                        walletAdjustments[walletID] = adjustment;
                    }
                }
                reader.Close();

                // cap nhat so du
                foreach (var adjustment in walletAdjustments)
                {
                    string updateWalletQuery = @"UPDATE Wallet
                                         SET Wallet.Money = Wallet.Money + @Adjustment,
                                             Wallet.UpdateDate = GETDATE()
                                         WHERE Wallet.ID = @WalletID";

                    SqlCommand updateWalletCmd = new SqlCommand(updateWalletQuery, conn);
                    updateWalletCmd.Parameters.AddWithValue("@Adjustment", adjustment.Value);
                    updateWalletCmd.Parameters.AddWithValue("@WalletID", adjustment.Key);
                    updateWalletCmd.ExecuteNonQuery();
                }

                // xoa transaction
                string deleteQuery = @"DELETE FROM [Transaction] WHERE ID IN (" + string.Join(",", transactionIDs) + ")";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.ExecuteNonQuery();
            }
        }

        public static void UpdateTransaction(int transactionID, string? newTransactionName, decimal? newMoney, string? newMoneyFlow, string? newCatalog, string? newWalletID, DateTime? date)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [Transaction]
                                 SET TransactionName = COALESCE(@NewTransactionName, TransactionName),
                                     Money = COALESCE(@NewMoney, Money),
                                     TransactionMoneyFlow = COALESCE(@NewMoneyFlow, TransactionMoneyFlow),
                                     TransactionCatalog = COALESCE(@NewCatalog, TransactionCatalog),
                                     WalletID = COALESCE(@NewWalletID, WalletID),
                                     TransactionDate = COALESCE(@NewDate, TransactionDate)
                                 WHERE ID = @TransactionID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                cmd.Parameters.AddWithValue("@NewTransactionName", (object?)newTransactionName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewMoney", (object?)newMoney ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewMoneyFlow", (object?)newMoneyFlow ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewCatalog", (object?)newCatalog ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewWalletID", (object?)newWalletID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewDate", (object?)date ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Transaction> GetAllTransaction()
        {
            List<Transaction> transastions = new List<Transaction>();
            string query = "SELECT * FROM [Transaction]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction()
                    {
                        ID = reader.GetInt32(0),
                        TransactionName = reader.GetString(1),
                        TransactionMoney = (double)reader.GetDecimal(2),
                        TransactionMoneyFlow = reader.GetString(3),
                        TransactionCatalog = reader.IsDBNull(4) ? null : reader.GetString(4),
                        WalletID = reader.IsDBNull(5) ? null : reader.GetString(5),
                        TransactionDate = DateOnly.FromDateTime(reader.GetDateTime(6))
                    };
                    transaction.WalletName = GetWalletNameByID(transaction.WalletID);
                    transastions.Add(transaction);
                }
                reader.Close();
            }
            return transastions;
        }
        public static string GetWalletNameByID(string WalletID)
        {
            string walletName = null;
            string query = @" SELECT WalletName
                            FROM [Wallet]
                            WHERE ID = @WalletID";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@WalletID", WalletID);
                conn.Open();
                object res = command.ExecuteScalar();
                if(res != null && res != DBNull.Value)
                {
                    walletName = res.ToString();
                }
            }
            return walletName;
        }
    }
}
