using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Transaction
    {
        private static int cnt = 0;

        public int ID { get; set; }
        public string TransactionName { get; set; }
        public double TransactionMoney { get; set; }
        public string TransactionMoneyFlow { get; set; }
        public string TransactionCatalog { get; set; }
        public string WalletID { get; set; }
        public DateOnly TransactionDate { get; set; }
    }
}
