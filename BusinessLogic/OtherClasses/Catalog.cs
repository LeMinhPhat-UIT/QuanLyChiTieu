﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.BusinessLogic.OtherClasses
{
    internal class Catalog
    {
        private static readonly Dictionary<string, Catalog> allCatalogs = new Dictionary<string, Catalog>();

        public string WalletName { get; private set; }
        private Catalog(string walletName)
        {
            WalletName = walletName;
            allCatalogs[WalletName] = this;
        }
        public static Catalog CreateCatalog(string WalletName)
            => allCatalogs.ContainsKey(WalletName) ? allCatalogs[WalletName] : new Catalog(WalletName);
        public static void DeleteCatalog(string WalletName)
            => allCatalogs.Remove(WalletName);
    }
}
