using Controller;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public abstract class ZakazivanjeService
    {
       
        private ZauzetostTerminaPregledaController zauzetostTerminaPregledaController = new ZauzetostTerminaPregledaController();
        private ManipulacijaPregledomController zakaziPregledController = new ManipulacijaPregledomController();
        public PrikazSlobodnihTerminaController prikazSlobodnihTerminaController = new PrikazSlobodnihTerminaController();
        public DoktorRepository doktorRepository = new DoktorRepository();
        public PregledRepository pregledRepository = new PregledRepository();
       
        public Pregled KreiranjePregleda(IntervalDatuma termin, Prostorija prostorija, Pacijent pacijent,Doktor doktor)
        {
            Doktor dr = new Doktor();
            if (doktor == null)
                dr = doktorRepository.DobaviByRegistracija(UlogovaniKorisnik.KorisnickoIme, UlogovaniKorisnik.Lozinka);
            else
                dr = doktor;
            Pregled pregled = new Pregled();
            pregled.Pocetak = termin.PocetnoVrijeme;
            pregled.Trajanje = termin.KrajnjeVrijeme.Subtract(termin.PocetnoVrijeme).Minutes;
            DopujavanjePregleda(pregled);
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.prostorija = prostorija;
            pregled.doktor = dr;
            pregled.pacijent = pacijent;
            return pregled;
        }
        
        public abstract void DopujavanjePregleda(Pregled p);
        public abstract void IspisivanjePoruke();


        public List<String> ZauzetiTermini(IntervalDatuma termin,Pregled pregled)
        {

            if (zauzetostTerminaPregledaController.ProvjeraZauzetostiTermina(pregled, termin))
            {
                List<String> termini = new List<String>();
                termini = prikazSlobodnihTerminaController.PrikazTermina(pregled, termin);
                MessageBox.Show("Dati termin je zauzet");
               
               return termini;
            }
            else
            {
                zakaziPregledController.ZakaziPregled(pregled);
                IspisivanjePoruke();
                 return null;

            }
        }

       
        public Boolean PreklapanjeTermina(Pregled pregled, Pregled zakazanPregled, IntervalDatuma termin)
        {
            if ((pregled.doktor.Jmbg == zakazanPregled.doktor.Jmbg || zakazanPregled.prostorija == pregled.prostorija) && zakazanPregled.Pocetak.Date.CompareTo(termin.PocetnoVrijeme.Date) == 0)
            {
                IntervalDatuma termin2 = new IntervalDatuma(pregled.Pocetak, pregled.Pocetak.AddMinutes(pregled.Trajanje));
                if (termin.DaLiSeTerminiPoklapaju(termin2))
                    return true;
            }
            return false;
        }

       

       
    }
}
