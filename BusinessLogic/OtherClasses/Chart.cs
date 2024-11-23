using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class Chart
    {
        private static int cnt = 0;
        public double[] SummaryStatistic; //total, mean, median, min, max
        public int Id { get; private set; }
        public Dictionary<Catalog, (double Cost, double Percent)> Data = new Dictionary<Catalog, (double Cost, double Percent)>();
        
        public Chart()
        {
            Id = ++cnt;
        }

        public void AddData(Catalog catalog, double cost, double percent)
        {
            if (Data.ContainsKey(catalog))
            {
                var currentData = Data[catalog];
                currentData.Cost += cost;
                currentData.Percent = percent;
                Data[catalog] = currentData;
            }
            else
                Data[catalog] = (cost, percent);
        }
    }
}
