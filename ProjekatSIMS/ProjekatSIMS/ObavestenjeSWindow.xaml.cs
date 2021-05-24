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

        private void Obrisi_obavestenje(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da obrišete ovu objavu?", "PROVERA", MessageBoxButton.YesNo);
            if(ret==MessageBoxResult.Yes)
            {
                if (n.ObrisiNotifikaciju() == true)
                {
                    NotifikacijaRepository fajl = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
                    List<Notifikacija> notif = fajl.DobaviSve();
                    foreach (Notifikacija no in notif)
                    {
                        if (no.Id == n.Id)
                        {
                            notif.Remove(no);
                            break;
                        }
                    }
                    fajl.Sacuvaj(notif);
                    MessageBox.Show("Objava je uspešno obrisana.", "OBAVEŠTENJE");
                    this.Close();
                }
            }
        }

        private void Sacuvaj_izmene(object sender, RoutedEventArgs e)
        {
            PrikupljanjePodatakaObavestenjaIzTextBoxa();
            NotifikacijaController notifikacijaController = new NotifikacijaController();
            if (notifikacijaController.cuvanjeIzmenjenjihPodataka(n) == true)
                MessageBox.Show("Obaveštenje je uspešno izmenjeno.");
            this.Close();
        }

        private void PrikupljanjePodatakaObavestenjaIzTextBoxa()
        {
            n.Naslov = Naslov.Text;
            n.Tekst = Tekst.Text;
        }
    }
}
