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
    /// Interaction logic for Commitment.xaml
    /// </summary>
    public partial class Commitments : Page
    {
        public Commitments()
        {
            InitializeComponent();
            InitListOfCommitments();
            DoubleClickHandler();
        }

        private void InitListOfCommitments()
        {
            listOfCommitments.ItemsSource = CommitmentsVM.GetCommitments();
        }

        private void AddObligation(object sender, RoutedEventArgs e)
        {
            AddCommitment addCommitment = new AddCommitment(null);
            addCommitment.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć to zobowiązanie?", "Usuń zobowiązanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                CommitmentsVM.DeleteCommitment(listOfCommitments.SelectedIndex);
            }
        }

        private void DoubleClickHandler()
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            listOfCommitments.RowStyle = rowStyle;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Commitment)listOfCommitments.SelectedItem;
            AddCommitment addCommitment = new AddCommitment(row);
            addCommitment.Show();
        }
    }
}
