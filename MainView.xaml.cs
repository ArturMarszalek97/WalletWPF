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

namespace WalletWPF
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            InitComponents();

            Consumo consumo = new Consumo();
            DataContext = new ConsumoViewModel(consumo);
        }

        private void InitComponents()
        {
            balance_of_credit_card.Text = AccountHelper.balance_of_credit_card.ToString();
            account_balance.Text = AccountHelper.account_balance.ToString();
            number_of_transaction.Text = AccountHelper.number_of_transaction.ToString();
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
                Titulo = "Limit karty kredytowej: 5000 zł";
                Porcentagem = CalcularPorcentagem();
            }

            private int CalcularPorcentagem()
            {
                return 47; //Calculo da porcentagem de consumo
            }
        }
    }
}
