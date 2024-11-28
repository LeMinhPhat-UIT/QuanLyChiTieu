using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BLL;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class BudgetService
    {
        private WalletBLL walletBLL = new WalletBLL();

        public static Wallet CreateWallet(string walletName, string type, string money, DateTime updateDate)
        {
            return WalletBLL.AddWallet(walletName, type, money, updateDate);
        }

        public static void DeleteWallet(List<int> walletID)
        {
            foreach (var id in walletID)
            {
                WalletBLL.DeleteWallet(id);
            }
        }

        public static void UpdateWallet(int walletID, string? newWalletName, string? newWalletType, string? newMoney, DateTime? updateDate = null)
        {
            WalletBLL.UpdateWallet(walletID,newWalletName, newWalletType, newMoney, updateDate);
        }

        //public static void Load(ListView listView, List<Wallet> wallets)
        public static void Load(ListView listView)
        {
            List<Wallet> wallets = WalletBLL.LoadWallets();

            listView.ItemsSource = wallets;
        }
    }
}
