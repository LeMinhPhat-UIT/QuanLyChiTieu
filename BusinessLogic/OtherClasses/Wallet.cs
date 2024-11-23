using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class WalletType
    {
        public static WalletType Cash = new WalletType("Tiền Mặt");
        public static WalletType DebitCard = new WalletType("Thẻ Ghi Nợ");
        public static WalletType CreditCard = new WalletType("Thẻ Tín Dụng");
        public static WalletType VirtualAccount = new WalletType("Tài Khoản Ảo");
        public static WalletType Investment = new WalletType("Đầu Tư");
        public static WalletType Debt = new WalletType("Nợ Tôi");
        public static WalletType MyDebt = new WalletType("Tôi Nợ");

        public string Name { get; set; }

        private WalletType(string name)
        {
            Name = name;
        }
    }

    internal class Wallet
    {
        private static int _cnt = 0;
        private List<Transaction> _allTransactions = new List<Transaction>();

        public int Id { get; }
        public string WalletName { get; set; }
        public WalletType WalletType { get; set; }
        public double Money { get; set; }
        public DateTime UpdateDate { get; set; }

        public Wallet(string walletName, string money, DateTime updateDate)
        {
            Id = ++_cnt;
            WalletName = walletName;
            WalletType = WalletType.Cash;
            Money = Int32.Parse(money);
            UpdateDate = updateDate;
        }

        public void AddTransaction(Transaction transaction)
            => _allTransactions.Add(transaction);
        public void DeleteTransaction(Transaction transaction)
            => _allTransactions.Remove(transaction);

        public List<Transaction> GetAllTransactions()
            => new List<Transaction>(_allTransactions); // Return a copy to prevent external modification
    }

}
