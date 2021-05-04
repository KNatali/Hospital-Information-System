using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tulpep.NotificationWindow;

namespace ProjekatSIMS
{
    public partial class ZakaziTerminSWindow : Window
    {
        public Pacijent pac { get; set; }
        public List<Doktor> Doktori { get; set; }
        public List<Prostorija> Ordinacije { get; set; }
        public List<TipPregleda> Tipovi { get; set; }
        public ZakaziTerminSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            List<Doktor> doktori = new List<Doktor>();
            Doktori = new List<Doktor>();
            //ucitavanje doktora u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            foreach (Doktor d in doktori)
                Doktori.Add(d);
            List<Prostorija> prostorije = new List<Prostorija>();
            Ordinacije = new List<Prostorija>();
            //ucitavanje ordinacija u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Prostorija.txt"))
            {

                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            foreach (Prostorija pr in prostorije)
            {
                if (pr.vrsta == VrstaProstorije.Ordinacija)
                    Ordinacije.Add(pr);
            }
            List<TipPregleda> tipovi = new List<TipPregleda>();
            Tipovi = new List<TipPregleda>();
            //ucitavanje tipova pregleda u combobox
            foreach (TipPregleda t in tipovi)
                Tipovi.Add(t);
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            p.doktor = (Doktor)Doktor.SelectedItem;
            Prostorija prostorija = (Prostorija)Ordinacija.SelectedItem;
            DateTime datum = (DateTime)Datum.SelectedDate;
            double sat;
            double minut;

            if (Termin.Visibility == Visibility.Visible)
            {
                sat = Convert.ToDouble(Termin.Text.Split(":")[0]);
                minut = Convert.ToDouble(Termin.Text.Split(":")[1]);
            }
            else
            {
                sat = Convert.ToDouble(Sat.Text);
                minut = Convert.ToDouble(Minut.Text);
            }

            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            DateTime datum2 = datum1.AddMinutes(20);
            PregledController pc = new PregledController();
            if (pc.ZakazivanjePregledaSekretar(Termin, pac.Jmbg, p.doktor.Jmbg,prostorija, datum1, datum2) == true)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.informacija;
                popup.TitleText = "OBAVEŠTENJE";
                popup.ContentText = "Pregled je uspešno zakazan. " +
                    "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
                popup.Popup();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste uspeli da zakažete pregled.");
            }
           
        }
    }
}
