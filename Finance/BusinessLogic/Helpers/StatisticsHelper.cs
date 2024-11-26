using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.BusinessLogic.Services;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Helpers
{
    public class StatisticsHelper
    {
        public static double GetIncome(DateTime startDate, DateTime endDate)
            => FinanceService._allTransaction.Values
                .Where(x => x.TransactionMoneyFlow == MoneyFlow.Income && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                .Select(x => x.Money).Sum();
            /*
            Lấy tất cả các 'giao dịch' thuộc loại 'thu nhập' từ ngày A đến B và tính tổng 
            */

        public static double GetExpense(DateTime startDate, DateTime endDate)
            => FinanceService._allTransaction.Values
                .Where(x => x.TransactionMoneyFlow == MoneyFlow.Expense && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                .Select(x => x.Money).Sum();
            /*
            Lấy tất cả các 'giao dịch' thuộc loại 'chi tiêu' từ ngày A đến B và tính tổng 
            */

        public static double GetBalance(DateTime startDate, DateTime endDate)
            => GetIncome(startDate, endDate)-GetExpense(startDate, endDate);

        public static SeriesCollection  GetChartData(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            /*
            Lấy dữ liệu theo 'dòng tiền' từ ngày A đến ngày B 
            */
        }
    }
}
