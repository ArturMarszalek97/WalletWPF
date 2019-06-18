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
        public AddTransaction()
        {
            InitializeComponent();
            db = new walletdbEntities2();
            ListPaymentMethod();
            InitCategoryComboBox();
        }

        public List<PaymentMethod> PaymentMethods { get; set; }
        private void ListPaymentMethod()
        {  
            var item = db.PaymentMethod.ToList();
            PaymentMethods = item;
            DataContext = PaymentMethods;
        }

        private void InitCategoryComboBox()
        {
            var list = CategoryVM.AddCategoriesFromDB();

            foreach (var item in list)
            {
                CategoriesComboBox.Items.Add(item.name);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = paymentMethod.SelectedItem as PaymentMethod;
            System.Windows.MessageBox.Show(item.name.ToString());

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.name = nameOfTransaction.Text;

            if(expenditure.IsChecked == true)
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

            this.Close();
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
