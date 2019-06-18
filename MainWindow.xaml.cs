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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DBHelper.EstablishConnection();
            CategoryVM.InitList();

            Main.Content = new MainView();
            Consumo consumo = new Consumo();
            DataContext = new ConsumoViewModel(consumo);
           
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Raports();
        }

        private void Transactions_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Transactions();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Orders();
        }

        private void Commitment_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Commitment();
        }

        private void Payments_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Payments();
        }

        private void Currencys_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Currency();
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainView();
        }
    }

    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
        public string Titulo { get; private set; }
        public int Porcentagem { get; private set; }

        public Consumo()
        {
            Titulo = "";
            Porcentagem = CalcularPorcentagem();
        }

        private int CalcularPorcentagem()
        {
            return 47; //Calculo da porcentagem de consumo
        }
    }
}
