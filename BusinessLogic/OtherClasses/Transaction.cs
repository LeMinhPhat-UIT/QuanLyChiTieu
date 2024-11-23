using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class FinanceFlow
    {
        public static FinanceFlow Income = new FinanceFlow("Thu Nhập");
        public static FinanceFlow Expense = new FinanceFlow("Chi Tiêu");

        public string Name { get; set; }
        private FinanceFlow(string name)
            => Name = name ?? throw new ArgumentNullException(nameof(name), "Tên dòng tiền không được để trống.");
    }

    internal class Transaction
    {
        private static int _cnt = 0;

        public int Id { get; }
        public Catalog Catalog { get; set; }
        public FinanceFlow Flow { get; set; }
        public DateTime Date { get; set; }
        public double MoneyAmount { get; set; }
        public string Note { get; set; }

        public Transaction(DateTime date, double moneyAmount, string note)
        {
            // Kiểm tra đầu vào
            if (date == default) throw new ArgumentException("Ngày không hợp lệ", nameof(date));
            if (moneyAmount <= 0) throw new ArgumentException("Số tiền không hợp lệ", nameof(moneyAmount));
            if (string.IsNullOrWhiteSpace(note)) throw new ArgumentException("Ghi chú không hợp lệ", nameof(note));

            Id = ++_cnt;
            Date = date;
            MoneyAmount = moneyAmount;
            Note = note;
        }

        public Transaction SetAsIncome()
        {
            Flow = Flow = FinanceFlow.Income;
            return this;
        }

        public Transaction SetAsExpense()
        {
            Flow = FinanceFlow.Expense;
            return this;
        }
    }
}
