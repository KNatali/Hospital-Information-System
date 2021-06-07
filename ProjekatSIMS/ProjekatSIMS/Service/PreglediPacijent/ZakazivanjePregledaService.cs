using Model;
using ProjekatSIMS.Service.PreglediPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public class ZakazivanjePregledaService
    {
        public PregledRepository pregledRepository = new PregledRepository();
        public PacijentRepository pacijentRepository = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
        public ZauzetiTerminiService zauzetiTermini = new ZauzetiTerminiService();
        public MaliciozanKorisnikService maliciozanKorisnikService = new MaliciozanKorisnikService();
        public ZauzimanjeProstorijeService zauzimanjeProstorije = new ZauzimanjeProstorijeService();
        public OtkazivanjePregledaService otkazivanjePregleda = new OtkazivanjePregledaService();
        public Boolean ZakazivanjePregledaPacijent(String imeDoktora, String prezimeDoktora, DateTime datum,Pacijent pac)
        {
            DateTime danasnjiDan = DateTime.UtcNow;
            ProveraVremenaZakazivanja(danasnjiDan);

            Pacijent pacijent = pac;
            Doktor doktor = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
            
            if (maliciozanKorisnikService.DaLiJeKorisnikMaliciozan(pac.Jmbg,pac) == false)
            {
                List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
                if(zauzetiTermini.DaLiJeTerminZauzet(datum) == true)
                {
                    MessageBox.Show("Odabrali ste termin koji je zauzet, na osnovu Vaseg prioriteta cemo Vam predloziti slobodne termine.");
                    return false;
                }
                if (zauzetiTermini.DaLiJeTerminZauzet(datum) == false)
                {
                    Pregled p = new Pregled { Pocetak = datum, Trajanje = 30, StatusPregleda = StatusPregleda.Zakazan, doktor = doktor, Tip = TipPregleda.Standardni, prostorija = zauzimanjeProstorije.ZauzmiProstoriju() , pacijent = pacijent};
                    pregledi.Add(p);
                    pregledRepository.SacuvajPregledPacijent(pregledi);
                    return true;
                }
                return true;
            }
            else
            {
                otkazivanjePregleda.OtkazivanjeZakazanihPregleda(pac);
                MessageBox.Show("Zakazali ste i otkazali previse pregleda u proteklom periodu, privremeno Vam je zabranjeno zakazivanje pregleda. Ukoliko smatrate da je ovo greska, molimo Vas obratite se sekretaru.");
                return false;
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
                    otkazivanjePregleda.ObrisiPokusajeZakazivanja(pacijent.Ime, pacijent.Prezime);
                }
            }
        }

    }
}
