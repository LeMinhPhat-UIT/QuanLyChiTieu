using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class AccountType
    {
        public static AccountType Cash = new AccountType("Tiền Mặt");
        public static AccountType DebitCard = new AccountType("Thẻ Ghi Nợ");
        public static AccountType CreditCard = new AccountType("Thẻ Tín Dụng");
        public static AccountType VirtualAccount = new AccountType("Tài Khoản Ảo");
        public static AccountType Investment = new AccountType("Đầu Tư");
        public static AccountType Debt = new AccountType("Nợ Tôi");
        public static AccountType MyDebt = new AccountType("Tôi Nợ");

        public string Name { get; set; }

        private AccountType(string name)
        {
            Name = name;
        }
    }

    internal class Account
    {
        private static int _cnt = 0;
        private List<Transaction> _allTransactions;

        public int Id { get; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public double MoneyAmount { get; set; }

        public Account(string name, AccountType accountType, double moneyAmount = 0)
        {
            Id = ++_cnt;
            Name = name;
            AccountType = AccountType.Cash;
            MoneyAmount = moneyAmount;
            _allTransactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
            => _allTransactions.Add(transaction);
        public void DeleteTransaction(Transaction transaction)
            => _allTransactions.Remove(transaction);

        public List<Transaction> GetAllTransactions()
            => new List<Transaction>(_allTransactions); // Return a copy to prevent external modification
    }

}
