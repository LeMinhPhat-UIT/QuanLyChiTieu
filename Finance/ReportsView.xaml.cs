using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Finance
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> Formatter { get; set; }
        public ReportsView()
        {
            //SeriesCollection = new SeriesCollection
            //{
            //    new ColumnSeries
            //    {
            //        Title = "VND",
            //        Values = new ChartValues<double> { 10, 50, 39, 50 }
            //    }
            //};

            //Labels = new[] { "Nấu ăn", "Khách sạn", "Đi chợ", "Xem phim" };
            //Formatter = value => value.ToString("N0");

            InitializeComponent();
            DataContext = this;
        }
    }
}
