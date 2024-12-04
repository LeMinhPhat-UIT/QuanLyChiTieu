using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using DTO;
using BLL;
using LiveCharts;

namespace Finance.ViewModel
{
    public class ReportsViewModel : BaseViewModel
    {
        public List<string> Labels { get; set; }
        public List<string> Labels2 { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        public string Income { get; set; }
        public string Spend { get; set; }
        public List<Transaction> List { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> Formatter2 { get; set; }

        public ReportsViewModel()
        {
            Labels = StatisticBLL.GetDataByCatalog("Thu nhập", DateTime.Now.Date, DateTime.Now.Date).Select(x=>x.Item1).ToList();
            Labels2 = StatisticBLL.GetDataByCatalog("Chi tiêu", DateTime.Now.Date, DateTime.Now.Date).Select(x => x.Item1).ToList();

            List<double> IncomeData = StatisticBLL.GetDataByCatalog("Thu nhập", DateTime.Now.Date, DateTime.Now.Date).Select(x => x.Item2).ToList();
            List<double> ExpenseData = StatisticBLL.GetDataByCatalog("Chi tiêu", DateTime.Now.Date, DateTime.Now.Date).Select(x => x.Item2).ToList();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Thu nhập",
                    Values = new ChartValues<double>(IncomeData)
                }
            };

            SeriesCollection2 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Chi tiêu",
                    Values= new ChartValues<double>(ExpenseData)
                }
            };

            List = TransactionBLL.GetAllTransactions();
            Formatter = value => $"{value:#,##0.##} ₫";
            Formatter2 = value => $"{value:#,##0.##} ₫";

            Income = IncomeData.Sum().ToString();
            Spend = ExpenseData.Sum().ToString();

            List = TransactionBLL.GetAllTransactions()
                                 .Where(x=>x.TransactionDate==DateOnly.FromDateTime(DateTime.Now.Date))
                                 .ToList();
        }
    }
}
