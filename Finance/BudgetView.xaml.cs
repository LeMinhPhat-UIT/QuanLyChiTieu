using Finance.ViewModel;
using LiveCharts;
using System;
using System.Collections.Generic;
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
using QuanLyChiTieu.BusinessLogic.Services;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;
//using QuanLyChiTieu.BusinessLogic.OtherClasses;

namespace Finance
{
    /// <summary>
    /// Interaction logic for BudgetView.xaml
    /// </summary>
    public partial class BudgetView : Window
    {
        public ComboBox comboBox = new ComboBox();
        public BudgetView()
        {
            InitializeComponent();
            //comboBox.ItemsSource = WalletType._allWalletTypes.Values.ToList();
            List<int> list = new List<int>() { 1,2,3,4,5};
            //walletTypeList.ItemsSource= WalletType._allWalletTypes.Values.ToList(); 
            walletTypeList.ItemsSource = list;
            
        }
    }
}
