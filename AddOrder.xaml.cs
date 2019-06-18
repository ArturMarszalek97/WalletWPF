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
using WalletWPF.DBModels.Enums;
using WalletWPF.ViewModels;

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private bool editStatus = false;
        private ConstOrder constOrder = null;
        public AddOrder(ConstOrder constOrder)
        {
            InitializeComponent();
            this.constOrder = constOrder;
            InitCategoryComboBox();
            InitPeriodsToComboBox();
            if(constOrder != null)
            {
                editStatus = true;
                InitConstOrderToEdit(constOrder);
            }
        }

        private void InitConstOrderToEdit(ConstOrder constOrder)
        {
            nameOfConstOrder.Text = constOrder.name;
            amountOfConstOrder.Text = constOrder.amount.ToString();
            categoriesOfConstOrder.SelectedItem = constOrder.category;
            subcategoriesOfConstOrder.SelectedItem = constOrder.subcategory;
            periodicityOfConstOrder.SelectedItem = constOrder.period;
        }

        private void InitCategoryComboBox()
        {
            var list = CategoryVM.AddCategoriesFromDB();

            foreach (var item in list)
            {
                categoriesOfConstOrder.Items.Add(item.name);
            }
        }

        private void InitPeriodsToComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Periods)))
            {
                periodicityOfConstOrder.Items.Add(item);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editStatus == true)
                {
                    ConstOrderVM.DeleteConstOrder(this.constOrder);
                }

                ConstOrder constOrder = new ConstOrder();
                constOrder.name = nameOfConstOrder.Text;
                constOrder.amount = Convert.ToDouble(amountOfConstOrder.Text);
                constOrder.category = categoriesOfConstOrder.SelectedItem.ToString();
                constOrder.subcategory = subcategoriesOfConstOrder.SelectedItem.ToString();
                constOrder.period = periodicityOfConstOrder.SelectedItem.ToString();

                ConstOrderVM.InitListOfConstOrders();
                ConstOrderVM.AddNewConstOrder(constOrder);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Wpisane dane są niepoprawne!");
            }
        }

        private void CategoriesOfConstOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            subcategoriesOfConstOrder.IsEnabled = true;
            subcategoriesOfConstOrder.Items.Clear();
            var list_of_subcategories = SubcategoryVM.GetSubcategoriesFromDB();
            int idSelectedCategory = 0;
            var categories = CategoryVM.GetListOfCategories();

            foreach (var item in categories)
            {
                if (item.name == categoriesOfConstOrder.SelectedItem.ToString())
                {
                    idSelectedCategory = item.id_category;
                    break;
                }
            }

            foreach (var item in list_of_subcategories)
            {
                if (item.id_category == idSelectedCategory)
                {
                    subcategoriesOfConstOrder.Items.Add(item.name);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
