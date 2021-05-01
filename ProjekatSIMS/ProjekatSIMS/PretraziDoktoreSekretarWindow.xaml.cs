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
    public partial class PretraziDoktoreSekretarWindow : Window
    {
        public List<Doktor> Doktori { get; set; }
        public Doktor dok { get; set; }
        public PretraziDoktoreSekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Doktori = new List<Doktor>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            Doktori = fajl.DobaviDoktore();
        }

        private void Pretraga(object sender, RoutedEventArgs e)
        {
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            dataGridDoktori.Visibility = Visibility.Visible;
            List<Doktor> Doktori1 = new List<Doktor>();
            List<Doktor> ListaDoktora = new List<Doktor>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            ListaDoktora = fajl.DobaviDoktore();
            foreach (Doktor d in ListaDoktora)
            {
                if (d.Ime == ime && d.Prezime == prezime)
                {
                    Doktori1.Add(d);
                    dok = d;
                }
            }
            Labela.Visibility = Visibility.Visible;
            dataGridDoktori.ItemsSource = Doktori1;  // refresh tabele
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Prikaz(object sender, RoutedEventArgs e)
        {
            dataGridDoktori.Visibility = Visibility.Visible;
            dataGridDoktori.ItemsSource = Doktori;
            Labela.Visibility = Visibility.Visible;
        }
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Doktor d = (Doktor)dataGridDoktori.SelectedItems[0];
            ProfilDoktoraSWindow pd = new ProfilDoktoraSWindow(d);
            pd.Show();
            this.Close();
        }
    }
}
