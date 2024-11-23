using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.OtherClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class BudgetService
    {
        //public static Dictionary<Catalog, (double Item1, double Item2)> _budgetOfEachCatalog = new Dictionary<Catalog, (double, double)>();
        public static List<Wallet> WalletsList { get; } = new List<Wallet>();

        public static Wallet CreateWallet(string walletName, string money, DateTime updateDate)
        {
            Wallet Wallet = new Wallet(walletName, money, updateDate);
            WalletsList.Add(Wallet);
            return Wallet;
        }

        public static void DeleteWallet(Wallet wallet)
            => WalletsList.Remove(wallet);

        public static void UpdateWallet(Wallet wallet, string walletName = "", WalletType? WalletType = null, string money = "")
        {
            if (wallet == null)
                return;
            if (!string.IsNullOrWhiteSpace(walletName))
                wallet.WalletName = walletName;
            if (WalletType != null)
                wallet.WalletType = WalletType;
            if (string.IsNullOrEmpty(money))
                wallet.Money = Int32.Parse(money);
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
