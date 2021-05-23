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
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void Kreiraj_profil(object sender, RoutedEventArgs e)
        {
            Pacijent noviPacijent = new Pacijent();
            PacijentController pacijentController = new PacijentController();
            PopunjavanjePoljaZaNovogPacijenta(noviPacijent);
            if (pacijentController.kreiranjeProfila(Jmbg.Text, Ime.Text, Prezime.Text, (DateTime)Datum.SelectedDate, Telefon.Text, Mail.Text, Adresa.Text) == true)
            {
                PorukaOUspesnomKreiranjuPacijenta(noviPacijent);
            }
        }

        private void PorukaOUspesnomKreiranjuPacijenta(Pacijent noviPacijent)
        {
            MessageBoxResult ret = MessageBox.Show("Profil pacijenta je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(noviPacijent);
                this.Close();
                pp.Show();
            }
            else
                this.Close();
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
