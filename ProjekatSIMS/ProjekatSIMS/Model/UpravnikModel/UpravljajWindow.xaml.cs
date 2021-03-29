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

namespace ProjekatSIMS.Model.UpravnikModel
{
    
    public partial class UpravljajWindow : Window
    {
        public UpravljajWindow()
        {
            InitializeComponent();
        }
        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
           KreirajWindow kw = new KreirajWindow();
           kw.Show();
        }
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
           IzmeniWindow iw = new IzmeniWindow();
            iw.Show();
        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            ObrisiWindow ow = new ObrisiWindow();
            ow.Show();
        }
    }
}
