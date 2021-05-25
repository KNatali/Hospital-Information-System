using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OtkazivanjePregledaDoktorService
    {
        private PregledRepository pregledRepository = new PregledRepository();
        public void OtkazivanjePregleda(Pregled pregled)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledeDoktor();
            foreach (Pregled p in pregledi)
            {
                if (p.Id == pregled.Id)
                {
                    pregledi.Remove(p);
                    break;
                }
            }
            pregledRepository.SacuvajPregledeDoktor(pregledi);
        }
       
    }
}
