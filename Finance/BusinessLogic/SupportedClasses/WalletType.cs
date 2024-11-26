using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.BusinessLogic.Helpers;
using QuanLyChiTieu.BusinessLogic.Services;

namespace QuanLyChiTieu.BusinessLogic.SupportedClasses
{
    public class WalletType
    {
        public static Dictionary<string, WalletType> _allWalletTypes { get; } = new Dictionary<string, WalletType>();

        public string Name { get; set; }

        private WalletType(string name)
        {
            Name = name;
            _allWalletTypes[name] = this;
        }

        public static WalletType Cash { get; }
        public static WalletType DebitCard { get; }
        public static WalletType CreditCard { get; }
        public static WalletType VirtualAccount { get; }
        public static WalletType Investment { get; }
        public static WalletType Debt { get; }
        public static WalletType MyDebt { get; }
        static WalletType()
        {
            Cash = new WalletType("Tiền Mặt");
            DebitCard = new WalletType("Thẻ Ghi Nợ");
            CreditCard = new WalletType("Thẻ Tín Dụng");
            VirtualAccount = new WalletType("Tài Khoản Ảo");
            Investment = new WalletType("Đầu Tư");
            Debt = new WalletType("Nợ Tôi");
            MyDebt = new WalletType("Tôi Nợ");
        }
    }
}
