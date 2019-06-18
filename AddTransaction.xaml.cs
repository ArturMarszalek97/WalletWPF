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
using WalletWPF.Helpers;
using WalletWPF.ViewModels;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        private walletdbEntities2 db;
        private bool editStatus = false;
        private Transaction editTransaction = null;
        public AddTransaction(Transaction transaction)
        {
            InitializeComponent();
            if(transaction != null)
            {
                editStatus = true;
                InitTransactionToEdit(transaction);
            }
            db = new walletdbEntities2();
            ListPaymentMethod();
            InitCategoryComboBox();
        }

        private void InitTransactionToEdit(Transaction transaction)
        {
            editTransaction = transaction;
            nameOfTransaction.Text = transaction.name;
            if(transaction.amount < 0)
            {
                expenditure.IsChecked = true;
                amountOfTransaction.Text = (0 - transaction.amount).ToString();
            }
            else
            {
                income.IsChecked = true;
                amountOfTransaction.Text = transaction.amount.ToString();
            }

            CategoriesComboBox.SelectedItem = transaction.category;
            subCategoriesComboBox.SelectedItem = transaction.subcategory;
            paymentMethod.SelectedItem = transaction.paymentMethod;
            dateOfTransaction.SelectedDate = transaction.date_transaction;
        }

        private void ListPaymentMethod()
        {
            var items = PaymentMethodVM.GetListOfPaymentMethod();
            foreach (var item in items)
            {
                paymentMethod.Items.Add(item.name);
            }
        }

        private void InitCategoryComboBox()
        {
            var list = CategoryVM.AddCategoriesFromDB();

            foreach (var item in list)
            {
                CategoriesComboBox.Items.Add(item.name);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editStatus == true)
                {
                    TransactionVM.DeleteTransaction(editTransaction);
                    AccountHelper.number_of_transaction -= 1;
                }

                Transaction transaction = new Transaction();
                transaction.name = nameOfTransaction.Text;

                if (expenditure.IsChecked == true)
                {
                    transaction.amount = Convert.ToDouble("-" + amountOfTransaction.Text);
                }
                else
                {
                    transaction.amount = Convert.ToDouble(amountOfTransaction.Text);
                }

                

                transaction.category = CategoriesComboBox.SelectedItem.ToString();
                transaction.subcategory = subCategoriesComboBox.SelectedItem.ToString();

                transaction.date_transaction = dateOfTransaction.SelectedDate.Value.Date;
                transaction.paymentMethod = paymentMethod.SelectedItem.ToString();

                TransactionVM.AddNewTransaction(transaction);
                AccountHelper.number_of_transaction += 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Wpisane dane są niepoprawne!");
            }
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            subCategoriesComboBox.IsEnabled = true;
            subCategoriesComboBox.Items.Clear();
            var list_of_subcategories = SubcategoryVM.GetSubcategoriesFromDB();
            int idSelectedCategory = 0;
            var categories = CategoryVM.GetListOfCategories();

            foreach (var item in categories)
            {
                if(item.name == CategoriesComboBox.SelectedItem.ToString())
                {
                    idSelectedCategory = item.id_category;
                    break;
                }
            }

            foreach (var item in list_of_subcategories)
            {
                if(item.id_category == idSelectedCategory)
                {
                    subCategoriesComboBox.Items.Add(item.name);
                }
            }
        }

    }
}
