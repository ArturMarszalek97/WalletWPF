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
using WalletWPF.ViewModels;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for Raports.xaml
    /// </summary>
    public partial class Raports : Page
    {
        public Raports()
        {
            InitializeComponent();
            InitListOfMethodsPayment();
            DoubleClickHandler();

        }

        private void InitListOfMethodsPayment()
        {
            listOfPaymentMethods.ItemsSource = PaymentMethodVM.GetListOfPaymentMethod();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentMethod addPaymentMethod = new AddPaymentMethod(null);
            addPaymentMethod.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz ten środek płatności?", "Usuń środek płatności", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                PaymentMethodVM.DeletePaymentMethod(listOfPaymentMethods.SelectedIndex);
            }
        }

        private void DoubleClickHandler()
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            listOfPaymentMethods.RowStyle = rowStyle;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (PaymentMethod)listOfPaymentMethods.SelectedItem;
            AddPaymentMethod addPaymentMethod = new AddPaymentMethod(row);
            addPaymentMethod.Show();
        }
    }
}
