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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Upravnik_Click(object sender, RoutedEventArgs e)
        {
            UpravnikWindow u = new UpravnikWindow();
            u.Show();
        }

        private void Doktor_Click(object sender, RoutedEventArgs e)
        {
            DoktorWindow d = new DoktorWindow();
            d.Show();
        }

        private void Sekretar_Click(object sender, RoutedEventArgs e)
        {
            SekretarWindow s = new SekretarWindow();
            s.Show();
        }

        private void Pacijent_Click(object sender, RoutedEventArgs e)
        {
            PacijentWindow p = new PacijentWindow();
            p.Show();
        }
    }
}
