using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Services;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.OtherClasses;

namespace QuanLyChiTieu.BusinessLogic.Helpers
{
    internal class StatisticsHelper
    {
        public static double GetIncome(DateTime startDate, DateTime endDate)
            => FinanceService._allTransaction
                .Where(x => x.Flow == FinanceFlow.Income && DateHelper.isBetween(x.Date, startDate, endDate))
                .Select(x => x.MoneyAmount).Sum();

        public static double GetExpense(DateTime startDate, DateTime endDate)
            => FinanceService._allTransaction
                .Where(x => x.Flow == FinanceFlow.Expense && DateHelper.isBetween(x.Date, startDate, endDate))
                .Select(x => x.MoneyAmount).Sum();

        public static double GetBalance(DateTime startDate, DateTime endDate)
            => GetIncome(startDate, endDate)-GetExpense(startDate, endDate);

        public static Chart GetDataForChart(FinanceFlow flow, DateTime startDate, DateTime endDate)
        {
            Chart chart = new Chart();

            List<Transaction> data = FinanceService.GetAllDataByFlow(flow, startDate, endDate);
            double total = GetIncome(startDate, endDate);

            double mean = total/DateHelper.GetDayBetween(startDate, endDate).Days;
            double median = (data[data.Count/2 - 1].MoneyAmount + data[data.Count/2].MoneyAmount)/2;
            double min = data.Min(x=>x.MoneyAmount);
            double max = data.Max(x=>x.MoneyAmount);

            chart.SummaryStatistic = new double[] { total, mean, median, min, max};
            foreach (var transaction in data)
            {
                double percent = 100 * transaction.MoneyAmount / total;
                chart.AddData(transaction.Catalog, transaction.MoneyAmount, percent);
            }
            return chart;
        }

        public static void GenerateReport(Chart chart, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id:", chart.Id);
                foreach (var item in chart.Data)
                {
                    writer.WriteLine("{0}, {1}, {2}, {3}, {4}", 
                        chart.SummaryStatistic[0], chart.SummaryStatistic[1], 
                        chart.SummaryStatistic[2], chart.SummaryStatistic[3], 
                        chart.SummaryStatistic[4]);
                    writer.WriteLine("{0}, {1}, {2}",item.Key, item.Value.Item1, item.Value.Item2);
                }
            }
        }

        public static void GetMonthlyAnalyze(int year){}

    }
}
