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
    public partial class KreiranjeProfilaDoktoraSWindow : Window
    {
        public KreiranjeProfilaDoktoraSWindow()
        {
            InitializeComponent();
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete kreiranje profila doktora?", "PROVERA", MessageBoxButton.YesNo);
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
            Doktor d = new Doktor();
            d.Jmbg = Jmbg.Text;
            d.Ime = Ime.Text;
            d.Prezime = Prezime.Text;
            d.BrojTelefona = Telefon.Text;
            d.Email = Mail.Text;
            d.Adresa = Adresa.Text;
            d.DatumRodjenja = (DateTime)Datum.SelectedDate;
            d.Specijalizacija = (Specijalizacija)Oblasti.SelectedIndex;
            d.PocetakRadnogVremena = Od.Text;
            d.KrajRadnogVremena = Do.Text;

            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            List<Doktor> doktori = fajl.DobaviDoktore();
            doktori.Add(d);
            fajl.SacuvajDoktora(doktori);

            MessageBoxResult ret = MessageBox.Show("Profil doktora je uspešno kreiran. Da li želite da pregledate njegov profil", "OBAVEŠTENJE", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    ProfilDoktoraSWindow pd = new ProfilDoktoraSWindow(d);
                    this.Close();
                    pd.Show();
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;
            }
        }
    }
}
