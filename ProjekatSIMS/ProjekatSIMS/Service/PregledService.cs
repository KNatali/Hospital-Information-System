 using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Service
{
    public class PregledService
    {
       
        public const int POCETAK_RADNOG_VREMENA = 8;
        public const int KRAJ_RADNOG_VREMENA = 20;
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public Repository.PregledRepository pregledRepository = new PregledRepository();
        public Repository.ReceptRepository receptRepository;
        

        public ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        public UputRepository uputRepository = new UputRepository();

        public int zauzetPregled = 0;

     
       
        public List<Pregled> DobaviSveSekretar()
        {
            return pregledRepository.GetListaPregledaSekretar();
        }


    
        public Boolean OtkazivanjeSekretar(Pregled p)
        {
            List<Pregled> pregledi = pregledRepository.GetListaPregledaSekretar();
            foreach(Pregled pr in pregledi)
            {
                if(pr.Id==p.Id)
                {
                    pregledi.Remove(pr);
                    break;
                }
            }
            pregledRepository.SacuvajPregledSekretar(pregledi);
            return true;
        }
       
        public Boolean IzmenaPregledaSekretar(Pregled p, DateTime datum)
        {
            List<Pregled> pregledi = pregledRepository.GetListaPregledaSekretar();
            foreach(Pregled pr in pregledi)
            {
                if(pr.Id==p.Id)
                {
                    pr.Pocetak = datum;
                    break;
                }
            }
            pregledRepository.SacuvajPregledSekretar(pregledi);
            return true;
        }

      

    

        public Boolean ZakazivanjePregledaSekretar(ComboBox Termin, String jmbg, String jmbgdoktor, Prostorija prostorija, DateTime datum1, DateTime datum2)
        {
            Pregled p = new Pregled();
            List<Doktor> doktori = new List<Doktor>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }

            int znak = 0;

            foreach (Doktor dr in doktori)
            {
                if (dr.Jmbg == jmbgdoktor)
                {
                    znak++;
                    p.doktor = dr;
                    break;
                }
            }
            if (znak == 0)
            {
                MessageBox.Show("Doktor nije nadjen!");
                return false;
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
                return false;
            }

            pregledRepository = new PregledRepository();

            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();

            foreach (Pregled pr in pregledi)
            {

                if (pr.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (jmbgdoktor == pr.doktor.Jmbg || pr.prostorija == prostorija)
                    {
                        if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                        {

                            DateTime datum11 = pr.Pocetak;
                            DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                            if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                                DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                            {
                                MessageBox.Show("Dati termin je zauzet");
                                PrikazTermina(Termin, pregledi, datum1, datum2, pr.doktor);
                                return false;
                            }

                        }
                    }
                }
            }

            p.Pocetak = datum1;
            p.Trajanje = 20;

            p.Tip = TipPregleda.Standardni;
            p.StatusPregleda = StatusPregleda.Zakazan;
            p.prostorija = prostorija;

            if (pregledi.Count == 0)
            {
                p.Id = 1;
            }
            else
            {
                p.Id = pregledi[pregledi.Count - 1].Id + 1;
            }
            pregledi.Add(p);
            pregledRepository.SacuvajPregledeDoktor(pregledi);


            return true;
        }


       

        private void PrikazTermina(ComboBox Termin, List<Pregled> pregledi, DateTime datum1, DateTime datum2, Doktor dr)
        {

            Termin.Visibility = Visibility.Visible;
            List<Pregled> isti = new List<Pregled>();
            List<DateTime> termini = new List<DateTime>();
            DateTime pocetni = new DateTime(datum1.Year, datum1.Month, datum1.Day, 8, 0, 0);
            DateTime krajnji = new DateTime(datum2.Year, datum2.Month, datum2.Day, 20, 0, 0);
            foreach (Pregled p in pregledi)
            {
                if (p.StatusPregleda == StatusPregleda.Zakazan)
                {
                    // || p.prostorija == (Prostorija)Ordinacija.SelectedItem
                    if (dr.Jmbg == p.doktor.Jmbg)
                    {
                        if (p.Pocetak.Year == datum1.Year && p.Pocetak.Month == datum1.Month && p.Pocetak.Day == datum1.Day)
                        {
                            isti.Add(p);
                        }
                    }
                }

            }
            for (DateTime i1 = pocetni; i1 < krajnji; i1 = i1.AddMinutes(20))
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


