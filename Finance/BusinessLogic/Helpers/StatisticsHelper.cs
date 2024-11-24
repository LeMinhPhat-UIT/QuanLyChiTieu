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

        public static double GetExpense(DateTime startDate, DateTime endDate)
            => FinanceService._allTransaction.Values
                .Where(x => x.TransactionMoneyFlow == MoneyFlow.Expense && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                .Select(x => x.Money).Sum();

        public static double GetBalance(DateTime startDate, DateTime endDate)
            => GetIncome(startDate, endDate)-GetExpense(startDate, endDate);

        public static Tuple<SeriesCollection, StatisticReport>  GetChartData(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            SeriesCollection series;
            StatisticReport statisticReport;

            double total, mean, median, min, max;
            total=mean=median=min=max=0;

            MoneyFlow transactionMoneyFlow = MoneyFlow._allMoneyFlows[moneyFlow];
            var dataByFlow = FinanceService.GetAllDataByFlow(transactionMoneyFlow, startDate, endDate);
            var values = new ChartValues<double>();

            foreach (var data in dataByFlow)
                values.Add(data.Money);
            total = values.Sum();
            mean = values.Average();
            median = (values[(values.Count()-1)/2] + values[values.Count()/2])/2;
            min = values.Min();
            max = values.Max();

            series = new SeriesCollection()
            {
                new LineSeries
                {
                    Values = values,
                },
            };
            statisticReport = new StatisticReport()
            {
                Total = total,
                Mean = mean,
                Median = median,
                Min = min,
                Max = max,
            };

            return Tuple.Create(series, statisticReport);
        }

        //public static Chart GetDataForChart(MoneyFlow TransactionMoneyFlow, DateTime startDate, DateTime endDate)
        //{
        //    Chart chart = new Chart();

        //    List<Transaction> data = FinanceService.GetAllDataByFlow(TransactionMoneyFlow, startDate, endDate);
        //    double total = GetIncome(startDate, endDate);

        //    double mean = total/DateHelper.GetDayBetween(startDate, endDate).Days;
        //    double median = (data[data.Count/2 - 1].Money + data[data.Count/2].Money)/2;
        //    double min = data.Min(x=>x.Money);
        //    double max = data.Max(x=>x.Money);

        //    chart.SummaryStatistic = new double[] { total, mean, median, min, max};
        //    foreach (var transaction in data)
        //    {
        //        double percent = 100 * transaction.Money / total;
        //        chart.AddData(transaction.Catalog, transaction.Money, percent);
        //    }
        //    return chart;
        //}

        //public static void GenerateReport(Chart chart, string filePath)
        //{
        //    using (StreamWriter writer = new StreamWriter(filePath))
        //    {
        //        writer.WriteLine("Id:", chart.Id);
        //        foreach (var item in chart.Data)
        //        {
        //            writer.WriteLine("{0}, {1}, {2}, {3}, {4}", 
        //                chart.SummaryStatistic[0], chart.SummaryStatistic[1], 
        //                chart.SummaryStatistic[2], chart.SummaryStatistic[3], 
        //                chart.SummaryStatistic[4]);
        //            writer.WriteLine("{0}, {1}, {2}",item.Key, item.Value.Item1, item.Value.Item2);
        //        }
        //    }
        //}
    }
}
