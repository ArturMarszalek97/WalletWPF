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
        }

        private void InitListOfCommitments()
        {
            listOfCommitments.ItemsSource = CommitmentsVM.GetCommitments();
        }

        private void AddObligation(object sender, RoutedEventArgs e)
        {
            AddCommitment addCommitment = new AddCommitment();
            addCommitment.Show();
        }
    }
}
