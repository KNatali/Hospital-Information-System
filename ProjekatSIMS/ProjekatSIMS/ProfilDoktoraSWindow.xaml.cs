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
    public partial class ProfilDoktoraSWindow : Window
    {
        public OsobaRepository fajl { get; set; }
        public List<Doktor> Doktori { get; set; }
        public Doktor dok { get; set; }
        public ProfilDoktoraSWindow(Doktor doktor)
        {
            InitializeComponent();
            dok = doktor;
            Jmbg.Text = dok.Jmbg;
            Ime.Text = dok.Ime;
            Prezime.Text = dok.Prezime;
            Mail.Text = dok.Email;
            Telefon.Text = dok.BrojTelefona;
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Oblasti.SelectedItem = dok.Specijalizacija;
            Od.Text = dok.PocetakRadnogVremena;
            Do.Text = dok.KrajRadnogVremena;
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            dok.Ime = Ime.Text;
            dok.Prezime = Prezime.Text;
            dok.BrojTelefona = Telefon.Text;
            dok.Email = Mail.Text;
            dok.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            dok.PocetakRadnogVremena = Od.Text;
            dok.KrajRadnogVremena = Do.Text;
            List<Doktor> ListaDoktora = new List<Doktor>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            ListaDoktora = fajl.DobaviDoktore();
            foreach (Doktor d in ListaDoktora)
            {
                if (dok.Jmbg == d.Jmbg)
                {
                    d.Ime = dok.Ime;
                    d.Prezime = dok.Prezime;
                    d.BrojTelefona = dok.BrojTelefona;
                    d.Email = dok.Email;
                    d.Specijalizacija = dok.Specijalizacija;
                    d.PocetakRadnogVremena = dok.PocetakRadnogVremena;
                    d.KrajRadnogVremena = dok.KrajRadnogVremena;
                }
            }
            fajl.SacuvajDoktora(ListaDoktora);

            this.Close();
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete doktora?", "PROVERA", MessageBoxButton.YesNo);
            if(ret==MessageBoxResult.Yes)
            {
                OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
                List<Doktor> doktor = fajl.DobaviDoktore();
                foreach (Doktor d in doktor)
                {
                    if (d.Jmbg == dok.Jmbg)
                    {
                        doktor.Remove(d);
                        break;
                    }
                }
                fajl.SacuvajDoktora(doktor);
                MessageBox.Show("Doktor je uspešno obrisan.", "OBAVEŠTENJE");
                this.Close();
            }
        }

        private void Manipulacija(object sender, RoutedEventArgs e)
        {
            ManipulacijaRadaDoktoraSWindow m = new ManipulacijaRadaDoktoraSWindow(dok);
            m.Show();
        }

        private void Kalendar(object sender, RoutedEventArgs e)
        {

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
