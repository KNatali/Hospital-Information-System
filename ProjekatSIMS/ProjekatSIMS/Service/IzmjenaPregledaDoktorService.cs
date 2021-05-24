using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IzmjenaPregledaDoktorService
    {
        private PregledRepository pregledRepository = new PregledRepository();
        public void IzmjeniPregled(Pregled stariPregled,DateTime noviTermin)
        {
           
            List<Pregled> sviPregledi=pregledRepository.DobaviSvePregledeDoktor();
            foreach(Pregled p in sviPregledi)
            {
                if (p.Id == stariPregled.Id)
                    p.Pocetak = noviTermin;
            }
            pregledRepository.SacuvajPregledeDoktor(sviPregledi);

        }
    }
}
