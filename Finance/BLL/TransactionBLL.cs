using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows;
using System.Security.Policy;

namespace BLL
{
    public static class TransactionBLL
    {
        static int signal = 0; // dong nay hoi ngu =))
        public static int CreateTransaction(string transactionName, double money, string moneyFlow, string catalog, string walletID, DateTime date)
        {
            int _walletID = Int32.Parse(walletID);
            var wallet = WalletDAL.GetWalletByID(_walletID);
            if (wallet.Money < money && moneyFlow == "Chi tiêu")
            {
                signal = 1;
                MessageBox.Show("Số dư không đủ để thực hiện giao dịch", "Thông báo", MessageBoxButton.OK);
                //throw new InvalidOperationException("Số dư ví không đủ để thực hiện giao dịch.");
                return 0;
            }
            return TransactionDAL.CreateTransaction(transactionName, Math.Round((decimal)money, 2), moneyFlow, catalog, walletID, date);
        }

        public static void AddTransaction(int transactionID, int walletID)
        {
            if (signal == 1)
            {
                signal = 0;
                return;
            }
            TransactionDAL.AddTransaction(transactionID, walletID);
        }

        public static void DeleteTransaction(List<int> transactionIDs)
        {
            TransactionDAL.DeleteTransaction(transactionIDs);
        }

        public static void UpdateTransaction(int transactionID, string? newTransactionName, double? newMoney, string? newMoneyFlow, string? newCatalog, string? newWalletID, DateTime? date = null)
        {
            TransactionDAL.UpdateTransaction(transactionID, newTransactionName, Math.Round((decimal)newMoney, 2), newMoneyFlow, newCatalog, newWalletID, date);
        }

        public static List<Transaction> GetAllTransactions()
            => TransactionDAL.GetAllTransaction();
    }

}
