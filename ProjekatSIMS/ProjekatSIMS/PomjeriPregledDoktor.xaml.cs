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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PomjeriPregledDoktor.xaml
    /// </summary>
    public partial class PomjeriPregledDoktor : Page
    {

        public PregledController pregledController = new PregledController();
        public PregledRepository pregledRepository = new PregledRepository();
        public Pregled pregled { get; set; }
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PomjeriPregledDoktor(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;


            Pregledi = new List<Pregled>();
            pregled = new Pregled();
            Pregledi.Add(p);
            pregled = p;
            Date.SelectedDate = pregled.Pocetak;
            Sati.Text = pregled.Pocetak.Hour.ToString();
            Minuti.Text = pregled.Pocetak.Minute.ToString();
           
        }

        private void PotvrdiIzmjenu(object sender, RoutedEventArgs e)
        {
            DateTime datum = (DateTime)Date.SelectedDate;
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
                sat = Convert.ToDouble(Sati.Text);
                minut = Convert.ToDouble(Minuti.Text);
            }
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut); //izabrano vrijeme
            DateTime datum2 = datum1.AddMinutes(pregled.Trajanje);
            /* if(pregledController.IzmjenaPregledaDoktor(pregled, datum1))
             {
                 MessageBox.Show("Uspjesno ste izmjenili termin pregleda");
             }
             else
                 MessageBox.Show("Neuspjesna promjena termina pregleda");*/

            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pregled.txt"))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
           
            foreach (Pregled pr in pregledi)
            {
                if (pr.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (pregled.doktor.Jmbg == pr.doktor.Jmbg || pr.prostorija == pregled.prostorija)
                    {
                        if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                        {

                            DateTime datum11 = pr.Pocetak;
                            DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                            if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                                DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                            {
                                MessageBox.Show("Dati termin je zauzet");
                                PrikazTermina(pregledi, datum1, datum2, pregled.Trajanje, pregled.doktor);
                                return;
                            }

                        }
                    }
                }
            }






            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == pregled.Id)
                {
                    pr.Pocetak = datum1;

                    break;
                }
            }
            pregledRepository.SacuvajPregledDoktor(pregledi);

            MessageBox.Show("Uspjesno je izmjenjen termin");
            this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));

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
                    if (dr.Jmbg == p.doktor.Jmbg || p.prostorija == pregled.prostorija)
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
