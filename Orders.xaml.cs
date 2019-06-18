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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            InitListOfConstOrders();
            DoubleClickHandler();
        }

        private void InitListOfConstOrders()
        {
            listOfConstOrders.ItemsSource = ConstOrderVM.GetConstOrders();
        }

        private void AddConstOrder(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder(null);
            addOrder.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć to zlecenie stałe?", "Usuń zlecenie stałe", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ConstOrderVM.DeleteConstOrder(listOfConstOrders.SelectedIndex);
            }
        }

        private void DoubleClickHandler()
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            listOfConstOrders.RowStyle = rowStyle;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (ConstOrder)listOfConstOrders.SelectedItem;
            AddOrder addConstOrder = new AddOrder(row);
            addConstOrder.Show();
        }
    }
}
