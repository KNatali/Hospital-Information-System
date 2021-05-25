using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ZakaziPregledDoktorService
    {
        private PregledRepository pregledRepository = new PregledRepository();

        public void ZakaziPregled(Pregled pregled)
        {
            List<Pregled> sviPregledi = pregledRepository.DobaviSvePregledeDoktor();
            if (sviPregledi == null)
                sviPregledi = new List<Pregled>();
            sviPregledi.Add(pregled);
            pregledRepository.SacuvajPregledeDoktor(sviPregledi);

        }
    }
}
