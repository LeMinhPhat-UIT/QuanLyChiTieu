using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;
using System.Windows.Controls;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class FinanceService
    {
        public static Dictionary<int, Transaction> _allTransaction { get; } = new Dictionary<int, Transaction>();

        public static void Alert()
            => Console.WriteLine("the amount is lower than the need");

        public static void AddTransaction(int transactionID, int walletID)
        {
            /*
            Lấy dữ liệu 'giao dịch' và 'ví tiền' thông qua ID
            Nếu 'giao dịch' thuộc loại 'chi tiêu' thì tiền trong 'ví tiền' giảm, nếu 'thu nhập' thì tăng
            Bonus: nếu 'giao dịch' thuộc loại 'chi tiêu' mà 'ví tiền' không đủ tài chính thì thông báo không đủ và không thực hiện giao dịch
            */
        }

        public static void DeleteTransaction(List<int> transactionID)
        {
            /*
            Thực hiện xóa 'giao dịch' thông qua ID. (Truyền vào List là vì thông thường ta có thể chọn nhiều mục để xóa thay vì xóa từng mục)
            Nếu 'giao dịch' thuộc loại 'chi tiêu' thì 'ví tiền' chứa giao dịch sẽ tăng trị giá, ngược lại với 'thu nhập'
            */
        }

        public static void UpdateTransaction(int transactionID, string? newTransactionName, string? newMoney, string? newMoneyFlow, string? newCatalog, int? newWalletID, DateTime? date = null)
        {
            /*
            Thực hiện cập nhật giao dịch thông qua ID
            Thuộc tính nào bỏ trống thì sẽ không cập nhật
            */
        }

        public static void Load(ListView listView, List<Transaction> transactions)
        {
            /*
            Thực hiện Load danh sách các wallet lên ListView tương ứng. (hàm Load chỉ được gọi khi có sự cập nhật liên quan đến DataBase)
            
            DAL: Cần có hàm để lấy toàn bộ dữ liệu từ DB và Convert thành List<Transaction>
            */

            /*code:
            listView.ItemsSource = transactions;
            */
        }
    }
}
