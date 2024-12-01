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
using DTO;

namespace Finance
{
    /// <summary>
    /// Interaction logic for BudgetView.xaml
    /// </summary>
    public partial class BudgetView : Window
    {
        private BudgetService budgetService = new BudgetService();

        public BudgetView()
        {
            InitializeComponent();
            DataContext = new BudgetViewModel();
        }

        private void WalletSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (DataContext is BudgetViewModel budgetViewModel)
                budgetViewModel.SelectedWallets = listView.SelectedItems.Cast<Wallet>().ToList();
        }
    }
}
