using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using Finance.ViewModel;
using QuanLyChiTieu.BusinessLogic.Services;
using DTO;

namespace Finance
{
    /// <summary>
    /// Interaction logic for AddTransactionView.xaml
    /// </summary>
    public partial class AddTransactionView : Window
    {
        public AddTransactionView()
        {
            InitializeComponent();
            this.DataContext = new AddTransactionViewModel();
        }
        private void TransactionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (DataContext is AddTransactionViewModel addTransactionViewModel)
                addTransactionViewModel.SelectedTransactions = listView.SelectedItems.Cast<Transaction>().ToList();
        }
    }
}
