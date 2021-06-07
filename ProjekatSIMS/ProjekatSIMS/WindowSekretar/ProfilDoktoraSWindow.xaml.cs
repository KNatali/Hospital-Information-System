using Model;
using Repository;
using System;
using Controller;
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
        public Doktor doktor { get; set; }
        public ProfilDoktoraSWindow(Doktor d)
        {
            InitializeComponent();
            doktor = d;
            Jmbg.Text = doktor.Jmbg;
            Ime.Text = doktor.Ime;
            Prezime.Text = doktor.Prezime;
            Mail.Text = doktor.Email;
            Telefon.Text = doktor.BrojTelefona;
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Oblasti.SelectedItem = doktor.Specijalizacija;
            Od.Text = doktor.PocetakRadnogVremena;
            Do.Text = doktor.KrajRadnogVremena;
        }
        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaDoktoraIzTextBoxa();
            DoktorController doktorController = new DoktorController();
            if (doktorController.CuvanjeIzmenjenjihPodataka(doktor) == true)
                MessageBox.Show("Podaci doktora su uspešno izmenjeni.");
            this.Close();
        }
        private void PrikupljanjePodatakaDoktoraIzTextBoxa()
        {
            doktor.Ime = Ime.Text;
            doktor.Prezime = Prezime.Text;
            doktor.BrojTelefona = Telefon.Text;
            doktor.Email = Mail.Text;
            doktor.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            doktor.PocetakRadnogVremena = Od.Text;
            doktor.KrajRadnogVremena = Do.Text;
        }

        private void Obrisi_profil(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete doktora?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                DoktorController doktorController = new DoktorController();
                BrisanjeDoktora(doktorController);
                this.Close();
            }
        }
        private void BrisanjeDoktora(DoktorController doktorController)
        {
            if (doktorController.ObrisiDoktora(doktor) == true)
                MessageBox.Show("Doktor je uspešno obrisan.", "OBAVEŠTENJE");
        }

        private void Manipulacija(object sender, RoutedEventArgs e)
        {
            ManipulacijaRadaDoktoraSWindow m = new ManipulacijaRadaDoktoraSWindow(doktor);
            m.Show();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
