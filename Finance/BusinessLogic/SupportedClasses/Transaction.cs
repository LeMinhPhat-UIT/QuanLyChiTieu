using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class Transaction
    {
        private static int cnt = 0;

        public int ID { get; }
        public string TransactionName { get; set; }
        public double Money { get; set; }
        public MoneyFlow TransactionMoneyFlow { get; set; }
        public Catalog Catalog { get; set; }
        public Wallet Wallet { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(string transactionName, string money, string transactionTypeName, string catalogName, DateTime date)
        {

            ID = ++cnt;
            double _money = Int32.Parse(money);
            MoneyFlow _moneyFlow = MoneyFlow._allMoneyFlows[transactionTypeName];
            Catalog _catalog = Catalog._allCatalogs[catalogName];

            if(string.IsNullOrWhiteSpace(transactionName))
                TransactionName = _catalog.Name;
            else TransactionName = transactionName;
            Money = Int32.Parse(money);
            TransactionMoneyFlow = _moneyFlow;
            Catalog = _catalog;
            TransactionDate = date;
        }

        public static Transaction CreateTransaction(string transactionName, string money, string transactionTypeName, string catalogName, DateTime date)
        {
            Transaction newTransaction = new Transaction(transactionName, money, transactionTypeName, catalogName, date);
            FinanceService._allTransaction.Add(newTransaction.ID, newTransaction);
            return newTransaction;
        }

        public Transaction SetAsIncome()
        {
            TransactionMoneyFlow = MoneyFlow.Income;
            return this;
        }

        public Transaction SetAsExpense()
        {
            TransactionMoneyFlow = MoneyFlow.Expense;
            return this;
        }
    }
}
