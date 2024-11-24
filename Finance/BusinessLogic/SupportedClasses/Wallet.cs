using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class Wallet
    {
        private static int _cnt = 0;
        private static Dictionary<int, Transaction> _allTransactions = new Dictionary<int, Transaction>();

        public int ID { get; }
        public string WalletName { get; set; }
        public WalletType WalletType { get; set; }
        public double Money { get; set; }
        public DateTime UpdateDate { get; set; }

        public Wallet(string walletName, string type, string money, DateTime updateDate)
        {
            ID = ++_cnt;
            WalletName = walletName;
            WalletType = WalletType._allWalletTypes[type];
            Money = Int32.Parse(money);
            UpdateDate = updateDate;
        }

        public void AddTransaction(int transactionID)
        {
            Transaction transaction = FinanceService._allTransaction[transactionID];
            _allTransactions.Add(transactionID, transaction);
        }

        public void DeleteTransaction(int transactionID)
            => _allTransactions.Remove(transactionID);

        //public List<Transaction> GetAllTransactions()
        //    => new List<Transaction>(_allTransactions); // Return a copy to prevent external modification
    }

}
