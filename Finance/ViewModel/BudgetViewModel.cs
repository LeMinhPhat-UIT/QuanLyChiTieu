using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Finance.ViewModel
{
    public class BudgetViewModel : BaseViewModel
    {
        private string _walletName;
        private double _money;
        private List<string> _walletType;
        private string _selectedWalletType;
        private DateTime _updateDate;
        private List<Wallet> _walletList;
        private List<Wallet> _selectedWallets;

        public string WalletName
        {
            get { return _walletName; } 
            set { _walletName = value; OnPropertyChanged(); }
        }

        public double Money
        {
            get { return _money; }
            set { _money = value; OnPropertyChanged(); }
        }

        public List<string> WalletType
        {
            get { return _walletType; }
            set { _walletType = value; OnPropertyChanged(); }
        }

        public string SelectedWalletType
        {
            get { return _selectedWalletType; }
            set { _selectedWalletType = value; OnPropertyChanged(); }
        }

        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; OnPropertyChanged(); }
        }

        public List<Wallet> WalletList
        {
            get { return _walletList; }
            set { _walletList = value; OnPropertyChanged(); }
        }

        public List<Wallet> SelectedWallets
        {
            get { return _selectedWallets; }
            set { _selectedWallets = value; OnPropertyChanged(); } 
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BudgetViewModel() 
        {
            UpdateDate = DateTime.Now;
            WalletList = WalletBLL.LoadWallets();
            WalletType = new List<string>()
            {
                "Tiền Mặt",
                "Thẻ Ghi Nợ",
                "Thẻ Tín Dụng",
                "Đầu tư"
            };

            AddCommand = new RelayCommand<object>((p) => true, (p) => AddWallet());
            DeleteCommand = new RelayCommand<object>((p) => true, (p) => DeleteWallet());
            EditCommand = new RelayCommand<object>(p => true, (p) => UpdateWallet());
        }

        private void AddWallet()
        {
            if(WalletName == null || SelectedWalletType == null || Money == 0)
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
                return;
            }
            WalletBLL.AddWallet(WalletName, SelectedWalletType.ToString(), Money.ToString(), UpdateDate);
            WalletList = WalletBLL.LoadWallets();
        }

        private void UpdateWallet()
        {
            if (SelectedWallets == null || !SelectedWallets.Any())
            {
                MessageBox.Show("Vui lòng chọn ví", "Thông báo", MessageBoxButton.OK);
                return;
            }
            if (SelectedWallets.Count == 1)
            {
                WalletBLL.UpdateWallet(SelectedWallets[0].ID, WalletName, SelectedWalletType, Money.ToString(), UpdateDate);
                WalletList = WalletBLL.LoadWallets();
            }
        }

        private void DeleteWallet()
        {
            if(SelectedWallets == null || !SelectedWallets.Any())
            {
                MessageBox.Show("Vui lòng chọn ví", "Thông báo", MessageBoxButton.OK);
                return;
            }
            foreach (Wallet wallet in SelectedWallets)
                WalletBLL.DeleteWallet(wallet.ID);
            WalletList = WalletBLL.LoadWallets();
        }
    }
}
