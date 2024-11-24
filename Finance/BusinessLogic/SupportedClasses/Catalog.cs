using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class Catalog
    {
        public static Dictionary<string, Catalog> _allCatalogs = new Dictionary<string, Catalog>();

        public string Name { get; private set; }
        public MoneyFlow MoneyFlow { get; private set; }

        private Catalog(string name, string moneyFlow)
        {
            Name = name;
            MoneyFlow = MoneyFlow._allMoneyFlows[moneyFlow];
            _allCatalogs.Add(name, this);
        }

        public static Catalog CreateCatalog(string name, string moneyFlow)
            => _allCatalogs.ContainsKey(name) ? _allCatalogs[name] : new Catalog(name, moneyFlow);
        
        public static void DeleteCatalog(string name)
            => _allCatalogs.Remove(name);
    }
}
