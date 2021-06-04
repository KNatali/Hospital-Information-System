using Model;
using ProjekatSIMS.Controller;
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

namespace ProjekatSIMS.UpravnikWindows
{
    
    public partial class IzmeniLek : Page
    {
        public Lijek LijekZaIzmenu { get; set; }
        public List<Lijek> Lekovi { get; set; }
        public List<String> LekoviZaDodavanje { get; set; }
        public LijekController lijekController { get; set; }
        public ObservableCollection<String> slicniLekovi { get; set; }
        public ObservableCollection<String> sastojci { get; set; }
        public IzmeniLek(Lijek lijekZaIzmenu)
        {
            InitializeComponent();
            this.DataContext = this;
            LijekZaIzmenu = lijekZaIzmenu;
            lijekController = new LijekController();
            Lekovi = lijekController.lijekService.DobaviPoStatusu(Model.OdobravanjeLekaEnum.Odobren);

            LekoviZaDodavanje = new List<String>();
            foreach (Lijek l in Lekovi)
            {
                LekoviZaDodavanje.Add(l.NazivLeka);
            }
            lekoviZaDodavanje.ItemsSource = LekoviZaDodavanje;
            slicniLekovi = new ObservableCollection<String>();

            sastojci = new ObservableCollection<String>();
            if(LijekZaIzmenu.Alergeni != null)
            {
                foreach (String s in LijekZaIzmenu.Alergeni)
                {
                    sastojci.Add(s);
                }
            }
            if (LijekZaIzmenu.AlternativniLekovi != null)
            {
                foreach (String s in LijekZaIzmenu.AlternativniLekovi)
                {
                    slicniLekovi.Add(s);
                }
            }
            Sastojci.ItemsSource = sastojci;
            SlicniLekovi.ItemsSource = slicniLekovi;




        }
        private void DodajSlicanLek(object sender, RoutedEventArgs e)
        {
            
            String noviLek = (String)lekoviZaDodavanje.SelectedItem;

            if(lijekController.DaLiJeUnetStringUKolekciju(noviLek, slicniLekovi))
            {
                MessageBox.Show("Dati lek je vec unet kao slican lek!");
            }
            else
            {
                slicniLekovi.Add(noviLek);
                SlicniLekovi.ItemsSource = slicniLekovi;
            }
            

        }
        private void DodajSastojak(object sender, RoutedEventArgs e)
        {
            String sastojak = Sastojak.Text;
            if (lijekController.DaLiJeUnetStringUKolekciju(sastojak, sastojci))
            {
                MessageBox.Show("Dati sastojak je vec unet!");
            }
            else
            {
                sastojci.Add(sastojak);
                Sastojci.ItemsSource = sastojci;
            }
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            Upravnik uw = (Upravnik)Window.GetWindow(this);
            uw.UpravnikFrame.Content = new PregledLekova();

        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if(lijekController.IzmenaLeka(LijekZaIzmenu.NazivLeka, Naziv.Text, Opis.Text, slicniLekovi, sastojci) == false)
            {
                MessageBox.Show("Vec postoji lek sa unetim nazivom!");

            }
            else
            {
                MessageBox.Show("Uspesno ste dodali lek!");
                Upravnik uw = (Upravnik)Window.GetWindow(this);
                uw.UpravnikFrame.Content = new PregledLekova();
            }
        }
    }
}
