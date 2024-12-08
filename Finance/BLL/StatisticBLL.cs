using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatisticBLL
    {
        public static List<Tuple<DateOnly, double>> GetDataByDate(string moneyFlow, DateTime? startDate, DateTime? endDate)
            => StatisticDAL.GetDataByDate(moneyFlow, startDate, endDate);

        public static List<Tuple<string, double>> GetDataByCatalog(string catalogName, DateTime startDate, DateTime endDate)
            => StatisticDAL.GetDataByCatalog(catalogName, startDate, endDate);

        public static List<DateOnly> GetDateHasData(DateTime startDate, DateTime endDate)
            => StatisticDAL.GetDateHasData(startDate, endDate);

        public static List<Tuple<string, double>> GetDataByMonth(string moneyFlow)
        {
            var allTransactions = TransactionDAL.GetAllTransaction();

            var filteredTransactions = allTransactions
        .Where(t => t.TransactionMoneyFlow == moneyFlow)
        .ToList();

            var groupedByMonth = filteredTransactions
        .GroupBy(t => new { t.TransactionDate.Year, t.TransactionDate.Month })
        .OrderBy(g => g.Key.Year)
        .ThenBy(g => g.Key.Month);
            var result = groupedByMonth
                        .Select(g => new Tuple<string, double>(
                        $"{g.Key.Month:00}/{g.Key.Year}",
                        g.Sum(t => t.TransactionMoney)
                        ))
                        .ToList();

            return result;
        }
    }
}
