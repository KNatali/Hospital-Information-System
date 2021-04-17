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
    /// Interaction logic for DinamickaOpremaWindow.xaml
    /// </summary>
    public partial class DinamickaOpremaWindow : Window
    {
        public DinamickaOpremaWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Prostorija> prostorije = new List<Prostorija>();
            List<Inventar> oprema = new List<Inventar>();



            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            prostorije = cuvanje.UcitajProstorije();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
          
        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
