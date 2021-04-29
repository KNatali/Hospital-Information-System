using Model;
using Newtonsoft.Json;
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
    /// Interaction logic for IzmjenaLijekDoktor.xaml
    /// </summary>
    public partial class IzmjenaLijekDoktor : Page
    {

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

            //dobavljanje svih iljekova
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                Lijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            SviLijekovi.ItemsSource = Lijekovi;
        }

       

        private void DodajSastojak(object sender, RoutedEventArgs e)
        {
            String noviSastojak = Sastojak.Text;
            if (noviSastojak.Length > 1)
            {
                if (lijek.Alergeni == null)
                    lijek.Alergeni = new List<String>();
                lijek.Alergeni.Add(noviSastojak);
            }

            //KKAO DA SE OVO POPRAVI????????????
            List<String> sastojciNovi = new List<String>();
            foreach (String s in lijek.Alergeni)
                sastojciNovi.Add(s);
            Sastojci.ItemsSource = sastojciNovi;



        }

        private void DodajAlternativniLijek(object sender, RoutedEventArgs e)
        {

        }

        private void SacuvajPromjene(object sender, RoutedEventArgs e)
        {
            Lijek l = new Lijek();
            l.NazivLeka = Naziv.Text;
            l.Opis = Opis.Text;
            l.Status = lijek.Status;
            l.Alergeni = new List<String>();
           foreach(String i in Sastojci.Items)
            {
                l.Alergeni.Add(i);
                
            }
            
            //DIO ZA DODAVANJE ALTERNATIVNIH ???????????
            foreach(Lijek li in Lijekovi)
            {
                if (li.NazivLeka == l.NazivLeka)
                {
                    li.Opis = l.Opis;
                    li.Alergeni = l.Alergeni;
                    li.AlternativniLekovi = l.AlternativniLekovi;
                }
                   
            }
            //upisivanje u fajl
            string newJson = JsonConvert.SerializeObject(Lijekovi);
            File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);

            this.NavigationService.GoBack();

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {

        }
    }
}
