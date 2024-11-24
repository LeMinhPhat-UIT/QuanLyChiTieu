using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class BudgetService
    {
        public static Dictionary<int, Wallet> _allWallets { get; } = new Dictionary<int, Wallet>();

        public static Wallet CreateWallet(string walletName, string type, string money, DateTime updateDate)
        {
            Wallet Wallet = new Wallet(walletName, type, money, updateDate);
            _allWallets.Add(Wallet.ID, Wallet);
            return Wallet;
        }

        public static void DeleteWallet(int walletID)
            => _allWallets.Remove(walletID);

        public static void UpdateWallet(int walletID, string? newWalletName, string? newWalletType, string? newMoney, DateTime? updateDate = null)
        {
            Wallet updateWallet = _allWallets[walletID];

            if (!string.IsNullOrEmpty(newWalletName))
                updateWallet.WalletName = newWalletName;
            if (!string.IsNullOrEmpty(newWalletType))
                updateWallet.WalletType = WalletType._allWalletTypes[newWalletType];
            if (!string.IsNullOrEmpty(newMoney))
                updateWallet.Money = Double.Parse(newMoney);
            if (updateDate != null)
                updateWallet.UpdateDate = (DateTime)updateDate;
        }

        //public void SetBudget(Catalog catalog, double money) 
        //{
        //    _budgetOfEachCatalog.Add(catalog, (money, money));
        //    totalBudget += money;
        //}

        //public void UpdateBudget(Catalog catalog, double money) 
        //{
        //    totalBudget -= _budgetOfEachCatalog[catalog].Item1;
        //    _budgetOfEachCatalog[catalog] = (money, money);
        //    totalBudget += money;
        //}

        //public void DeleteBudget(Catalog catalog) 
        //{
        //    totalBudget -= _budgetOfEachCatalog[catalog].Item1;
        //    _budgetOfEachCatalog.Remove(catalog);
        //}

        //public (double, double) GetRemainingBudget(Catalog? catalog = null) 
        //{
        //    if(catalog == null)
        //    {
        //        double remaining = _budgetOfEachCatalog.Select(x => x.Value.Item2).ToList().Sum();
        //        return (remaining, 100*remaining/totalBudget);
        //    }
        //    else
        //        return (_budgetOfEachCatalog[catalog].Item2, 100*_budgetOfEachCatalog[catalog].Item2/ _budgetOfEachCatalog[catalog].Item1);
        //}
    }
}
