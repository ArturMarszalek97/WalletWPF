using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {

        public AddTransaction()
        {
            ListPaymentMethod();
            InitializeComponent();
        }

        public List<PaymentMethod> PaymentMethods { get; set; }
        private void ListPaymentMethod()
        {
            walletdbEntities1 dc = new walletdbEntities1();
            var item = dc.PaymentMethod.ToList();
            PaymentMethods = item;
            DataContext = PaymentMethods;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = combobox1.SelectedItem as PaymentMethod;
            MessageBox.Show(item.name.ToString());

        }
    }
}
