using Model;
using Repository;
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
    public partial class PretraziPacijenteSekretarWindow : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pac { get; set; }
        public PretraziPacijenteSekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = fajl.DobaviPacijente();
        }
        private void Pretraga(object sender, RoutedEventArgs e)
        {
            //kada unese ime i prezime pretrazice i izbaciti tabelu sa tim pacijentima u tabelapacijenata prozoru
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            /*this.Close();
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(ime, prezime);
            pp.Show();*/
            dataGridPacijenti.Visibility = Visibility.Visible;
            List<Pacijent> Pacijenti1 = new List<Pacijent>();
            List<Pacijent> ListaPacijenata = new List<Pacijent>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            ListaPacijenata = fajl.DobaviPacijente();
            foreach (Pacijent p in ListaPacijenata)
            {
                if (p.Ime == ime && p.Prezime == prezime)
                {
                    Pacijenti1.Add(p);
                    pac = p;
                }
            }
            Labela.Visibility = Visibility.Visible;
            dataGridPacijenti.ItemsSource = Pacijenti1;  // refresh tabele
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Prikaz(object sender, RoutedEventArgs e)
        {
            dataGridPacijenti.Visibility = Visibility.Visible;
            dataGridPacijenti.ItemsSource = Pacijenti;
            Labela.Visibility = Visibility.Visible;
            /*TabelaPacijenataSWindow tp = new TabelaPacijenataSWindow();
            tp.Show();
            this.Close();*/
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(p);
            pp.Show();
            this.Close();
        }
    }
}
