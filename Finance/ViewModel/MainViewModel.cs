using BLL;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DTO;

namespace Finance.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private List<Transaction> _list;

        public bool IsLoaded = false;
        public ICommand AddTransactionViewCommand { get; set; }
        public ICommand BudgetViewCommand { get; set; }
        public ICommand ReportsViewCommand { get; set; }
        public ICommand UserWindowCommand { get; set; }
        public ICommand Filter {  get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public List<DateOnly> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public string TransactionMoney { get; set; }
        public string TransactionName { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<Transaction> List 
        {
            get { return _list; }
            set { _list = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;

            List = TransactionBLL.GetAllTransactions();
            List<DateOnly> Labels = TransactionBLL.GetAllTransactions()
                                                   .Select(x => x.TransactionDate)
                                                   .Distinct().OrderBy(date=>date)
                                                   .ToList();
            List<double> IncomeData = StatisticBLL.GetDataByDate("Thu nhập", null, null).Select(x => x.Item2).ToList();
            List<double> ExpenseData = StatisticBLL.GetDataByDate("Chi tiêu", null, null).Select(x => x.Item2).ToList();
            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Thu nhập",
                    Values = new ChartValues<double>(IncomeData)
                },
                new LineSeries
                {
                    Title = "Chi tiêu",
                    Values = new ChartValues<double>(ExpenseData)
                }
            };

            YFormatter = value => $"{value:#,##0.##} ₫";

            AddTransactionViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                AddTransactionView Window = new AddTransactionView();
                Window.ShowDialog();
            }
           );

            BudgetViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                BudgetView Window = new BudgetView();
                Window.ShowDialog();
            }
           );

            ReportsViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                ReportsView Window = new ReportsView();
                Window.ShowDialog();
            }
           );

            UserWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserWindow Window = new UserWindow();
                Window.ShowDialog();
            }
           );

            Filter = new RelayCommand<object>((p) => { return true; }, (p) => Filtered());
        }

        private void Filtered()
        {
            SeriesCollection.Clear();
            Labels = StatisticBLL.GetDateHasData(StartDate, EndDate);

            List<double> IncomeData = StatisticBLL.GetDataByDate("Thu nhập", StartDate, EndDate).Select(x => x.Item2).ToList();
            List<double> ExpenseData = StatisticBLL.GetDataByDate("Chi tiêu", StartDate, EndDate).Select(x => x.Item2).ToList();

            SeriesCollection.Add(new LineSeries()
            {
                Title = "Thu nhập",
                Values = new ChartValues<double>(IncomeData)
            });
            SeriesCollection.Add(new LineSeries()
            {
                Title = "Chi tiêu",
                Values = new ChartValues<double>(ExpenseData)
            });
            List = TransactionBLL.GetAllTransactions()
                                 .Where(x =>
                                    x.TransactionDate >= DateOnly.FromDateTime(StartDate)
                                    &&
                                    x.TransactionDate <= DateOnly.FromDateTime(EndDate))
                                 .ToList();
        }
    }
}
