using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class ConstOrderVM
    {
        private static ObservableCollection<ConstOrder> list_of_constOrders;

        public static void InitListOfConstOrders()
        {
            list_of_constOrders = new ObservableCollection<ConstOrder>();
        }

        public static void AddNewConstOrder(ConstOrder constOrder)
        {
            list_of_constOrders.Add(constOrder);
        }

        public static ObservableCollection<ConstOrder> GetConstOrders()
        {
            return list_of_constOrders;
        }
    }
}
