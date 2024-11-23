using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using System.Security.Principal;
using QuanLyChiTieu.BusinessLogic.OtherClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class FinanceService
    {
        public static List<Transaction> _allTransaction { get; } = new List<Transaction>();

        public static void Alert()
            => Console.WriteLine("the amount is lower than the need");

        public static void Transfer(Transaction transaction, Wallet fromAccount, Wallet toAccount)
        {
            if (transaction.Money > fromAccount.Money)
            {
                Alert();
                return;
            }
            fromAccount.AddTransaction(transaction.SetAsExpense());
            toAccount.AddTransaction(transaction.SetAsIncome());
        }

        public static void EarnMoney(Transaction transaction, Wallet Wallet)
        {
            Wallet.AddTransaction(transaction);
            Wallet.Money += transaction.Money;
            _allTransaction.Add(transaction);
        }

        public static void SpendMoney(Transaction transaction, Wallet Wallet)
        {
            if (transaction.Money > Wallet.Money)
            {
                Alert();
                return;
            }
            //var x = BudgetService._budgetOfEachCatalog[transaction.Catalog];
            //x.Item2 -= transaction.Money;
            //BudgetService._budgetOfEachCatalog[transaction.Catalog] = x;
            Wallet.AddTransaction(transaction);
            Wallet.Money -= transaction.Money;
            _allTransaction.Add(transaction);
        }

        public static void DeleteTransaction(Transaction transaction, Wallet Wallet)
        {
            Wallet.DeleteTransaction(transaction);
            if (transaction.TransactionType == MoneyFlow.Income)
                Wallet.Money -= transaction.Money;
            else
                //var x = BudgetService._budgetOfEachCatalog[transaction.Catalog];
                //x.Item2 += transaction.Money;
                //BudgetService._budgetOfEachCatalog[transaction.Catalog] = x;
                Wallet.Money += transaction.Money;

        }

        public static void UpdateTransaction(Transaction transaction, string WalletName, string Money, MoneyFlow TransactionType, Catalog catalog, Wallet Wallet, DateTime date)
        {
            transaction.Wallet.DeleteTransaction(transaction);
            if (string.IsNullOrWhiteSpace(WalletName))
                transaction.TransactionName = WalletName;
            if (!string.IsNullOrEmpty(Money))
                transaction.Money = Int32.Parse(Money);
            if(TransactionType != null)
                transaction.TransactionType = TransactionType;
            if (catalog != null)
                transaction.Catalog = catalog;
            if(Wallet != null)
            {
                Wallet.AddTransaction(transaction);
                transaction.Wallet = Wallet;
            }
        }

        // Lấy dữ liệu
        public static List<Transaction> GetTransactionHistory(Wallet Wallet)
            => Wallet.GetAllTransactions();

        public static List<Transaction> GetAllDataByFlow(MoneyFlow TransactionType, DateTime startDate, DateTime endDate)
            => _allTransaction.Where(x => x.TransactionType == TransactionType && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                                     .ToList();
    }
}
