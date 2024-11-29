using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public static class TransactionBLL
    {
        public static int CreateTransaction(string transactionName, double money, string moneyFlow, string catalog, string walletID, DateTime date)
        {
            return TransactionDAL.CreateTransaction(transactionName, Math.Round((decimal)money,2), moneyFlow, catalog, walletID, date);
        }

        public static void AddTransaction(int transactionID, int walletID)
        {
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

        public static List<Transaction> Load()
            => TransactionDAL.GetAllTransaction();
    }

}
