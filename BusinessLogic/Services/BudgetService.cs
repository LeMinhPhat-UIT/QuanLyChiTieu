using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class BudgetService
    {
        public static Dictionary<int, Wallet> _allWallets { get; } = new Dictionary<int, Wallet>();

        public static void CreateWallet(string walletName, string type, string money, DateTime updateDate)
        {
            /*
            Tạo một 'ví tiền' mới
            Trả về 'ví tiền' vừa tạo

            (các giá trị đầu vào được lấy từ các TextBox ở phần GUI, riêng ID thì mặc định tự tạo khi thêm vào)
            */
        }

        public static void DeleteWallet(List<int> walletID) 
        {
            /*
            Xóa một 'ví tiền' thông qua các ID 

            (ID sẽ được lấy từ Item được chọn trong ListView. Có thể dùng ListView.SelectedItem)
            */   
        }

        public static void UpdateWallet(int walletID, string? newWalletName, string? newWalletType, string? newMoney, DateTime? updateDate = null)
        {
            /*
            Cập nhật 'ví tiền' thông qua ID
            Thuộc tính nào trống thì không cập nhật
            */
        }

        public static void Load(ListView listView, List<Wallet> wallets)
        {
            /*
            Thực hiện Load danh sách các wallet lên ListView tương ứng. (hàm Load chỉ được gọi khi có sự cập nhật liên quan tới DataBase)

            DAL: Cần có hàm để lấy toàn bộ dữ liệu từ DB và Convert thành List<Wallet>
            */

            /*code:
            listView.ItemsSource = wallets;
            */
        }
    }
}
