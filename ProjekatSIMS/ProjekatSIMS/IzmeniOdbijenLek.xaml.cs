using Model;
using ProjekatSIMS.Service;
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
   
    public partial class IzmeniOdbijenLek : Window
    {
        public LijekService LijekService { get; set; }
        public List<Lijek> Lijekovi { get; set; }
        public Lijek Lijek1 { get; set; }
        public List<Lijek> sviLekovi { get; set; }
        public IzmeniOdbijenLek(Lijek lijek)
        {
            InitializeComponent();
            this.DataContext = this;
            Lijek1 = lijek;
            LijekService = new LijekService();


            Lijekovi = new List<Lijek>();
            sviLekovi = new List<Lijek>();
            sviLekovi = LijekService.lijekRepoisitory.DobaviSve();
            Lijekovi = LijekService.DobaviPoStatusu(Model.OdobravanjeLekaEnum.Odobren);
            Sastojci.ItemsSource = Lijek1.Alergeni;
            AlternativniLekovi.ItemsSource = Lijek1.AlternativniLekovi;

        }

        private void obrisiSlicanLek(object sender, RoutedEventArgs e)
        {
            String s = (String)AlternativniLekovi.SelectedItems[0];
            foreach (String str in Lijek1.AlternativniLekovi)
            {
                if(str == s)
                {
                    Lijek1.AlternativniLekovi.Remove(str);
                }
            }
            AlternativniLekovi.ItemsSource = Lijek1.AlternativniLekovi;

        }

        private void dodajSlicanLek(object sender, RoutedEventArgs e)
        {
            String s = AlternativniLek.Text;
            Lijek1.AlternativniLekovi.Add(s);
            AlternativniLekovi.ItemsSource = Lijek1.AlternativniLekovi;
            
        }
        private void sacuvaj(object sender, RoutedEventArgs e)
        {
            foreach(Lijek l in sviLekovi)
            {
                if(l.NazivLeka == Lijek1.NazivLeka)
                {
                    l.Alergeni = Lijek1.Alergeni;
                    l.AlternativniLekovi = Lijek1.AlternativniLekovi;
                    l.Opis = Lijek1.Opis;
                    l.PorukaOdbaci = Lijek1.PorukaOdbaci;
                    break;
                }
            }
            LijekService.lijekRepoisitory.Sacuvaj(sviLekovi);
            sviLekovi = LijekService.lijekRepoisitory.DobaviSve();
        }
        private void dodajSastojak(object sender, RoutedEventArgs e)
        {
            String s = Alergen.Text;
            foreach (String str in Lijek1.Alergeni)
            {
                if (str == s)
                {
                    MessageBox.Show("Sastojak je vec unesen!");
                }
            }
            Lijek1.Alergeni.Add(s);
            Sastojci.ItemsSource = Lijek1.Alergeni;

        }
        private void obrisiSastojak(object sender, RoutedEventArgs e)
        {
            String s = (String)Sastojci.SelectedItems[0];
            foreach (String str in Lijek1.Alergeni)
            {
                if (str == s)
                {
                    Lijek1.Alergeni.Remove(str);
                }
            }
            Sastojci.ItemsSource = Lijek1.Alergeni;


        }
    }
}
