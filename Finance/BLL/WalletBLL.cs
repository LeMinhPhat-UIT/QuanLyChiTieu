using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class WalletBLL
    {
        private WalletDAL walletDAL = new WalletDAL();
        public static Wallet AddWallet(string walletName, string type, string money, DateTime updateDate)
        {
            Wallet wallet = new Wallet
            {
                WalletName = walletName,
                WalletType = type,
                Money = double.Parse(money),
                UpdateDate = DateOnly.FromDateTime(updateDate)
            };
            WalletDAL.AddWallet(wallet);
            return wallet;
        }

        public static Wallet GetWalletByID(int id)
        {
            return WalletDAL.GetWalletByID(id);
        }

        public static void DeleteWallet(int id)
        {
            WalletDAL.DeleteWallet(id);
        }

        public static void UpdateWallet(int walletID, string? newWalletName, string? newWalletType, string? newMoney, DateTime? updateDate = null)
        {
            Wallet wallet = WalletDAL.GetWalletByID(walletID);

            if (!string.IsNullOrWhiteSpace(newWalletName)) wallet.WalletName = newWalletName;
            if (!string.IsNullOrWhiteSpace(newWalletType)) wallet.WalletType = newWalletType;
            if (!string.IsNullOrWhiteSpace(newMoney)) wallet.Money = double.Parse(newMoney);
            if (updateDate.HasValue) wallet.UpdateDate = DateOnly.FromDateTime(updateDate.Value);
            WalletDAL.UpdateWallet(wallet);
        }

        public static List<Wallet> LoadWallets()
            => WalletDAL.GetAllWallets();
    }
}
