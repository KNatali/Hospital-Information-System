using Model;
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
        private void Otkazi(object sender, RoutedEventArgs e)
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
        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            String jmbg = Jmbg.Text;
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String telefon = Telefon.Text;
            String mail = Mail.Text;
            String adresa = Adresa.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            Pacijent p = new Pacijent();
            
            CuvanjePacijenta fajl = new CuvanjePacijenta(@"..\..\Fajlovi\Pacijent.txt");
            List<Pacijent> pacijenti = fajl.DobaviPacijente();
            pacijenti.Add(p);
            fajl.Sacuvaj(pacijenti);

            MessageBoxResult ret = MessageBox.Show("Profil pacijenta je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    ProfilPacijentaSWindow pp = new ProfilPacijentaSWindow(p);
                    this.Close();
                    pp.Show();
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;
            }
        }
    }
}
