using Model;
using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class IzmenaLekaUpravnik : Page
    {
        public LijekService LijekService = new LijekService();
        public List<Lijek> lekovi = new List<Lijek>();
        public ObservableCollection<String> SastojciLeka = new ObservableCollection<String>();
        public ObservableCollection<String> Alternativni = new ObservableCollection<String>();
        public IzmenaLekaUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            lekovi = LijekService.lijekRepoisitory.DobaviSve();
            Lijek lijekZaIzmenu = (Lijek)Lekovi.SelectedItem;

            Sastojci.ItemsSource = SastojciLeka;
            AlternativniLekovi.ItemsSource = Alternativni;

        }
        private void dodajSastojak(object sender, RoutedEventArgs e)
        {

        }
        private void obrisiSastojak(object sender, RoutedEventArgs e)
        {

        }
        private void dodajSlicanLek(object sender, RoutedEventArgs e)
        {

        }
        private void obrisiSlicanLek(object sender, RoutedEventArgs e)
        {

        }
        private void sacuvaj(object sender, RoutedEventArgs e)
        {

        }
    }
}
