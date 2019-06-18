using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WalletWPF.ViewModels;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for AddPaymentMethod.xaml
    /// </summary>
    public partial class AddPaymentMethod : Window
    {
        private bool editStatus = false;
        private PaymentMethod paymentMethod = null;
        public AddPaymentMethod(PaymentMethod paymentMethod)
        {
            InitializeComponent();
            if(paymentMethod != null)
            {
                editStatus = true;
                this.paymentMethod = paymentMethod;
                InitPaymentMethodToEdit();
            }
        }

        private void InitPaymentMethodToEdit()
        {
            nameOfPaymentMethod.Text = paymentMethod.name;
            balanceOfPaymentMethod.Text = paymentMethod.balance.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(editStatus == true)
            {
                PaymentMethodVM.DeletePaymentMethod(this.paymentMethod);
            }

            PaymentMethod paymentMethod = new PaymentMethod
            {
                name = nameOfPaymentMethod.Text,
                balance = Convert.ToDouble(balanceOfPaymentMethod.Text)
            };

            PaymentMethodVM.AddNewPaymentMethod(paymentMethod);

            this.Close();
        }
    }
}
