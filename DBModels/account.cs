using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.DBModels
{
    public class Account // wallet in database
    {
        public string wallet_name { get; set; }
        public int? id_wallet { get; set; }
        public int? balance { get; set; }
    }
}
