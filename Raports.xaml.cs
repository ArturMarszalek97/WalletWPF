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

            Raportss raportss = new Raportss("test");
            List<Raportss> raportsses = new List<Raportss>();

            raportsses.Add(raportss);
            bloki.ItemsSource = raportsses;
            //bloki.DataContext = new RaportsViewModel(raportss);
        }

        internal class Raportss
        {
            public string name { get; set; }
            public int count { get; set; }

            public Raportss(string name)
            {
                this.name = name;
                count = rnd();
            }

            private int rnd()
            {
                Random random = new Random();
                return random.Next(0, 100);
            }
        }

    }
}
