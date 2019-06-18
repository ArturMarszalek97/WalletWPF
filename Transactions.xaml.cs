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
using WalletWPF.ViewModels;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        public Transactions()
        {
            InitializeComponent();
            DoubleClickHandler();
            listOfTransaction.ItemsSource = TransactionVM.GetTransactions();
            InitComponents();
        }

        private void GetPartOfList()
        {

        }

        private void InitComponents()
        {
            balance_of_credit_card.Text = AccountHelper.balance_of_credit_card.ToString();
            account_balance.Text = AccountHelper.account_balance.ToString();
            number_of_transaction.Text = AccountHelper.number_of_transaction.ToString();
        }

        private void addtransactions(object sender, RoutedEventArgs e)
        {
            AddTransaction addTransaction = new AddTransaction(null);
            addTransaction.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć tę transakcję?", "Usuń transakcję", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                TransactionVM.DeleteTransaction(listOfTransaction.SelectedIndex);
                AccountHelper.number_of_transaction -= 1;
            }
        }

        private void DoubleClickHandler()
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            listOfTransaction.RowStyle = rowStyle;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Transaction)listOfTransaction.SelectedItem;
            AddTransaction addTransaction = new AddTransaction(row);
            addTransaction.Show();
        }
    }
}
