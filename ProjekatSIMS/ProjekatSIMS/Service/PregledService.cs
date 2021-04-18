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

        public Repository.PregledRepository pregledRepository =new PregledRepository();
        public Repository.ReceptRepository receptRepository;
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

        public Boolean IzmjenaPregledaDoktor(Pregled p,DateTime datum)
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

        public Boolean ZakazivanjePregleda(ComboBox Termin,String jmbg, Prostorija prostorija, DateTime datum1, DateTime datum2)
      {
            Pregled p = new Pregled();
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }

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

                if (pr.Pocetak.Year == datum1.Year && pr.Pocetak.Month == datum1.Month && pr.Pocetak.Day == datum1.Day)
                {

                    DateTime datum11 = pr.Pocetak;
                    DateTime datum22 = pr.Pocetak.AddMinutes(pr.Trajanje);
                    if (DateTime.Compare(datum1, datum11) >= 0 && DateTime.Compare(datum1, datum22) < 0 ||
                        DateTime.Compare(datum2, datum11) > 0 && DateTime.Compare(datum2, datum22) <= 0)
                    {
                        MessageBox.Show("Dati termin je zauzet");
                        PrikazTermina(Termin,pregledi, datum1, datum2);
                        return false;
                    }

                }
            }


            p.Pocetak = datum1;
            p.Trajanje = 20;

            p.Tip = TipPregleda.Standardni;
            p.StatusPregleda = StatusPregleda.Zakazan;
            p.prostorija = prostorija;

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
            pregledRepository.SacuvajPregledDoktor(pregledi);

           
            return true;
      }

        private void PrikazTermina(ComboBox Termin,List<Pregled> pregledi, DateTime datum1, DateTime datum2)
        {

            Termin.Visibility = Visibility.Visible;
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
                    Termin.Items.Add(i1.Hour.ToString() + ":" + i1.Minute.ToString());

                }
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