using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.DBModels
{
    public class parent_category
    {
        public string name { get; set; }
        public int? id_parent_category { get; set; }
        public int? color { get; set; }
        public int? id_wallet { get; set; }
    }
}
