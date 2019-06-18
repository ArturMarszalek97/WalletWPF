using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class PaymentMethodVM
    {
        private static ObservableCollection<PaymentMethod> list_of_paymentMethod;
        private static walletdbEntities2 db = new walletdbEntities2();

        public static void AddNewPaymentMethod(PaymentMethod paymentMethod)
        {
            list_of_paymentMethod.Add(paymentMethod);
        }

        public static ObservableCollection<PaymentMethod> GetListOfPaymentMethod()
        {
            //list_of_paymentMethod = db.PaymentMethod.ToList();
            return list_of_paymentMethod;
        }

        internal static void InitList()
        {
            list_of_paymentMethod = new ObservableCollection<PaymentMethod>();
        }

        internal static void DeletePaymentMethod(int selectedIndex)
        {
            list_of_paymentMethod.RemoveAt(selectedIndex);
        }

        internal static void DeletePaymentMethod(PaymentMethod paymentMethod)
        {
            list_of_paymentMethod.Remove(paymentMethod);
        }
    }
}
