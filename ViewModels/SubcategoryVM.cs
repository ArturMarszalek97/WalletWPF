using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class SubcategoryVM
    {
        private static List<Subcategory> list_of_subcategories;
        private static walletdbEntities2 db = new walletdbEntities2();

        public static List<Subcategory> GetSubcategoriesFromDB()
        {
            list_of_subcategories = db.Subcategory.ToList();

            return list_of_subcategories;
        }
    }
}
