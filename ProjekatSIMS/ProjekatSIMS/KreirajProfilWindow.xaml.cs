using Model;
using Repository;
using Controller;
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
    public partial class KreirajProfilWindow : Window
    {
        public KreirajProfilWindow()
        {
            InitializeComponent();
        }
        private void Otkazi_kreiranje(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete kreiranje profila pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
                this.Close();
        }
        private void Kreiraj_profil(object sender, RoutedEventArgs e)
        {
            Pacijent noviPacijent = new Pacijent();
            PacijentController pacijentController = new PacijentController();
            PopunjavanjePoljaZaNovogPacijenta(noviPacijent);
            if (pacijentController.KreiranjeProfila(noviPacijent) == true)
            {
                PorukaOUspesnomKreiranjuPacijenta(noviPacijent);
            }
        }

        private void PorukaOUspesnomKreiranjuPacijenta(Pacijent noviPacijent)
        {
            MessageBoxResult ret = MessageBox.Show("Profil pacijenta je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                PrelazakNaProfilPacijenta(noviPacijent);
            }
            else
                this.Close();
        }

        private void PrelazakNaProfilPacijenta(Pacijent noviPacijent)
        {
            ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(noviPacijent);
            this.Close();
            pp.Show();
        }

        private void PopunjavanjePoljaZaNovogPacijenta(Pacijent noviPacijent)
        {
            noviPacijent.Jmbg = Jmbg.Text;
            noviPacijent.Ime = Ime.Text;
            noviPacijent.Prezime = Prezime.Text;
            noviPacijent.DatumRodjenja = (DateTime)Datum.SelectedDate;
            noviPacijent.BrojTelefona = Telefon.Text;
            noviPacijent.Email = Mail.Text;
            noviPacijent.Adresa = Adresa.Text;
        }
    }
}
