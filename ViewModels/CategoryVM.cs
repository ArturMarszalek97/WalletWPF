using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class CategoryVM
    {
        private static List<Category> list_of_categories;
        private static walletdbEntities2 db = new walletdbEntities2();

        public static List<Category> AddCategoriesFromDB()
        {
            var item = db.Category.ToList();
            list_of_categories = item;

            return list_of_categories;
        }

        public static void InitList()
        {
            list_of_categories = new List<Category>();
        }

        public static List<Category> GetListOfCategories()
        {
            return list_of_categories;
        }
    }
}
