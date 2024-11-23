using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.OtherClasses;

namespace QuanLyChiTieu.BusinessLogic.Services
{
    internal class BudgetService
    {
        public static Dictionary<Catalog, (double Item1, double Item2)> _budgetOfEachCatalog = new Dictionary<Catalog, (double, double)>();
        public static double totalBudget=0;

        public void SetBudget(Catalog catalog, double money) 
        {
            _budgetOfEachCatalog.Add(catalog, (money, money));
            totalBudget += money;
        }

        public void UpdateBudget(Catalog catalog, double money) 
        {
            totalBudget -= _budgetOfEachCatalog[catalog].Item1;
            _budgetOfEachCatalog[catalog] = (money, money);
            totalBudget += money;
        }

        public void DeleteBudget(Catalog catalog) 
        {
            totalBudget -= _budgetOfEachCatalog[catalog].Item1;
            _budgetOfEachCatalog.Remove(catalog);
        }

        public (double, double) GetRemainingBudget(Catalog? catalog = null) 
        {
            if(catalog == null)
            {
                double remaining = _budgetOfEachCatalog.Select(x => x.Value.Item2).ToList().Sum();
                return (remaining, 100*remaining/totalBudget);
            }
            else
                return (_budgetOfEachCatalog[catalog].Item2, 100*_budgetOfEachCatalog[catalog].Item2/ _budgetOfEachCatalog[catalog].Item1);
        }
    }
}
