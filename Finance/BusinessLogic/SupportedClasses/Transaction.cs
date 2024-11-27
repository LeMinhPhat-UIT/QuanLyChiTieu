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
        public string TransactionMoneyFlow { get; set; }
        public string TransactionCatalog { get; set; }
        public string TransactionBudgetService { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
