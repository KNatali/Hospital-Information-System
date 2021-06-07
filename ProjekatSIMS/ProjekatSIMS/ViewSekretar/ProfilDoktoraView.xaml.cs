using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;

namespace ProjekatSIMS.ViewSekretar
{
    public partial class ProfilDoktoraView : Window
    {
        private Doktor d;
        public ProfilDoktoraView(Doktor doktor)
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.ProfilDoktoraViewModel(doktor, this);
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Oblasti.SelectedItem = doktor.Specijalizacija;
            d = doktor;
        }
        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaDoktoraIzTextBoxa();
            DoktorController doktorController = new DoktorController();
            if (doktorController.CuvanjeIzmenjenjihPodataka(d) == true)
                MessageBox.Show("Podaci doktora su uspešno izmenjeni.");
            this.Close();
        }
        private void PrikupljanjePodatakaDoktoraIzTextBoxa()
        {
            d.Ime = Ime.Text;
            d.Prezime = Prezime.Text;
            d.BrojTelefona = Telefon.Text;
            d.Email = Mail.Text;
            d.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            d.PocetakRadnogVremena = Od.Text;
            d.KrajRadnogVremena = Do.Text;
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
            if (doktorController.ObrisiDoktora(d) == true)
                MessageBox.Show("Doktor je uspešno obrisan.", "OBAVEŠTENJE");
        }

        private void Manipulacija(object sender, RoutedEventArgs e)
        {
            ManipulacijaRadaDoktoraSWindow m = new ManipulacijaRadaDoktoraSWindow(d);
            m.Show();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
