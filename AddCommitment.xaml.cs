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
    /// Interaction logic for AddCommitment.xaml
    /// </summary>
    public partial class AddCommitment : Window
    {
        private Commitment commitment = null;
        private bool editStatus = false;
        public AddCommitment(Commitment commitment)
        {
            InitializeComponent();
            if(commitment != null)
            {
                editStatus = true;
                this.commitment = commitment;
                InitCommitmentToEdit();
            }
        }

        private void InitCommitmentToEdit()
        {
            nameOfCommitment.Text = commitment.name;
            installmentOfCommitment.Text = commitment.amount.ToString();
            numberOfInstallment.Text = commitment.number_of_installments.ToString();
            dateOfCommitment.SelectedDate = commitment.date;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editStatus == true)
                {
                    CommitmentsVM.DeleteCommitment(this.commitment);
                }

                Commitment commitment = new Commitment
                {
                    name = nameOfCommitment.Text,
                    amount = Convert.ToDouble(installmentOfCommitment.Text),
                    number_of_installments = Convert.ToInt32(numberOfInstallment.Text),
                    date = dateOfCommitment.SelectedDate.Value
                };


                CommitmentsVM.AddNewCommitment(commitment);

                this.Close();
            }
            catch
            {
                MessageBox.Show("Wpisane dane są niepoprawne!");
            }
            
        }
    }
}
