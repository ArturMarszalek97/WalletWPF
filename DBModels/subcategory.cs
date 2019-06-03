using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.DBModels
{
    public class subcategory
    {
        public string name { get; set; }
        public int? id_subcategory { get; set; }
        public int? id_parent_category { get; set; }
    }
}
