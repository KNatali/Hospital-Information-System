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
    public partial class NovaObjavaSWindow : Window
    {
        public NovaObjavaSWindow()
        {
            InitializeComponent();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete postavljanje obaveštenja?", "PROVERA", MessageBoxButton.YesNo);
            if (ret==MessageBoxResult.Yes)
                this.Close();
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            String naslov = Naslov.Text;
            String tekst = Tekst.Text;
            Notifikacija n = new Notifikacija();
            n.Naslov = naslov;
            n.Tekst = tekst;
            n.Datum = DateTime.Now;
            NotifikacijaRepository fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
            List<Notifikacija> notifikacija = fajl.DobaviNotifikacije();
            notifikacija.Add(n);
            fajl.SacuvajNotifikaciju(notifikacija);
            MessageBox.Show("Obaveštenje je uspešno postavljeno.", "OBAVEŠTENJE");
            this.Close();
        }
    }
}
