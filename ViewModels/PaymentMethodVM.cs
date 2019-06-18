using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletWPF.ViewModels
{
    public static class PaymentMethodVM
    {
        private static List<PaymentMethod> list_of_paymentMethod;
        private static walletdbEntities2 db = new walletdbEntities2();

        public static void AddNewPaymentMethod(PaymentMethod paymentMethod)
        {
            list_of_paymentMethod.Add(paymentMethod);
        }

        public static List<PaymentMethod> GetListOfPaymentMethod()
        {
            //list_of_paymentMethod = db.PaymentMethod.ToList();
            return list_of_paymentMethod;
        }

        internal static void InitList()
        {
            list_of_paymentMethod = new List<PaymentMethod>();
        }
    }
}
