using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public class ZakazivanjePregledaService
    {
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public int trajanje = 30;
        public PregledRepository pregledRepository = new PregledRepository();
        public int zauzetPregled = 0;
        public PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        ProstorijaRepository prostorijaRepository = new ProstorijaRepository();

        public Boolean ZakazivanjePregledaPacijent(String ime, String prezime, String imeDoktora, String prezimeDoktora, DateTime datum, String jmbg)
        {
            DateTime danasnjiDan = DateTime.UtcNow;
            ProveraVremenaZakazivanja(danasnjiDan);

            Pacijent pacijent = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
            Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
            
            if (DaLiJeKorisnikMaliciozan(pacijent.Ime, pacijent.Prezime) == false)
            {
                List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
                if(DaLiJeTerminZauzet(datum) == true)
                {
                    return false;
                }
                if (DaLiJeTerminZauzet(datum) == false)
                {
                    Pregled p = new Pregled { Pocetak = datum, Trajanje = trajanje, StatusPregleda = StatusPregleda.Zakazan, doktor = doktor, Tip = TipPregleda.Standardni, prostorija = ZauzmiProstoriju() , pacijent = pacijent};
                    pregledi.Add(p);
                    pregledRepository.SacuvajPregledPacijent(pregledi);
                    return true;
                }
                return true;
            }
            else
            {
                OtkazivanjeZakazanihPregleda(ime, prezime);
                MessageBox.Show("Zakazali ste i otkazali previse pregleda u proteklom periodu, privremeno Vam je zabranjeno zakazivanje pregleda. Ukoliko smatrate da je ovo greska, molimo Vas obratite se sekretaru.");
                return false;
            }
        }
        private Prostorija ZauzmiProstoriju()
        {
            List<Prostorija> prostorije = prostorijaRepository.DobaviSve();
            Prostorija prostorija = new Prostorija();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.slobodna == true)
                {
                    prostorija = pr;
                    pr.slobodna = false;
                    break;
                }
            }
            return prostorija;
        }
        public Boolean DaLiJeTerminZauzet(DateTime datum)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled pregled in pregledi)
            {
                if (pregled.Pocetak == datum)
                {
                    MessageBox.Show("Odabrali ste termin koji je zauzet, na osnovu Vaseg prioriteta cemo Vam predloziti slobodne termine.");
                    return true;
                    
                }
            }
            return false;
        }
        private void OtkazivanjeZakazanihPregleda(String ime, String prezime)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled pregled in pregledi)
            {
                if ((pregled.pacijent.Ime == ime) && (pregled.pacijent.Prezime == prezime))
                {
                    pregled.StatusPregleda = StatusPregleda.Otkazan;
                }
            }
        }
        private Boolean DaLiJeKorisnikMaliciozan(String imePacijenta, String prezimePacijenta)
        {
            ProveraPodatakaPacijenta(imePacijenta, prezimePacijenta);
            Pacijent pacijent = new Pacijent();
            foreach (Pacijent p in DobavljanjePacijenataIzFajla())
            {
                if ((p.Ime == imePacijenta) && (p.Prezime == prezimePacijenta))
                {
                    pacijent = p;
                }
            }
            return pacijent.jesteMaliciozanKorisnik;
        }

        private bool SlanjePorukeOBlokiranjuKorisnika(String ime, String prezime)
        {
            List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();
            foreach (Pacijent p in Pacijenti)
            {
                if ((p.Ime == ime) & (p.Prezime == prezime))
                {
                    p.jesteMaliciozanKorisnik = true;
                }
            }
            pacijentRepository.Sacuvaj(Pacijenti);
            return true;
        }

        private List<Pacijent> DobavljanjePacijenataIzFajla()
        {
            List<Pacijent> Pacijenti= pacijentRepository.DobaviSve();
            return Pacijenti;
        }
        private void ProveraPodatakaPacijenta(String imePacijenta, String prezimePacijenta)
        {
            foreach (Pacijent pacijent in DobavljanjePacijenataIzFajla())
            {
                if ((pacijent.Ime == imePacijenta) && (pacijent.Prezime == prezimePacijenta) && (pacijent.otkazaoPregled >= MAKSIMALNO_OTKAZIVANJA))
                {
                    SlanjePorukeOBlokiranjuKorisnika(imePacijenta, prezimePacijenta);
                    break;
                }
            }
        }
        private void ProveraVremenaZakazivanja(DateTime sadasnjeVreme)
        {
            List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();

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
            List<Pacijent> Pacijenti = pacijentRepository.DobaviSve();

            foreach (Pacijent pacijent in Pacijenti)
            {
                if ((pacijent.Prezime == prezime) && (pacijent.Ime == ime))
                {
                    pacijent.otkazaoPregled = 0;
                    pacijent.zakazaoPregled = 0;
                }
            }
            pacijentRepository.Sacuvaj(Pacijenti);
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

    }
}
