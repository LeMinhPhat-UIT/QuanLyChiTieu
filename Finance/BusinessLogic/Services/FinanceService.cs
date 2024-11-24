using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class FinanceService
    {
        public static Dictionary<int, Transaction> _allTransaction { get; } = new Dictionary<int, Transaction>();

        public static void Alert()
            => Console.WriteLine("the amount is lower than the need");

        public static void AddTransaction(int transactionID, int walletID)
        {
            Transaction transaction = _allTransaction[transactionID];
            Wallet wallet = BudgetService._allWallets[walletID];
            if(transaction.TransactionMoneyFlow == MoneyFlow.Expense)
                if(transaction.Money > wallet.Money)
                    Alert();
            wallet.AddTransaction(transactionID);
            if (transaction.TransactionMoneyFlow == MoneyFlow.Income)
                wallet.Money += transaction.Money;
            else wallet.Money -= transaction.Money;
        }

        public static void DeleteTransaction(int transactionID)
        {
            Transaction transaction = _allTransaction[transactionID];
            Wallet wallet = transaction.Wallet;
            wallet.DeleteTransaction(transactionID);
            if (transaction.TransactionMoneyFlow == MoneyFlow.Income)
                wallet.Money -= transaction.Money;
            else
                wallet.Money += transaction.Money;
            _allTransaction.Remove(transactionID);
        }

        public static void UpdateTransaction(int transactionID, string? newTransactionName, string? newMoney, string? newMoneyFlow, string? newCatalog, int newWalletID = -1, DateTime? date = null)
        {
            Transaction transaction = _allTransaction[transactionID];
            if(!string.IsNullOrEmpty(newTransactionName))
                transaction.TransactionName = newTransactionName;
            if (!string.IsNullOrEmpty(newMoney))
                transaction.Money = Int32.Parse(newMoney);
            if(newMoneyFlow != null)
                transaction.TransactionMoneyFlow = MoneyFlow._allMoneyFlows[newMoneyFlow];
            if (newCatalog != null)
                transaction.Catalog = Catalog._allCatalogs[newCatalog];
            if(newWalletID != -1)
            {
                transaction.Wallet.DeleteTransaction(transactionID);
                Wallet newWallet = BudgetService._allWallets[newWalletID];
                newWallet.AddTransaction(transactionID);
                transaction.Wallet = newWallet;
            }
            if (date != null)
                transaction.TransactionDate = (DateTime)date;
        }

        public static List<Transaction> GetAllDataByFlow(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            MoneyFlow transactionMoneyFlow = MoneyFlow._allMoneyFlows[moneyFlow];
            return _allTransaction.Values.Where(x => x.TransactionMoneyFlow == transactionMoneyFlow && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                                     .ToList();

        }
    }
}
