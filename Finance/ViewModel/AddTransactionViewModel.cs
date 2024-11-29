using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL;
using DTO;

namespace Finance.ViewModel
{
    public class AddTransactionViewModel : BaseViewModel
    {
        public ObservableCollection<string> TransactionCatalog { get; set; }

        private ObservableCollection<string> _transactionMoneyFlow;
        private List<string> _transactionBudgetService;
        private string _selectedTransactionMoneyFlow;
        private string _selectedTransactionCatalog;
        private string _selectedTransactionBudgetService;
        private string _transactionName;
        private decimal _transactionMoney;
        private DateTime _transactionDate;
        private ObservableCollection<Transaction> _list;
        private Transaction _selectedTransaction;

        public ObservableCollection<string> TransactionMoneyFlow 
        { 
            get { return _transactionMoneyFlow; }
            set { _transactionMoneyFlow = value; OnPropertyChanged(); }
        }

        public List<string> TransactionBudgetService
        { 
            get { return _transactionBudgetService; }
            set { _transactionBudgetService = value; OnPropertyChanged(); }
        }

        public string SelectedTransactionMoneyFlow
        {
            get { return _selectedTransactionMoneyFlow; }
            set { _selectedTransactionMoneyFlow = value; OnPropertyChanged(); }
        }

        public string SelectedTransactionCatalog
        {
            get { return _selectedTransactionCatalog; }
            set { _selectedTransactionCatalog = value; OnPropertyChanged(); }
        }

        public string SelectedTransactionBudgetService
        {
            get { return _selectedTransactionBudgetService; }
            set { _selectedTransactionBudgetService = value; OnPropertyChanged(); }
        }

        public string TransactionName
        {
            get { return _transactionName; }
            set { _transactionName = value; OnPropertyChanged(); }
        }

        public decimal TransactionMoney
        {
            get { return _transactionMoney; }
            set { _transactionMoney = value; OnPropertyChanged(); }
        }

        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; OnPropertyChanged(); }
        }

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set { _selectedTransaction = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Transaction> List
        {
            get => _list;
            set { _list = value;OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public AddTransactionViewModel()
        {
            var x = WalletBLL.LoadWallets();

            AddCommand = new RelayCommand<object>((p) => true, (p) => AddTransaction());
            DeleteCommand = new RelayCommand<object>((p) => true, (p) => DeleteTransaction());
            List = new ObservableCollection<Transaction>();
            TransactionBudgetService = new List<string>();
            TransactionBudgetService = x.Select(y=>y.WalletName).ToList();
            Load();
        }

        private void AddTransaction()
        {
            var newTransacID = TransactionBLL.CreateTransaction(TransactionName, (double)TransactionMoney, SelectedTransactionMoneyFlow, SelectedTransactionCatalog, SelectedTransactionBudgetService, TransactionDate);
            TransactionBLL.AddTransaction(newTransacID, 1);
            Load();
        }

        private void DeleteTransaction()
        {
            
            Load();
        }

        private void Load()
        {
            List.Clear();
            var list = TransactionBLL.Load();
            foreach (var item in list)
                List.Add(item);
        }
    }
}
