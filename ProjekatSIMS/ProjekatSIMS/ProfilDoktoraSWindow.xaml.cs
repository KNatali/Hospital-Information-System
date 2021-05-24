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
        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaDoktoraIzTextBoxa();
            DoktorController doktorController = new DoktorController();
            if (doktorController.CuvanjeIzmenjenjihPodataka(dok) == true)
                MessageBox.Show("Podaci doktora su uspešno izmenjeni.");
            this.Close();
        }
        private void PrikupljanjePodatakaDoktoraIzTextBoxa()
        {
            dok.Ime = Ime.Text;
            dok.Prezime = Prezime.Text;
            dok.BrojTelefona = Telefon.Text;
            dok.Email = Mail.Text;
            dok.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            dok.PocetakRadnogVremena = Od.Text;
            dok.KrajRadnogVremena = Do.Text;
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
            if (doktorController.ObrisiDoktora(dok) == true)
                MessageBox.Show("Doktor je uspešno obrisan.", "OBAVEŠTENJE");
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
