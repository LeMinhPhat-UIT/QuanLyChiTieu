using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatisticBLL
    {
        public static List<Tuple<DateOnly, double>> GetDataByDate(string moneyFlow, DateTime? startDate, DateTime? endDate)
            => StatisticDAL.GetDataByDate(moneyFlow, startDate, endDate);

        public static List<Tuple<string, double>> GetDataByCatalog(string catalogName, DateTime startDate, DateTime endDate)
            => StatisticDAL.GetDataByCatalog(catalogName, startDate, endDate);

        public static List<DateOnly> GetDateHasData(DateTime startDate, DateTime endDate)
            => StatisticDAL.GetDateHasData(startDate, endDate);
    }
}
