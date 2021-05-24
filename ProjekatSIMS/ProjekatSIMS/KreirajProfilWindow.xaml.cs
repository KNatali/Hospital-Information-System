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
            String jmbg = Jmbg.Text;
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String telefon = Telefon.Text;
            String mail = Mail.Text;
            String adresa = Adresa.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            if (pacijentController.kreiranjeProfila(jmbg, ime, prezime, datum, telefon, mail, adresa) == true)
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
            else
                MessageBox.Show("Morate uneti obavezna polja pacijenta: Jmbg, Ime, Prezime.");

            /*p.Jmbg = jmbg;
            p.Ime = ime;
            p.Prezime = prezime;
            p.BrojTelefona = telefon;
            p.Email = mail;
            p.Adresa = adresa;
            p.DatumRodjenja = datum;
            
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            List<Pacijent> pacijenti = fajl.DobaviPacijente();
            pacijenti.Add(p);
            fajl.Sacuvaj(pacijenti);*/
        }
    }
}
