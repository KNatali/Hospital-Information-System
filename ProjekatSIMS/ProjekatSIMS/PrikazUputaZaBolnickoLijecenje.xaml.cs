using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    /// Interaction logic for PrikazUputaZaBolnickoLijecenje.xaml
    /// </summary>
    public partial class PrikazUputaZaBolnickoLijecenje : Page
    {
        private UputBolnickoLijecenjeRepository uputBolnickoLiejecenjeRepository = new UputBolnickoLijecenjeRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        private Pacijent pacijent = new Pacijent();
        public PrikazUputaZaBolnickoLijecenje(Pacijent p)
        {
            InitializeComponent();
            pacijent = p;
           
            ZdravsteniKarton karton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);


            Uputi.ItemsSource = karton.UputiZaBolnickoLijecenje;
        }

        private void ProduziTrajanje(object sender, RoutedEventArgs e)
        {
            UputBolnickoLijecenje izabraniUput = (UputBolnickoLijecenje)Uputi.SelectedItem;
            ProduziBolnickoLijecenje p = new ProduziBolnickoLijecenje(izabraniUput,pacijent);
            this.NavigationService.Navigate(p);
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            this.NavigationService.Navigate(z);
        }

    }
}
