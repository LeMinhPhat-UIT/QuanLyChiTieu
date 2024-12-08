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

        public static List<Tuple<DateOnly, double>> GetDataByMonth(string moneyFlow, DateTime? startDate, DateTime? endDate)
        {
            var tempResult = StatisticDAL.GetDataByDate(moneyFlow, startDate, endDate)
                                          .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);

            List<Tuple<DateOnly, double>> result = new List<Tuple<DateOnly, double>>();
            for (int i = 1; i <= 31; i++)
            {
                try
                {
                    DateOnly date = DateOnly.FromDateTime(new DateTime(startDate?.Year ?? DateTime.Now.Year,
                                                                       startDate?.Month ?? DateTime.Now.Month, i));

                    if (tempResult.ContainsKey(date))
                    {
                        result.Add(new Tuple<DateOnly, double>(date, tempResult[date]));
                    }
                    else
                    {
                        result.Add(new Tuple<DateOnly, double>(date, 0));
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
            return result;
        }
    }
}
