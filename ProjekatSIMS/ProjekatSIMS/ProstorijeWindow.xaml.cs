using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for ProstorijeWindow.xaml
    /// </summary>
    public partial class ProstorijeWindow : Window
    {
        public ProstorijeWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            Prostorija prostorija = new Prostorija();
            prostorija.id = Id.Text;
            prostorija.sprat = Convert.ToInt32(Sprat.Text);
            





        }
        private void izmeni(object sender, RoutedEventArgs e)
        {

        }
        private void obrisi(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
