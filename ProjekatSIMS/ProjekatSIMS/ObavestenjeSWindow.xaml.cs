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
    public partial class ObavestenjeSWindow : Window
    {
        public Notifikacija notifikacija { get; set; }
        public ObavestenjeSWindow(Notifikacija novaNotifikacija)
        {
            InitializeComponent();
            this.DataContext = this;
            notifikacija = novaNotifikacija;
            Naslov.Text = notifikacija.Naslov;
            Tekst.Text = notifikacija.Tekst;
            Datum.Text = notifikacija.Datum.ToString();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            ProveraBrisanjaObjave();
        }

        private void ProveraBrisanjaObjave()
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete ovu objavu?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    BrisanjeObjave();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void BrisanjeObjave()
        {
            //if (MetodaZaBrisanjeObavestenja())
            //{
                NotifikacijaRepository fajlVesti;
                List<Notifikacija> listaNotifikacija;
                CitanjeIzFajla(out fajlVesti, out listaNotifikacija);
                BrisanjeNotifikacije(fajlVesti, listaNotifikacija);
                MessageBox.Show("Objava je uspešno obrisana.", "OBAVEŠTENJE");
                this.Close();
            //}
        }

        private void BrisanjeNotifikacije(NotifikacijaRepository fajlVesti, List<Notifikacija> listaNotifikacija)
        {
            foreach (Notifikacija n in listaNotifikacija)
            {
                if (n.Id == notifikacija.Id)
                {
                    listaNotifikacija.Remove(n);
                    break;
                }
            }
            fajlVesti.SacuvajNotifikaciju(listaNotifikacija);
        }

        private static void CitanjeIzFajla(out NotifikacijaRepository fajl, out List<Notifikacija> notif)
        {
            fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
            notif = fajl.DobaviNotifikacije();
        }

        /*private bool MetodaZaBrisanjeObavestenja()
        {
            return notifikacija.ObrisiNotifikaciju();
        }*/

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            notifikacija.Naslov = Naslov.Text;
            notifikacija.Tekst = Tekst.Text;
            NotifikacijaRepository fajlVesti;
            List<Notifikacija> listaNotifikacija;
            CitanjeIzFajla(out fajlVesti, out listaNotifikacija);
            IzmenaNotifikacije(fajlVesti, listaNotifikacija);
            this.Close();
        }

        private void IzmenaNotifikacije(NotifikacijaRepository fajlVesti, List<Notifikacija> listaNotifikacija)
        {
            foreach (Notifikacija n in listaNotifikacija)
            {
                if (notifikacija.Id == n.Id)
                {
                    n.Naslov = notifikacija.Naslov;
                    n.Tekst = notifikacija.Tekst;
                }
            }
            fajlVesti.SacuvajNotifikaciju(listaNotifikacija);
        }
    }
}
