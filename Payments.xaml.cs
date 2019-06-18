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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WalletWPF.Helpers;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : Page
    {
        public Payments()
        {
            InitializeComponent();
            InitComponents();
        }

        private void InitComponents()
        {
            balance_of_credit_card.Text = AccountHelper.balance_of_credit_card.ToString();
            account_balance.Text = AccountHelper.account_balance.ToString();
            number_of_transaction.Text = AccountHelper.number_of_transaction.ToString();
        }
    }
}
