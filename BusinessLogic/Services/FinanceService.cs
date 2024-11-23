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
        public static List<Account> _allAccounts { get; } = new List<Account>();

        public static Account CreateAccount(string name, AccountType accountType, double moneyAmount)
        {
            Account account = new Account(name, accountType, moneyAmount);
            _allAccounts.Add(account);
            return account;
        }
           
        public static void DeleteAccount(int id)
        {
            var account = _allAccounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
                _allAccounts.Remove(account);
        }

        public static void UpdateAccount(int id, string name="", AccountType? accountType=null, double moneyAmount=-1)
        {
            var account = _allAccounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return;
            if (!string.IsNullOrWhiteSpace(name))
                account.Name = name;
            if(accountType != null)
                account.AccountType = accountType;
            if(moneyAmount!=-1)
                account.MoneyAmount = moneyAmount;
        }

        public static void Alert()
            => Console.WriteLine("the amount is lower than the need");

        public static void Transfer(Transaction transaction, Account fromAccount, Account toAccount) 
        {
            if (transaction.MoneyAmount > fromAccount.MoneyAmount)
            {
                Alert();
                return;
            }
            fromAccount.AddTransaction(transaction.SetAsExpense());
            toAccount.AddTransaction(transaction.SetAsIncome());
        }

        public static void EarnMoney(Transaction transaction, Account account)
        {
            account.AddTransaction(transaction.SetAsIncome());
            account.MoneyAmount += transaction.MoneyAmount;
            _allTransaction.Add(transaction);
        }

        public static void SpendMoney(Transaction transaction, Account account)
        {
            if (transaction.MoneyAmount > account.MoneyAmount)
            {
                Alert();
                return;
            }
            var x = BudgetService._budgetOfEachCatalog[transaction.Catalog];
            x.Item2-=transaction.MoneyAmount;
            BudgetService._budgetOfEachCatalog[transaction.Catalog] = x;
            account.AddTransaction(transaction.SetAsExpense());
            account.MoneyAmount -= transaction.MoneyAmount;
            _allTransaction.Add(transaction);
        }

        public static void DeleteTransaction(int idTransaction, int idAccount)
        {
            var transaction = _allTransaction.FirstOrDefault(x => x.Id==idTransaction);
            var account = _allAccounts.FirstOrDefault(x => x.Id==idAccount);
            if (transaction != null)
            {
                account.DeleteTransaction(transaction);
                if (transaction.Flow == FinanceFlow.Income)
                    account.MoneyAmount -= transaction.MoneyAmount;
                else 
                {
                    var x = BudgetService._budgetOfEachCatalog[transaction.Catalog];
                    x.Item2 += transaction.MoneyAmount;
                    BudgetService._budgetOfEachCatalog[transaction.Catalog] = x;
                    account.MoneyAmount += transaction.MoneyAmount; 
                }

            }
        }

        public static void UpdateTransaction(int id, Account? account=null, Catalog? catalog=null, FinanceFlow? flow=null, double moneyAmount=-1, string note="")
        {
            var transaction = _allTransaction.FirstOrDefault(a => a.Id == id);
            if (transaction != null)
            {
                if (catalog != null)
                    transaction.Catalog = catalog;
                if (flow == FinanceFlow.Income)
                    transaction.SetAsIncome();
                else transaction.SetAsExpense();
                if (moneyAmount != -1)
                    transaction.MoneyAmount = moneyAmount;
                if (string.IsNullOrWhiteSpace(note))
                    transaction.Note = note;
                if (account != null)
                {
                    if (flow == FinanceFlow.Income)
                        EarnMoney(transaction, account);
                    else
                        SpendMoney(transaction, account);
                }
            }
        }

        // Lấy dữ liệu
        public static List<Transaction> GetTransactionHistory(Account account)
            => account.GetAllTransactions();


        public static List<Transaction> GetAllDataByFlow(FinanceFlow flow, DateTime startDate, DateTime endDate)
            => _allTransaction.Where(x => x.Flow == flow && DateHelper.isBetween(x.Date, startDate, endDate))
                                     .ToList();
        //public static void SetRecurringTransactions() { }

        /* Cân nhắc xóa 
        public static List<Transaction> GetDataFromDateToDate(Account account, FinanceFlow flow, DateTime startDate, DateTime endDate)
        {
            List<Transaction> allTransactions = account.GetAllTransactions();
            List<Transaction> transactions = new List<Transaction>();
            foreach (Transaction transaction in allTransactions)
                if (transaction.Date >= startDate && transaction.Date <= endDate && transaction.Flow == flow)
                    transactions.Add(transaction);
            return transactions;
        }*/
    }
}
