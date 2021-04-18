﻿using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections;
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
    /// Interaction logic for ZakaziOperacijuDoktor.xaml
    /// </summary>
    public partial class ZakaziOperacijuDoktor : Page
    {
        public List<Prostorija> Sale { get; set; }
        public ZakaziOperacijuDoktor()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Prostorija> prostorije = new List<Prostorija>();
            Sale = new List<Prostorija>();
            //ucitavanje sala u combobox
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Prostorija.txt"))
            {
                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            //ubacujem samo sale za operaciju
            foreach (Prostorija p in prostorije)
            {
                if (p.Vrsta == VrstaProstorije.Sala)
                    Sale.Add(p);

            }
        }

        private void ZakazivanjeOperacije(object sender, RoutedEventArgs e)
        {
            PregledController pc = new PregledController();
            PregledRepository prep = new PregledRepository();

            Pregled p = new Pregled();
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;

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
            int trajanje = Convert.ToInt32(Trajanje.Text);
            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            DateTime datum2 = datum1.AddMinutes(trajanje);


            //gledam da li postoji dati pacijent

            List<Pacijent> pacijenti = new List<Pacijent>();
            int znak = 0;

            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            foreach (Pacijent pa in pacijenti)
            {
                if (pa.Jmbg == jmbg)
                {
                    znak++;
                    p.pacijent = pa;
                    break;
                }
            }
            if (znak == 0)
            {
                MessageBox.Show("Pacijent nije nadjen!");
                return;
            }


            ///DATUM i VRIJEME
            List<Pregled> pregledi;
         
            pregledi = prep.DobaviSvePregledeDoktor();
            

            foreach (Pregled pr in pregledi)
            {

                if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                {

                    DateTime datum11 = pr.Pocetak;
                    DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                    if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                        DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                    {
                        MessageBox.Show("Dati termin je zauzet");
                        PrikazTermina(pregledi, datum1, datum2, trajanje);
                        return;
                    }

                }
            }


            p.Pocetak = datum1;
            p.Trajanje = trajanje;

            p.Tip = TipPregleda.Operacija;
            p.StatusPregleda = StatusPregleda.Zakazan;
            p.prostorija = (Prostorija)Sala.SelectedItem;


            Doktor dr = new Doktor { Jmbg = "1511990855023", Ime = "Marijana", Prezime = "Peric" };
            p.doktor = dr;



            if (pregledi.Count == 0)
            {
                p.Id = 1;
            }
            else
            {
                p.Id = pregledi[pregledi.Count - 1].Id + 1;
            }
            pregledi.Add(p);
            prep.SacuvajPregledDoktor(pregledi);

            MessageBox.Show("Uspjesno je zakazana operacija");
        }

        private void PrikazTermina(List<Pregled> pregledi, DateTime datum1, DateTime datum2, int trajanje)
        {
            Termin.Visibility = Visibility.Visible;
            Izbor.Visibility = Visibility.Visible;
            List<Pregled> isti = new List<Pregled>();
            List<DateTime> termini = new List<DateTime>();
            DateTime pocetni = new DateTime(datum1.Year, datum1.Month, datum1.Day, 8, 0, 0);
            DateTime krajnji = new DateTime(datum2.Year, datum2.Month, datum2.Day, 20, 0, 0);
            foreach (Pregled p in pregledi)
            {

                if (p.Pocetak.Year == datum1.Year && p.Pocetak.Month == datum1.Month && p.Pocetak.Day == datum1.Day)
                {
                    isti.Add(p);
                }

            }
            for (DateTime i1 = pocetni; i1 < krajnji; i1 = i1.AddMinutes(trajanje))
            {
                int znak = 0;
                DateTime i2 = i1.AddMinutes(20);
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
                    Termin.Items.Add(i1.Hour.ToString() + ":" + i1.Minute.ToString());

                }
            }

        }

        private void PrikazInventara(object sender, RoutedEventArgs e)
        {

            RightListBox.Items.Clear();
            Prostorija s = (Prostorija)Sala.SelectedItem;

            Inventar[] inventari = s.Inventar;
            if (inventari ==null)
                RightListBox.Items.Add("Inventar jos nije unesen!");
            else
            {
                foreach (Inventar i in inventari)
                    RightListBox.Items.Add(i.Ime+" : "+i.Kolicina.ToString());


            }
        }
    }
}
