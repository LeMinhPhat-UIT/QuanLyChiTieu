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
            /*
            Tạo một 'ví tiền' mới
            Trả về 'ví tiền' vừa tạo
            */
        }

        public static void DeleteWallet(int walletID) 
        {
            /*
            Xóa một 'ví tiền' thông qua ID 
            */   
        }

        public static void UpdateWallet(int walletID, string? newWalletName, string? newWalletType, string? newMoney, DateTime? updateDate = null)
        {
            /*
            Cập nhật 'ví tiền' thông qua ID
            Thuộc tính nào trống thì không cập nhật
            */
        }

    }
}
