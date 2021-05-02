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
        public Notifikacija n { get; set; }
        public ObavestenjeSWindow(Notifikacija notifikacija)
        {
            InitializeComponent();
            this.DataContext = this;
            n = notifikacija;
            Naslov.Text = n.Naslov;
            Tekst.Text = n.Tekst;
            Datum.Text = n.Datum.ToString();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete ovu objavu?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    if (n.ObrisiNotifikaciju() == true)
                    {
                        NotifikacijaRepository fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
                        List<Notifikacija> notif = fajl.DobaviNotifikacije();
                        foreach (Notifikacija no in notif)
                        {
                            if (no.Id == n.Id)
                            {
                                notif.Remove(no);
                                break;
                            }
                        }
                        fajl.SacuvajNotifikaciju(notif);
                        MessageBox.Show("Objava je uspešno obrisana.", "OBAVEŠTENJE");
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            n.Naslov = Naslov.Text;
            n.Tekst = Tekst.Text;
            List<Notifikacija> ListaN = new List<Notifikacija>();
            NotifikacijaRepository fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
            ListaN = fajl.DobaviNotifikacije();
            foreach (Notifikacija notif in ListaN)
            {
                if (n.Id == notif.Id)
                {
                    notif.Naslov = n.Naslov;
                    notif.Tekst = n.Tekst;
                }
            }
            fajl.SacuvajNotifikaciju(ListaN);
            this.Close();
        }
    }
}
