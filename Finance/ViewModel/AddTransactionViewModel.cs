using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using BLL;
using DAL;
using DTO;

namespace Finance.ViewModel
{
    public class AddTransactionViewModel : BaseViewModel
    {

        private List<Catalog> CatalogList;
        private string _transactionName;
        private decimal _transactionMoney;
        private List<string> _catalogMoneyFlow;
        private string _selectedCatalogMoneyFlow;
        private List<string> _catalogName;
        private string _selectedCatalogName;
        private List<Wallet> _walletList;
        private Wallet _selectedWallet;
        private DateTime _transactionDate;
        private List<Transaction> _transactionList;
        private List<Transaction> _selectedTransactions;

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

        public List<string> CatalogMoneyFlow
        {
            get { return _catalogMoneyFlow; }
            set { _catalogMoneyFlow = value; OnPropertyChanged(); }
        }

        public string SelectedCatalogMoneyFlow
        {
            get { return _selectedCatalogMoneyFlow; }
            set { _selectedCatalogMoneyFlow = value; OnPropertyChanged(); FilterCatalogName(); }
        }

        public List<string> CatalogName
        {
            get { return _catalogName; }
            set { _catalogName = value; OnPropertyChanged(); }
        }

        public string SelectedCatalogName
        {
            get { return _selectedCatalogName; }
            set { _selectedCatalogName = value; OnPropertyChanged(); FilterCatalogMoneyFlow(); }
        }

        public List<Wallet> WalletList
        {
            get { return _walletList; }
            set { _walletList = value; OnPropertyChanged(); }
        }

        public Wallet SelectedWallet
        {
            get { return _selectedWallet; }
            set { _selectedWallet = value; OnPropertyChanged(); }
        }

        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; OnPropertyChanged(); }
        }

        public List<Transaction> TransactionList
        {
            get { return _transactionList; }
            set { _transactionList = value; OnPropertyChanged(); }
        }

        public List<Transaction> SelectedTransactions
        {
            get { return _selectedTransactions; }
            set { _selectedTransactions = value; OnPropertyChanged(); }
        }

        private void FilterCatalogName()
        {
            CatalogName.Clear();
            var filtered = CatalogList.Where(x => x.CatalogMoneyFlow == SelectedCatalogMoneyFlow).Select(x => x.CatalogName).Distinct().ToList();
            CatalogName = filtered;
        }

        private void FilterCatalogMoneyFlow()
        {
            if(SelectedCatalogName != null)
            {
                var catalogMoneyFlow = CatalogList?.FirstOrDefault(x=>x.CatalogName == SelectedCatalogName);
                if(catalogMoneyFlow != null)
                    if(SelectedCatalogMoneyFlow != catalogMoneyFlow.CatalogMoneyFlow)
                        SelectedCatalogMoneyFlow = catalogMoneyFlow.CatalogMoneyFlow;
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public AddTransactionViewModel()
        {
            TransactionDate = DateTime.Now.Date;
            TransactionList = TransactionBLL.GetAllTransactions();

            AddCommand = new RelayCommand<object>((p) => true, (p) => AddTransaction());
            DeleteCommand = new RelayCommand<object>((p) => true, (p) => DeleteTransaction());
            EditCommand = new RelayCommand<object>(p => true, (p) => EditTransaction());

            WalletList = WalletBLL.LoadWallets();
            CatalogList = CatalogDAL.GetAllCatalog();
            CatalogMoneyFlow = CatalogList.Select(x=>x.CatalogMoneyFlow).Distinct().ToList();
            CatalogName = CatalogList.Select(x=>x.CatalogName).Distinct().ToList();
        }

        private void AddTransaction()
        {
            var newTransacID = TransactionBLL.CreateTransaction(TransactionName, (double)TransactionMoney, SelectedCatalogMoneyFlow, SelectedCatalogName, SelectedWallet.ID.ToString(), TransactionDate);
            TransactionBLL.AddTransaction(newTransacID, SelectedWallet.ID);
            TransactionList = TransactionBLL.GetAllTransactions();
        }

        private void DeleteTransaction()
        {
            TransactionBLL.DeleteTransaction(SelectedTransactions.Select(x=>x.ID).ToList());
            TransactionList = TransactionBLL.GetAllTransactions();
        }

        private void EditTransaction()
        {
            if(SelectedTransactions.Count == 1)
                TransactionBLL.UpdateTransaction(SelectedTransactions[0].ID, TransactionName, (double)TransactionMoney, SelectedCatalogMoneyFlow, SelectedCatalogName, SelectedTransactions[0].WalletID, TransactionDate);
            TransactionList = TransactionBLL.GetAllTransactions();
        }
    }
}