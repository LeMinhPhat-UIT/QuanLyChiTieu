using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class Catalog
    {
        private static readonly Dictionary<string, Catalog> allCatalogs = new Dictionary<string, Catalog>();

        public string Name { get; private set; }
        private Catalog(string name)
        {
            Name = name;
            allCatalogs[name] = this;
        }
        public static Catalog CreateCatalog(string name)
            => allCatalogs.ContainsKey(name) ? allCatalogs[name] : new Catalog(name);
        public static void DeleteCatalog(string name)
            => allCatalogs.Remove(name);
    }
}
