using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ManipulacijaPregledomService
    {
        private PregledRepository pregledRepository = new PregledRepository();

        public void ZakaziPregled(Pregled pregled)
        {
            List<Pregled> sviPregledi = pregledRepository.DobaviSvePregledeDoktor();
            if (sviPregledi == null)
                sviPregledi = new List<Pregled>();
            pregled.Id = GenerisiId(sviPregledi);
            sviPregledi.Add(pregled);
            pregledRepository.SacuvajPregledeDoktor(sviPregledi);

        }

        public int GenerisiId(List<Pregled> pregledi)
        {
            if (pregledi.Count == 0)
                return 1;
             
            else
                return pregledi[pregledi.Count - 1].Id + 1;

        }

        public void IzmjeniPregled(Pregled stariPregled, DateTime noviTermin)
        {

            List<Pregled> sviPregledi = pregledRepository.DobaviSvePregledeDoktor();
            Pregled pregled = pregledRepository.DobaviPregledById(stariPregled.Id);
            sviPregledi.Find(p => p.Id == stariPregled.Id).Pocetak = noviTermin;
            pregledRepository.SacuvajPregledeDoktor(sviPregledi);



        }
    }
}
