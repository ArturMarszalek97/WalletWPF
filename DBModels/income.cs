﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.DBModels
{
    public class Income
    {
        public string name { get; set; }
        public string comment { get; set; }
        public int? id_income { get; set; }
        public int? id_subcategory { get; set; }
        public float amount { get; set; }
        public DateTime? date { get; set; }
    }
}
