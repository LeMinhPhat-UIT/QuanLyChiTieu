using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class StatisticReport
    {
        public double Total { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public StatisticReport(double total=0, double mean=0, double median=0, double min=0, double max=0)
        {
            Total = total;
            Mean = mean;
            Median = median;
            Min = min;
            Max = max;
        }
    }
}
