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
        private const int TRAJANJE_PREGLEDA = 20;
        public const int POCETAK_RADNOG_VREMENA = 8;
        public const int KRAJ_RADNOG_VREMENA = 20;
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public bool jesteMaliciozniKorisnik = false;
      
        public Repository.PregledRepository pregledRepository = new PregledRepository();
        public Repository.ReceptRepository receptRepository;
        

        public ProstorijaRepository prostorijaRepository = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
        public UputRepository uputRepository = new UputRepository();

        public int zauzetPregled = 0;

        public Model.Pregled ZakaziGuestPregledService(DateTime datumPregleda, Model.Pacijent pacijent)
        {
            // TODO: implement
            return null;
        }



        public List<Pregled> DobaviSvePreglede()
        {
            return pregledRepository.DobaviSvePregledeDoktor();
        }
        public List<Pregled> DobaviSvePregledeSekretar()
        {
            return pregledRepository.GetListaPregledaSekretar();
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
            pregledRepository.SacuvajPregledeDoktor(pregledi);
            return true;

        }
        public Boolean OtkazivanjePregledaSekretar(Pregled p)
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
            pregledRepository.SacuvajPregledeDoktor(pregledi);
            return true;

        }



        public Boolean IzdavanjeUputa(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin)
        {
            Prostorija slobodnaOrdinacija = NadjiSlobodnuOrdinaciju(izabraniTermin);
            if (slobodnaOrdinacija == null)
                return false;

            Pregled p = KreiranjePregleda(pacijent, doktor, izabraniTermin, slobodnaOrdinacija);
            pregledRepository.SacuvajPregledDoktor(p);

            DateTime vrijemeIzadavanja = DateTime.Now;
            Uput uput = new Uput(p, vrijemeIzadavanja);
            uputRepository.SacuvajUput(uput);

            return true;
        }



        private static Pregled KreiranjePregleda(Pacijent pacijent, Doktor doktor, DateTime izabraniTermin, Prostorija slobodnaOrdinacija)
        {
            Pregled pregled = new Pregled();
            pregled.pacijent = pacijent;
            pregled.doktor = doktor;
            pregled.Pocetak = izabraniTermin;
            pregled.Trajanje = TRAJANJE_PREGLEDA;
            pregled.prostorija = slobodnaOrdinacija;
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.Tip = TipPregleda.Standardni;
            return pregled;
        }

        public Prostorija NadjiSlobodnuOrdinaciju(DateTime terminPocetak)
        {
            DateTime terminKraj = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA);
            List<Pregled> zakazaniPregledi = pregledRepository.DobaviZakazanePreglede();
            List<Prostorija> ordinacije = prostorijaRepository.DobaviOrdinacije();
            List<Prostorija> slobodneOrdinacije = DobaviSlobodneOrdinacije(terminPocetak, terminKraj, zakazaniPregledi, ordinacije);

            if (slobodneOrdinacije.Count == 0)
            {
                MessageBox.Show("Nema slbodnih ordinacija u izabranom terminu. Molimo Vas izaberite neki od drugih ponudjenih termina");
                return null;
            }

            return slobodneOrdinacije[0];
        }

        private static List<Prostorija> DobaviSlobodneOrdinacije(DateTime terminPocetak, DateTime terminKraj, List<Pregled> zakazaniPregledi, List<Prostorija> ordinacije)
        {
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

            return slobodneOrdinacije;
        }

        public List<DateTime> PrikazSlobodnihTermina(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, int pocetniInterval, int krajnjiInerval)
        {

            List<DateTime> slobodniTermini = DobaviSlobodneTermineDoktora(doktor, pocetnoVrijeme, krajnjeVrijeme, pocetniInterval, krajnjiInerval);
            if (slobodniTermini.Count != 0)
                return slobodniTermini;
            else
            {
                MessageBox.Show("Nema slobodnih termina u datom intervalu.Prikazace se najblizi slobodni termini");
                return PronadjiNoveTermine(doktor, pocetnoVrijeme, krajnjeVrijeme, pocetniInterval, krajnjiInerval);
            }
        }

        public List<DateTime> DobaviSlobodneTermineDoktora(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, int pocetniInterval, int krajnjiInterval)
        {
            List<Pregled> ZakazaniPreglediDoktora = pregledRepository.DobaviZakazanePregledeDoktora(doktor);
            List<Pregled> zauzetiPreglediZaInterval = ZauzetostPregledaZaInterval(pocetnoVrijeme, krajnjeVrijeme, ZakazaniPreglediDoktora);

            List<DateTime> slobodniTermini = RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, pocetnoVrijeme, krajnjeVrijeme, pocetniInterval, krajnjiInterval);
            return slobodniTermini;
        }

        public List<DateTime> RacunanjeSlobodnihTermina(List<Pregled> zauzetiPregledi, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, int pocetniInterval, int krajnjiInterval)
        {

            List<DateTime> slobodniTermini = new List<DateTime>();

            for (DateTime datum = pocetnoVrijeme; datum <= krajnjeVrijeme; datum = datum.AddDays(1))
            {
                DodavanjeSlobodnihTermina(zauzetiPregledi, pocetniInterval, krajnjiInterval, slobodniTermini, datum);
            }

            return slobodniTermini;
        }

        private static void DodavanjeSlobodnihTermina(List<Pregled> zauzetiPregledi, int pocetniInterval, int krajnjiInterval, List<DateTime> slobodniTermini, DateTime datum)
        {
            DateTime pocetak = new DateTime(datum.Year, datum.Month, datum.Day, pocetniInterval, 0, 0);
            DateTime kraj = new DateTime(datum.Year, datum.Month, datum.Day, krajnjiInterval, 0, 0);

            for (DateTime terminPocetak = pocetak; terminPocetak < kraj; terminPocetak = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA))
            {
                int zauzet = 0;
                DateTime terminKraj = terminPocetak.AddMinutes(TRAJANJE_PREGLEDA);
                zauzet = ProvjeravanjeZauzetostiTermina(zauzetiPregledi, terminPocetak, zauzet, terminKraj);

                if (zauzet == 0)
                    slobodniTermini.Add(terminPocetak);
            }
        }

        private static int ProvjeravanjeZauzetostiTermina(List<Pregled> zauzetiPregledi, DateTime terminPocetak, int zauzet, DateTime terminKraj)
        {
            foreach (Pregled p in zauzetiPregledi)
            {
                zauzet = ProvjeravanjePodudaranjaTerminaSaPregledom(terminPocetak, zauzet, terminKraj, p);
            }

            return zauzet;
        }

        private static int ProvjeravanjePodudaranjaTerminaSaPregledom(DateTime terminPocetak, int zauzet, DateTime terminKraj, Pregled p)
        {
            if (DateTime.Compare(terminPocetak, p.Pocetak) >= 0 && DateTime.Compare(terminPocetak, p.Pocetak.AddMinutes(p.Trajanje)) < 0 ||
                DateTime.Compare(terminKraj, p.Pocetak) > 0 && DateTime.Compare(terminKraj, p.Pocetak.AddMinutes(p.Trajanje)) <= 0)
                zauzet++;
            return zauzet;
        }

        public List<DateTime> PronadjiNoveTermine(Doktor doktor, DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, int pocetniInterval, int krajnjiInterval)
        {

            List<Pregled> ZakazaniPreglediDoktora = pregledRepository.DobaviZakazanePregledeDoktora(doktor);
            List<Pregled> zauzetiPreglediZaInterval = ZauzetostPregledaZaInterval(pocetnoVrijeme, krajnjeVrijeme, ZakazaniPreglediDoktora);

            DateTime pocetnoVrijemePrije, krajnjeVrijemePrije, pocetnoVrijemePoslije, krajnjeVrijemePoslije;
            RacunanjeVremenaOkoIntervala(pocetnoVrijeme, krajnjeVrijeme, out pocetnoVrijemePrije, out krajnjeVrijemePrije, out pocetnoVrijemePoslije, out krajnjeVrijemePoslije);

            List<DateTime> slobodniTerminiPrije = RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, pocetnoVrijemePrije, krajnjeVrijemePrije, pocetniInterval, krajnjiInterval);
            List<DateTime> slobodniTerminiPoslije = RacunanjeSlobodnihTermina(zauzetiPreglediZaInterval, pocetnoVrijemePoslije, krajnjeVrijemePoslije, pocetniInterval, krajnjiInterval);

            List<KeyValuePair<int, DateTime>> parUdaljenostTermin = new List<KeyValuePair<int, DateTime>>();
            parUdaljenostTermin = UdaljenostiOdZadatogVremena(parUdaljenostTermin, pocetnoVrijeme, slobodniTerminiPrije);
            parUdaljenostTermin = UdaljenostiOdZadatogVremena(parUdaljenostTermin, krajnjeVrijeme, slobodniTerminiPoslije);

            return IzlistavanjeNajblizihTermina(parUdaljenostTermin);

        }

        private static List<Pregled> ZauzetostPregledaZaInterval(DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, List<Pregled> ZakazaniPreglediDoktora)
        {
            List<Pregled> zauzetiPreglediZaInterval = new List<Pregled>();
            foreach (Pregled p in ZakazaniPreglediDoktora)
            {
                if (p.Pocetak.Date >= pocetnoVrijeme.Date && p.Pocetak.Date <= krajnjeVrijeme.Date)
                    zauzetiPreglediZaInterval.Add(p);
            }

            return zauzetiPreglediZaInterval;
        }

        private static void RacunanjeVremenaOkoIntervala(DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, out DateTime pocetnoVrijemePrije, out DateTime krajnjeVrijemePrije, out DateTime pocetnoVrijemePoslije, out DateTime krajnjeVrijemePoslije)
        {

            pocetnoVrijemePrije = pocetnoVrijeme.AddDays(-2);
            krajnjeVrijemePrije = pocetnoVrijeme.AddDays(-1);
            pocetnoVrijemePoslije = krajnjeVrijeme.AddDays(1);
            krajnjeVrijemePoslije = krajnjeVrijeme.AddDays(2);
        }

        private static void PostavljanjeVremenaOdInteresa(DateTime pocetnoVrijeme, DateTime krajnjeVrijeme, out DateTime pocetakIntervalaOdInteresa, out DateTime krajIntervalaOdInteresa)
        {
            pocetakIntervalaOdInteresa = new DateTime(pocetnoVrijeme.Year, pocetnoVrijeme.Month, pocetnoVrijeme.Day, POCETAK_RADNOG_VREMENA, 0, 0);
            krajIntervalaOdInteresa = new DateTime(krajnjeVrijeme.Year, krajnjeVrijeme.Month, krajnjeVrijeme.Day, KRAJ_RADNOG_VREMENA, 0, 0);
        }
        
        private static List<DateTime> IzlistavanjeNajblizihTermina(List<KeyValuePair<int, DateTime>> parUdaljenostTermin)
        {
            List<DateTime> slobodniTermini = new List<DateTime>();
            parUdaljenostTermin.Sort((x, y) => x.Key.CompareTo(y.Key));

            for (int i = 1; i < 100; i++)
            {
                if (parUdaljenostTermin.Count < i + 1)
                    break;
                slobodniTermini.Add(parUdaljenostTermin[i].Value);
            }

            List<DateTime> sortiraniSlobodniTermini = slobodniTermini.OrderBy(o => o).ToList();

            return sortiraniSlobodniTermini;
        }

        private static List<KeyValuePair<int, DateTime>> UdaljenostiOdZadatogVremena(List<KeyValuePair<int, DateTime>> parUdaljenostTermin, DateTime pocetnoVrijeme, List<DateTime> slobodniTermini)
        {

            foreach (DateTime t in slobodniTermini)
            {
                int distanca = (int)((t - pocetnoVrijeme.AddHours(2)).Duration()).TotalSeconds;

                parUdaljenostTermin.Add(new KeyValuePair<int, DateTime>(distanca, t));
            }

            return parUdaljenostTermin;
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


        public Boolean OdredjivanjePrioritetaPacijent()
        {

            if (zauzetPregled == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      /*  private Doktor postojiDoktorUSistemu(String ime,String prezime)
        {
            bool doktorPostoji = false;
            List<Doktor> doktori = new List<Doktor>();
            using (StreamReader sr = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = sr.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            foreach (Doktor dr in doktori)
            {
                if ((dr.Ime == ime) && (dr.Prezime == prezime))
                {

                    return dr;
                    
                }
            }
            if(doktorPostoji == false)
            {
                MessageBox.Show("Ne postoji doktor sa tim imenom!");
                return null;
                
            }
            return null;

            
        } */

        private void ZabeleziPodatkePacijenta(Pacijent p)
        {

            PacijentRepository pacijentRepository = new PacijentRepository();
            List <Pacijent> Pacijenti = pacijentRepository.UcitajSvePacijente();
            foreach(Pacijent pa in Pacijenti)
            {
                if (p.zakazaoPregled == 0)
                {
                    p.datumPrvogZakazivanjaPregleda = DateTime.UtcNow;
                }
            }
     
        }

        private void ProveraVremenaZakazivanja(DateTime sadasnjeVreme)
        {
            PacijentRepository pacijentRepository = new PacijentRepository();
            List<Pacijent> Pacijenti = pacijentRepository.UcitajSvePacijente();

            foreach (Pacijent pacijent in Pacijenti)
            {
                int prosloNedeljuDana = DateTime.Compare(pacijent.datumPrvogZakazivanjaPregleda.AddDays(7), sadasnjeVreme);
                if (prosloNedeljuDana < 0)
                {
                    ObrisiPokusajeZakazivanja(pacijent.Ime, pacijent.Prezime);
                }

            }

        }

        private void ObrisiPokusajeZakazivanja(String ime, String prezime)
        {
            PacijentRepository pacijentRepository = new PacijentRepository();
            List<Pacijent> Pacijenti = pacijentRepository.UcitajSvePacijente();

            foreach (Pacijent pacijent in Pacijenti)
            {
                if ((pacijent.Prezime == prezime) && (pacijent.Ime == ime))
                {
                    pacijent.otkazaoPregled = 0;
                    pacijent.zakazaoPregled = 0;
                    
                }
            }
            pacijentRepository.SacuvajPacijente(Pacijenti);
        }
        public Boolean ZakazivanjePregledaPacijent(String ime, String prezime, String imeDoktora, String prezimeDoktora, DateTime datum, String jmbg)
        {
            
            Pregled p = new Pregled();

            int trajanje = 30;
            DateTime danasnjiDan = DateTime.UtcNow;

            ProveraVremenaZakazivanja(danasnjiDan);

            Pacijent pacijent = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
            /*if(postojiDoktorUSistemu(imeDoktora,prezimeDoktora) != null)
            {
                p.doktor = postojiDoktorUSistemu(imeDoktora, prezimeDoktora);
            } */
            Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
            p.doktor = doktor;

            if (DaLiJeKorisnikMaliciozan(ime, prezime) == false)
            {

                pregledRepository = new PregledRepository();

                List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();

                foreach (Pregled pregled in pregledi)
                {
                    if (pregled.Pocetak == datum)
                    {
                        MessageBox.Show("Odabrali ste termin koji je zauzet, na osnovu Vaseg prioriteta cemo Vam predloziti slobodne termine.");
                        zauzetPregled = 1;

                        return false;
                    }
                }

                if (zauzetPregled == 0)
                {

                    p.Tip = TipPregleda.Standardni;
                    p.Pocetak = datum;
                    p.Trajanje = trajanje;
                    Pacijent pac = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
                    p.pacijent = pac;
                    p.StatusPregleda = StatusPregleda.Zakazan;

                    ProstorijaRepository file = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
                    List<Prostorija> prostorije = file.DobaviSveProstorije();
                    foreach (Prostorija pr in prostorije)
                    {
                        if (pr.slobodna == true)
                        {
                            p.prostorija = pr;
                            pr.slobodna = false;
                            break;
                        }
                    }
                    pregledi.Add(p);
                  
                    pregledRepository.SacuvajPregledPacijent(pregledi);


                    return true;


                }
                return true;
            }
            else
            {
                pregledRepository = new PregledRepository();

                List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
                //svi pregledi koje je taj pacijent imao zakazane postaju otkazani
                foreach (Pregled pregled in pregledi)
                {
                    if ((pregled.pacijent.Ime == ime) && (pregled.pacijent.Prezime == prezime))
                    {
                        pregled.StatusPregleda = StatusPregleda.Otkazan;
                    }
                }
                return false;
            }
        }

       private Pacijent PretragaPacijenta(String ime,String prezime)
        {
            PacijentRepository pacijentRepository = new PacijentRepository();
            List<Pacijent> Pacijenti = pacijentRepository.UcitajSvePacijente();
            foreach(Pacijent p in Pacijenti)
            {
                if((p.Ime == ime) && (p.Prezime == prezime))
                {
                    return p;
                }
            }
            return null;
        }


        private Boolean DaLiJeKorisnikMaliciozan(String imePacijenta, String prezimePacijenta)
        {
            ProveraPodatakaPacijenta(imePacijenta, prezimePacijenta);
           
            return jesteMaliciozniKorisnik;
            
            
        }

        private void SlanjePorukeOBlokiranjuKorisnika(String ime,String prezime)
        {
            MessageBox.Show("Zakazali ste i otkazali previse pregleda u proteklom periodu, privremeno Vam je zabranjeno zakazivanje pregleda. Ukoliko smatrate da je ovo greska, molimo Vas obratite se sekretaru.");
            jesteMaliciozniKorisnik = true;
        
        }

        
        private List<Pacijent> DobavljanjePacijenataIzFajla()
        {
            List<Pacijent> Pacijenti;
            Pacijenti = new List<Pacijent>();
            PacijentRepository pacijentRepository = new PacijentRepository();
            Pacijenti = pacijentRepository.UcitajSvePacijente();
            return Pacijenti;
        }
        private void ProveraPodatakaPacijenta(String imePacijenta, String prezimePacijenta)
        {
            foreach (Pacijent pacijent in DobavljanjePacijenataIzFajla())
            {
                if ((pacijent.Ime == imePacijenta) && (pacijent.Prezime == prezimePacijenta) && (pacijent.otkazaoPregled >= MAKSIMALNO_OTKAZIVANJA))
                {
                    SlanjePorukeOBlokiranjuKorisnika(imePacijenta,prezimePacijenta);
                    
                   
                    break;
                }
            }
        }

       



    }
}


