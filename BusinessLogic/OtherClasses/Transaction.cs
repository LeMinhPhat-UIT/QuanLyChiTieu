using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class MoneyFlow
    {
        public static MoneyFlow Income = new MoneyFlow("Thu Nhập");
        public static MoneyFlow Expense = new MoneyFlow("Chi Tiêu");

        public string Name { get; set; }
        private MoneyFlow(string name)
            => Name = name ?? throw new ArgumentNullException(nameof(name), "Tên dòng tiền không được để trống.");
    }

    internal class Transaction
    {
        private static int _cnt = 0;

        public int Id { get; }
        public string TransactionName { get; set; }
        public double Money { get; set; }
        public MoneyFlow TransactionType { get; set; }
        public Catalog Catalog { get; set; }
        public Wallet Wallet { get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction(string walletName, string money, MoneyFlow transactionType, Catalog catalog, Wallet wallet, DateTime date)
        {
            Id = ++_cnt;
            if(string.IsNullOrWhiteSpace(walletName))
                TransactionName = catalog.WalletName;
            else TransactionName = walletName;
            Money = Int32.Parse(money);
            TransactionType = transactionType;
            Catalog = catalog;
            Wallet = wallet;
            TransactionDate = date;
        }

        public Transaction SetAsIncome()
        {
            TransactionType = MoneyFlow.Income;
            return this;
        }

        public Transaction SetAsExpense()
        {
            TransactionType = MoneyFlow.Expense;
            return this;
        }
    }
}
