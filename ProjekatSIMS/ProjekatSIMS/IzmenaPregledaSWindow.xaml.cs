using Controller;
using Microsoft.Toolkit.Uwp.Notifications;
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
    public partial class IzmenaPregledaSWindow : Window
    {
        public PregledController pregledController = new PregledController();
        public PregledRepository pregledRepository = new PregledRepository();
        public PregledRepository fajl { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public Pregled pre { get; set; }
        public IzmenaPregledaSWindow(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;
            /*Pregledi = new List<Pregled>();
            Datum.SelectedDate = p.Pocetak;
            Sat.Text = p.Pocetak.Hour.ToString();
            Minut.Text = p.Pocetak.Minute.ToString();*/


            Pregledi = new List<Pregled>();
            pre = new Pregled();
            Pregledi.Add(p);
            pre = p;
            Datum.SelectedDate = pre.Pocetak;
            Sat.Text = pre.Pocetak.Hour.ToString();
            Minut.Text = pre.Pocetak.Minute.ToString();
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {

            /*double sati = Convert.ToDouble(Sat.Text);
            double minuti = Convert.ToDouble(Minut.Text);
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datumNovi = new DateTime();
            datumNovi = datum.AddHours(sati);
            datumNovi = datumNovi.AddMinutes(minuti);
            int slobodanTerminFlag = 0;

            //List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
            /*foreach (Pregled pregled in Pregledi)
            {
                if (pregled.Pocetak == datumNovi)
                {
                    MessageBox.Show("Ovaj termin je zauzet.", "OBAVEŠTENJE",MessageBoxButton.OK);
                    slobodanTerminFlag = 1;
                }

                if (slobodanTerminFlag == 0)
                {*/
            //Pregledi.Add(pre);
            //string newJson = JsonConvert.SerializeObject(Pregledi);
            //File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
            /*PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno izmenjen. " +
               "Poslato je obaveštenje pacijentu i doktoru da je pregled izmenjen.";
            popup.Popup();
            this.Close();
                //}
            //}
            fajl.SacuvajPregledSekretar(Pregledi);*/
            DateTime datum = (DateTime)Datum.SelectedDate;
            DateTime datum1;
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
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            DateTime datum2 = datum1.AddMinutes(pre.Trajanje);

            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pregled.txt"))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }

            foreach (Pregled pr in pregledi)
            {
                if (pr.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (pre.doktor.Jmbg == pr.doktor.Jmbg || pr.prostorija == pre.prostorija)
                    {
                        if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                        {

                            DateTime datum11 = pr.Pocetak;
                            DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                            if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                                DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                            {
                                MessageBox.Show("Termin koji ste odabrali je zauzet!");
                                PrikazTermina(pregledi, datum1, datum2, pre.Trajanje, pre.doktor);
                                return;
                            }

                        }
                    }
                }
            }

            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == pre.Id)
                {
                    pr.Pocetak = datum1;

                    break;
                }
            }
            pregledRepository.SacuvajPregledDoktor(pregledi);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno izmenjen. " +
               "Poslato je obaveštenje pacijentu i doktoru da je pregled izmenjen.";
            popup.Popup();
            this.Close();
        }
        private void PrikazTermina(List<Pregled> pregledi, DateTime datum1, DateTime datum2, int trajanje, Doktor dr)
        {
            Termin.Visibility = Visibility.Visible;
            Izbor.Visibility = Visibility.Visible;

            List<Pregled> isti = new List<Pregled>();
            List<DateTime> termini = new List<DateTime>();
            DateTime pocetni = new DateTime(datum1.Year, datum1.Month, datum1.Day, 8, 0, 0);
            DateTime krajnji = new DateTime(datum2.Year, datum2.Month, datum2.Day, 20, 0, 0);
            foreach (Pregled p in pregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (dr.Jmbg == p.doktor.Jmbg || p.prostorija == pre.prostorija)
                    {

                        if (p.Pocetak.Year == datum1.Year && p.Pocetak.Month == datum1.Month && p.Pocetak.Day == datum1.Day)
                        {
                            isti.Add(p);
                        }
                    }
                }
            }
            for (DateTime i1 = pocetni; i1 < krajnji; i1 = i1.AddMinutes(trajanje))
            {
                int znak = 0;
                DateTime i2 = i1.AddMinutes(trajanje);
                foreach (Pregled p in isti)
                {
                    DateTime datum11 = p.Pocetak;
                    DateTime datum22 = p.Pocetak.AddMinutes(p.Trajanje);
                    if (DateTime.Compare(i1, datum11) >= 0 && DateTime.Compare(i1, datum22) < 0 ||
                        DateTime.Compare(i2, datum11) > 0 && DateTime.Compare(i2, datum22) <= 0)
                    {
                        znak++;
                    }
                }
                if (znak == 0)
                {
                    termini.Add(i1);

                }
            }

            //parovi rastojanje-termin
            List<KeyValuePair<int, DateTime>> parovi = new List<KeyValuePair<int, DateTime>>();

            foreach (DateTime t in termini)
            {
                int distanca = (int)((t - datum1).Duration()).TotalSeconds;

                parovi.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }
            parovi.Sort((x, y) => x.Key.CompareTo(y.Key));

            //izlistavam 4 najbliza termina izabranom
            for (int i = 1; i < 5; i++)
            {
                if (parovi.Count < i + 1)
                    break;
                Termin.Items.Add(parovi[i].Value.Hour + ":" + parovi[i].Value.Minute);
            }
        }
    }
}
