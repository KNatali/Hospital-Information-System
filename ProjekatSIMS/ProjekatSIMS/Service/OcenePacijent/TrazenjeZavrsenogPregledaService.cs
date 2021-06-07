using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.OcenePacijent
{
    public class TrazenjeZavrsenogPregledaService
    {
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public Boolean DaLiPostojiZavrsenPregled()
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.StatusPregleda == StatusPregleda.Zavrsen))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
