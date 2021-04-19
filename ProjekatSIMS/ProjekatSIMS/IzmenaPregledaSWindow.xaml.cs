﻿using Model;
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
    public partial class IzmenaPregledaSWindow : Window
    {
        public PregledRepository fajl { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public Pregled pre { get; set; }
        public IzmenaPregledaSWindow(Pregled p)
        {
            InitializeComponent();
            this.DataContext = this;
            Pregledi = new List<Pregled>();
            Datum.SelectedDate = p.Pocetak;
            Sat.Text = p.Pocetak.Hour.ToString();
            Minut.Text = p.Pocetak.Minute.ToString();
            Trajanje.Text = p.Trajanje.ToString();

            /*List<Pregled> ListaPregleda = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi");
            ListaPregleda = fajl.GetListaPregledaSekretar();*/
            
            /*Pregledi.Add(p);
            Pre = p;
            Pocetak.SelectedDate = Pregled.Pocetak;
            Trajanje.Text = Pregled.Pocetak.Hour.ToString();
            Tip.Text = Pregled.Pocetak.Minute.ToString();*/
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {

            /*DateTime datum = (DateTime)Datum.SelectedDate;
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
            /* if(pregledController.IzmjenaPregledaDoktor(pregled, datum1))
             {
                 MessageBox.Show("Uspjesno ste izmjenili termin pregleda");
             }
             else
                 MessageBox.Show("Neuspjesna promjena termina pregleda");*/

            /*List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\SviPregledi.txt");
            Pregledi = fajl.GetListaPregledaSekretar();

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
                                MessageBox.Show("Ovaj termin je već zauzet!");
                                PrikazTermina(pregledi, datum1, datum2, pre.Trajanje, pre.doktor);
                                return;
                            }

                        }
                    }
                }
            }*/

            /*foreach (Pregled pr in pregledi)
            {
                if (pr.Id == pregled.Id)
                {
                    pr.Pocetak = datum1;

                    break;
                }
            }
            PregledRepository.SacuvajPregledSekretar(pregledi);

            MessageBox.Show("Uspjesno je zakazana operacija");
            this.NavigationService.Navigate(new Uri("PrikazPregledaDoktor.xaml", UriKind.Relative));*/

            MessageBox.Show("Uspešno ste izmenili termin. " +
                "Poslato je obaveštenje pacijentu i doktoru.", "OBAVEŠTENJE", MessageBoxButton.OK);
            this.Close();
        }
        /*private void PrikazTermina(List<Pregled> pregledi, DateTime datum1, DateTime datum2, int trajanje, Doktor dr)
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
        }*/
    }
}