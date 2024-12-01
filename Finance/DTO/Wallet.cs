using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Wallet
    {
        private static int _cnt = 0;
        private static Dictionary<int, Transaction> _allTransactions = new Dictionary<int, Transaction>();

        public int ID { get; set;  }
        public string WalletName { get; set; }
        public string WalletType { get; set; }
        public double Money { get; set; }
        public DateOnly UpdateDate { get; set; }
    }

}
