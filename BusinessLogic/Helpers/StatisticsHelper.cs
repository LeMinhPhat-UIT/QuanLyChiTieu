using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.BusinessLogic.Services;
using QuanLyChiTieu.BusinessLogic.SupportedClasses;

namespace QuanLyChiTieu.BusinessLogic.Helpers
{
    public class StatisticsHelper
    {
        //public static double GetIncome(DateTime startDate, DateTime endDate)
        //{
        //    /*
        //    Lấy tất cả các 'giao dịch' thuộc loại 'thu nhập' từ ngày A đến B và tính tổng 

        //    DAL: Cần có hàm để lấy 'giao dịch' thuộc loại 'thu nhập' từ ngày A đến ngày B
        //    */
        //}

        //public static double GetExpense(DateTime startDate, DateTime endDate)
        //{
        //    /*
        //    Lấy tất cả các 'giao dịch' thuộc loại 'chi tiêu' từ ngày A đến B và tính tổng

        //    DAL: Cần có hàm để lấy 'giao dịch' thuộc loại 'chi tiêu' từ ngày A đến ngày B
        //    */

        //}

        public static SeriesCollection CreateChart(string moneyFlow, DateTime startDate, DateTime endDate)
        {
            /*
            Lấy dữ liệu theo 'dòng tiền' từ ngày A đến ngày B 
            */
            SeriesCollection chart = new SeriesCollection();
            return chart;
        }
    }
}
