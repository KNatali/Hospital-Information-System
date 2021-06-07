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
    public partial class KreiranjeProfilaDoktoraSWindow : Window
    {
        public KreiranjeProfilaDoktoraSWindow()
        {
            InitializeComponent();
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
        }

        private void Otkazi_kreiranje(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete kreiranje profila doktora?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
                this.Close();
        }

        private void Kreiraj_profil(object sender, RoutedEventArgs e)
        {
            Doktor noviDoktor = new Doktor();
            DoktorController doktorController = new DoktorController();
            PopunjavanjePoljaZaNovogDoktora(noviDoktor);
            if (doktorController.KreiranjeProfila(noviDoktor) == true)
            {
                PorukaOUspesnomKreiranjuDoktora(noviDoktor);
            }
        }
        private void PorukaOUspesnomKreiranjuDoktora(Doktor noviDoktor)
        {
            MessageBoxResult ret = MessageBox.Show("Profil doktora je uspešno kreiran. Da li želite da pregledate njegov profil?", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                PrelazakNaProfilDoktora(noviDoktor);
            }
            else
                this.Close();
        }

        private void PrelazakNaProfilDoktora(Doktor noviDoktor)
        {
            ProfilDoktoraSWindow pd = new ProfilDoktoraSWindow(noviDoktor);
            this.Close();
            pd.Show();
        }

        private void PopunjavanjePoljaZaNovogDoktora(Doktor noviDoktor)
        {
            noviDoktor.Jmbg = Jmbg.Text;
            noviDoktor.Ime = Ime.Text;
            noviDoktor.Prezime = Prezime.Text;
            noviDoktor.DatumRodjenja = (DateTime)Datum.SelectedDate;
            noviDoktor.BrojTelefona = Telefon.Text;
            noviDoktor.Email = Mail.Text;
            noviDoktor.Adresa = Adresa.Text;
            noviDoktor.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            noviDoktor.PocetakRadnogVremena = Od.Text;
            noviDoktor.KrajRadnogVremena = Do.Text;
        }
    }
}
