using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Helpers
{

    internal class DateHelper
    {
        private static int[] _dayOfMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public static bool isValid(string date)
        {
            bool isValid = DateTime.TryParse(date, out DateTime validDate);
            return isValid;
        }

        public static bool isLeapYear(int year)
            => (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));

        private static void UpdateDaysInMonth(int year)
        {
            if (isLeapYear(year))
                _dayOfMonth[1] = 29;
            else
                _dayOfMonth[1] = 28;
        }

        public static bool isBetween(DateTime date, DateTime start, DateTime end)
            => date>=start && date<=end;

        public static DateTime GetCurrentDate()
            => DateTime.Now;

        public static TimeSpan GetDayBetween(DateTime start, DateTime end)
            => end - start;

        public static int GetNumberOfDaysInMonth(int year, int month) 
        {
            if (isLeapYear(year))
                UpdateDaysInMonth(year);
            return _dayOfMonth[month-1];
        }
    }
}
