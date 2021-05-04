using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Service
{
    public class PregledService
    {
        private const int TRAJANJE_PREGLEDA = 20;
        public Repository.PregledRepository pregledRepository = new PregledRepository();
        public Repository.ReceptRepository receptRepository;
        public ProstorijaRepository prostorijaRepository = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
        public UputRepository uputRepository = new UputRepository();
        public Model.Pregled ZakaziGuestPregledService(DateTime datumPregleda, Model.Pacijent pacijent)
        {
            // TODO: implement
            return null;
        }

        public Model.Pregled ZakazivanjeOperacije()
        {
            // TODO: implement
            return null;
        }

        public List<Pregled> DobaviSvePreglede()
        {
            return pregledRepository.DobaviSvePregledeDoktor();
        }






        public Boolean OtkazivanjePregledaDoktor(Pregled p)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();
            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == p.Id)
                {
                    pregledi.Remove(pr);
                    break;
                }
            }
            pregledRepository.SacuvajPregledDoktor(pregledi);
            return true;

        }

        public Boolean IzmjenaPregledaDoktor(Pregled p, DateTime datum)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();
            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == p.Id)
                {
                    pr.Pocetak = datum;

                    break;
                }
            }
            pregledRepository.SacuvajPregledDoktor(pregledi);
            return true;

        }

        public Boolean IzdavanjeUputa(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin)
        {
            Prostorija slobodnaOrdinacija = NadjiSlobodnuOrdinaciju(izabraniTermin);
            if (slobodnaOrdinacija == null)
                return false;

            Pregled p = new Pregled();
            p.pacijent = pacijent;
            p.doktor = doktor;
            p.Pocetak = izabraniTermin;
            p.Trajanje = TRAJANJE_PREGLEDA;
            p.prostorija = slobodnaOrdinacija;
            p.StatusPregleda = StatusPregleda.Zakazan;
            p.Tip = TipPregleda.Standardni;
            List<Pregled> sviPregledi = pregledRepository.DobaviSvePregledeDoktor();
            if (sviPregledi.Count == 0)
            {
                p.Id = 1;
            }
            else
            {
                p.Id = sviPregledi[sviPregledi.Count - 1].Id + 1;
            }
            sviPregledi.Add(p);
            pregledRepository.SacuvajPregledDoktor(sviPregledi);

            DateTime vrijemeIzadavanja = DateTime.Now;
            Uput uput = new Uput(p, vrijemeIzadavanja);
            List<Uput> uputi = new List<Uput>();
            if (uputRepository.DobaviUpute() == null)
                uputi = new List<Uput>();
            else
                uputi = uputRepository.DobaviUpute();

            uputi.Add(uput);
            uputRepository.SacuvajUput(uputi);

            return true;
        }

        public Prostorija NadjiSlobodnuOrdinaciju(DateTime terminPocetak)
        {
            DateTime terminKraj = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA);
            List<Pregled> zakazaniPregledi = pregledRepository.DobaviZakazanePreglede();
            List<Prostorija> ordinacije = prostorijaRepository.DobaviOrdinacije();
            List<Prostorija> slobodneOrdinacije = ordinacije;


            foreach (Pregled p in zakazaniPregledi)
            {
                if (DateTime.Compare(terminPocetak, p.Pocetak) >= 0 && DateTime.Compare(terminPocetak, p.Pocetak.AddMinutes(p.Trajanje)) < 0 ||
                DateTime.Compare(terminKraj, p.Pocetak) > 0 && DateTime.Compare(terminKraj, p.Pocetak.AddMinutes(p.Trajanje)) <= 0 ||
                DateTime.Compare(terminKraj, p.Pocetak) == 0 && DateTime.Compare(terminKraj, p.Pocetak.AddMinutes(p.Trajanje)) == 0)
                {

                    for (int i = 0; i < ordinacije.Count; i++)
                    {
                        if (ordinacije[i].id == p.prostorija.id)
                            slobodneOrdinacije.Remove(ordinacije[i]);
                    }
                }
            }


            if (slobodneOrdinacije.Count == 0)
            {
                MessageBox.Show("Nema slbodnih ordinacija u izabranom terminu. Molimo Vas izaberite neki od drugih ponudjenih termina");
                return null;
            }


            return slobodneOrdinacije[0];
        }

        public List<DateTime> PrikazSlobodnihTermina(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme)
        {

            List<DateTime> slobodniTermini = GetSlobodniTermini(doktor, pocetnoVrijeme, krajnjeVrijeme);
            if (slobodniTermini.Count != 0)
                return slobodniTermini;
            else
                return PronadjiNoveTermine(doktor, pocetnoVrijeme, krajnjeVrijeme);

        }

        public List<DateTime> GetSlobodniTermini(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme)
        {
            List<Pregled> ZakazaniPreglediDoktora = DobaviZakazanePregledeDoktora(doktor);
            List<Pregled> zauzetiPreglediZaInterval = new List<Pregled>();
            List<DateTime> slobodniTermini = new List<DateTime>();

            foreach (Pregled p in ZakazaniPreglediDoktora)
            {
                if (p.Pocetak.Date >= pocetnoVrijeme.Date && p.Pocetak.Date <= krajnjeVrijeme.Date)
                    zauzetiPreglediZaInterval.Add(p);
            }

            DateTime pocetakRadnoVrijeme = new DateTime(pocetnoVrijeme.Year, pocetnoVrijeme.Month, pocetnoVrijeme.Day, 8, 0, 0);
            DateTime krajRadnoVrijeme = new DateTime(krajnjeVrijeme.Year, krajnjeVrijeme.Month, krajnjeVrijeme.Day, 20, 0, 0);

            slobodniTermini = SlobodniTerminiZaInterval(zauzetiPreglediZaInterval, pocetakRadnoVrijeme, krajRadnoVrijeme);
            return slobodniTermini;
        }

        public List<DateTime> SlobodniTerminiZaInterval(List<Pregled> zauzetiPregledi, DateTime pocetakRadnoVrijeme, DateTime krajRadnoVrijeme)
        {

            List<DateTime> slobodniTermini = new List<DateTime>();

            for (DateTime terminPocetak = pocetakRadnoVrijeme; terminPocetak < krajRadnoVrijeme; terminPocetak = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA))
            {
                int zauzet = 0;
                DateTime terminKraj = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA);
                foreach (Pregled p in zauzetiPregledi)
                {
                    if (DateTime.Compare(terminPocetak, p.Pocetak) >= 0 && DateTime.Compare(terminPocetak, p.Pocetak.AddMinutes(p.Trajanje)) < 0 ||
                        DateTime.Compare(terminKraj, p.Pocetak) > 0 && DateTime.Compare(terminKraj, p.Pocetak.AddMinutes(p.Trajanje)) <= 0)
                    {
                        zauzet++;
                    }
                }

                if (zauzet == 0)
                    slobodniTermini.Add(terminPocetak);

                if (terminPocetak.Hour == 19 && terminPocetak.Minute == 40)
                    terminPocetak = terminPocetak.AddHours(12);
            }

            return slobodniTermini;
        }

        public List<DateTime> PronadjiNoveTermine(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme)
        {

            List<Pregled> ZakazaniPreglediDoktora = DobaviZakazanePregledeDoktora(doktor);
            List<Pregled> zauzetiPregledi = new List<Pregled>();
            List<DateTime> slobodniTerminiPrije = new List<DateTime>();
            List<DateTime> slobodniTerminiPoslije = new List<DateTime>();
            List<DateTime> slobodniTermini = new List<DateTime>();

            foreach (Pregled p in ZakazaniPreglediDoktora)
            {
                if (p.Pocetak.Date >= pocetnoVrijeme.Date && p.Pocetak.Date <= krajnjeVrijeme.Date)
                    zauzetiPregledi.Add(p);
            }

            DateTime pocetakRadnoVrijeme = new DateTime(pocetnoVrijeme.Year, pocetnoVrijeme.Month, pocetnoVrijeme.Day, 8, 0, 0);
            DateTime pocetakRadnoVrijemePrije = pocetakRadnoVrijeme.AddDays(-2);
            DateTime krajnjeRadnoVrijeme = new DateTime(krajnjeVrijeme.Year, krajnjeVrijeme.Month, krajnjeVrijeme.Day, 20, 0, 0);
            DateTime krajnjeRadnoVrijemePrije = pocetakRadnoVrijeme.AddHours(-12);

            DateTime pocetakRadnoVrijemePoslije = krajnjeRadnoVrijeme.AddHours(12);
            DateTime krajnjeRadnoVrijemePoslije = krajnjeRadnoVrijeme.AddDays(2);

            slobodniTerminiPrije = SlobodniTerminiZaInterval(zauzetiPregledi, pocetakRadnoVrijemePrije, krajnjeRadnoVrijemePrije);
            slobodniTerminiPoslije = SlobodniTerminiZaInterval(zauzetiPregledi, pocetakRadnoVrijemePoslije, krajnjeRadnoVrijemePoslije);

            List<KeyValuePair<int, DateTime>> parovi = new List<KeyValuePair<int, DateTime>>();


            foreach (DateTime t in slobodniTerminiPrije)
            {
                int distanca = (int)((t - pocetnoVrijeme.AddHours(2)).Duration()).TotalSeconds;

                parovi.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }

            foreach (DateTime t in slobodniTerminiPoslije)
            {
                int distanca = (int)((t - krajnjeVrijeme.AddHours(2)).Duration()).TotalSeconds;

                parovi.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }
            parovi.Sort((x, y) => x.Key.CompareTo(y.Key));

            //izlistavam 4 najbliza termina izabranom
            for (int i = 1; i < 10; i++)
            {
                if (parovi.Count < i + 1)
                    break;
                slobodniTermini.Add(parovi[i].Value);
            }

            return slobodniTermini;



        }

        public List<Pregled> DobaviZakazanePregledeDoktora(Doktor doktor)
        {

            List<Pregled> zakazaniPregledi = pregledRepository.DobaviZakazanePreglede();
            List<Pregled> zakazaniPreglediDoktora = new List<Pregled>();
            foreach (Pregled p in zakazaniPregledi)
            {
                if (p.doktor.Jmbg == doktor.Jmbg)
                    zakazaniPreglediDoktora.Add(p);
            }
            return zakazaniPreglediDoktora;

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
            pregledRepository.SacuvajPregledDoktor(pregledi);


            return true;
        }

        public Boolean ZakazivanjePregleda(ComboBox Termin, String jmbg, Prostorija prostorija, DateTime datum1, DateTime datum2)
        {
            Pregled p = new Pregled();
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }

            Doktor dr = new Doktor { Jmbg = "1511990855023", Ime = "Marijana", Prezime = "Peric" };


            int znak = 0;

            //da i postoji unijeti pacijent     
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

            ///DATUMMM i VRIJEMEE
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();

            foreach (Pregled pr in pregledi)
            {

                if (pr.StatusPregleda == StatusPregleda.Zakazan)
                {
                    if (dr.Jmbg == pr.doktor.Jmbg || pr.prostorija == prostorija)
                    {
                        if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                        {

                            DateTime datum11 = pr.Pocetak;
                            DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                            if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                                DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                            {
                                MessageBox.Show("Dati termin je zauzet");
                                PrikazTermina(Termin, pregledi, datum1, datum2, dr);
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
            pregledRepository.SacuvajPregledDoktor(pregledi);


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


        public List<Pregled> GetListaPregledaService(DateTime zaDan)
        {
            // TODO: implement
            return null;
        }

        public List<Pregled> GetListaPregledaService(String jmbg)
        {
            // TODO: implement
            return null;
        }

        public Boolean ProveraTerminaService(DateTime datumVreme)
        {
            // TODO: implement
            return true;
        }

        public Model.Pregled IzmenaPregledaPacijent(Model.Pregled pregled)
        {
            // TODO: implement
            return null;
        }

        public Boolean SlobodanTerminPacijent()
        {
            // TODO: implement
            return true;
        }





    }
}