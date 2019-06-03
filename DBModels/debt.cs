using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.DBModels
{
    public class debt
    {
        public string name { get; set; }
        public string comment { get; set; }
        public string creditor { get; set; }
        public int? id_debt { get; set; }
        public int? id_subcategory { get; set; }
        public float amount { get; set; }
        public DateTime? date { get; set; }
    }
}
