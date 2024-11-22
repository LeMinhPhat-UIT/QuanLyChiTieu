using LiveCharts;
using LiveCharts.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> YFormatter { get; set; }
        public MainWindow()
        {
            //SeriesCollection = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Title = "Thu nhập",
            //        Values = new ChartValues<double> { 868717, 729906, 684041, 503329, 377577, 469490, 595794, 693682, 196731, 741266, 303276, 879585 }
            //    },
            //    new LineSeries
            //    {
            //        Title = "Chi tiêu",
            //        Values = new ChartValues<double> { 272927, 850526, 710670, 330014, 368949, 436081, 995346, 225267, 639344, 408858, 159098, 585442 }
            //    }
            //};

            //Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            //YFormatter = value => value.ToString("N0");

            InitializeComponent();
            //DataContext = this;
        }
    }
}