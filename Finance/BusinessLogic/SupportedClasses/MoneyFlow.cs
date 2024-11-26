using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class MoneyFlow
    {
        public static Dictionary<string, MoneyFlow> _allMoneyFlows { get; } = new Dictionary<string, MoneyFlow>();
        
        public string Name { get; set; }

        private MoneyFlow(string name)
        {
            Name = name;
            _allMoneyFlows[name] = this;
        }

        public static MoneyFlow Income { get; }
        public static MoneyFlow Expense { get; }
        static MoneyFlow()
        {
            Income = new MoneyFlow("Thu Nhập");
            Expense = new MoneyFlow("Chi Tiêu");
        }
    }
}
