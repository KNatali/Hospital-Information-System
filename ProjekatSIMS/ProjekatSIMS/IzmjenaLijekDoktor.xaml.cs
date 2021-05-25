using Controller;
using Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class IzmjenaLijekDoktor : Page
    {
        private LijekRepository lijekRepository = new LijekRepository();
        private IzmjenaLijekaDoktorController izmjenaLijekaController = new IzmjenaLijekaDoktorController();
        private CuvanjeIzmjenaLijekaDoktorController cuvanjeIzmjenaLijekaDoktorController = new CuvanjeIzmjenaLijekaDoktorController();
        public Lijek lijek { get; set; }
        public List<Lijek> Lijekovi { get; set; }
        public IzmjenaLijekDoktor(Lijek l)
        {
            InitializeComponent();
            this.DataContext = this;
            lijek = l;
            Naziv.Text = l.NazivLeka;
            Opis.Text = l.Opis;
            Sastojci.ItemsSource = l.Alergeni;
            AlternativniLijekovi.ItemsSource = l.AlternativniLekovi;
            Lijekovi = lijekRepository.DobaviSve();
            SviLijekovi.ItemsSource = Lijekovi;
        }



        private void DodajSastojak(object sender, RoutedEventArgs e)
        {
            String noviSastojak = Sastojak.Text;
            Sastojci.ItemsSource = izmjenaLijekaController.DodavanjeSastojka(noviSastojak, lijek);
        }

        private void DodajAlternativniLijek(object sender, RoutedEventArgs e)
        {

            Lijek izabraniLijek = (Lijek)SviLijekovi.SelectedItem;
            String noviAlternativniLijek = izabraniLijek.NazivLeka;

            AlternativniLijekovi.ItemsSource = izmjenaLijekaController.DodavanjeALternativnihLijekova(noviAlternativniLijek, lijek);

        }

        private void SacuvajPromjene(object sender, RoutedEventArgs e)
        {
            Lijek l = new Lijek();
            l.NazivLeka = Naziv.Text;
            l.Opis = Opis.Text;
            l.Status = lijek.Status;

            cuvanjeIzmjenaLijekaDoktorController.SacuvajIzmjene(l, Sastojci.Items, AlternativniLijekovi.Items);
            this.NavigationService.GoBack();

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {

            this.NavigationService.GoBack();

        }
    }
}
