﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

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

        public static Catalog CreateCatalog(string name, string moneyFlow)
        {
            /*
            Tạo catalog mới với name và dòng tiền 
            */
        }

        public static void DeleteCatalog(string name) 
        {
            /*
            Xóa catalog thông qua tên 
            */
        }

        public static List<Transaction> GetAllDataByFlow(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            MoneyFlow transactionMoneyFlow = MoneyFlow._allMoneyFlows[moneyFlow];
            return _allTransaction.Values.Where(x => x.TransactionMoneyFlow == transactionMoneyFlow && DateHelper.isBetween(x.TransactionDate, startDate, endDate))
                                     .ToList();
        }
    }
}
