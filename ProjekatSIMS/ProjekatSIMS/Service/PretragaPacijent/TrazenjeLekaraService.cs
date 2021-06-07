using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.OcenePacijent
{
    public class TrazenjeLekaraService
    {
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public Boolean DaLiPostojiLekar(String ime, String prezime)
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.doktor.Ime == ime) && (p.doktor.Prezime == prezime))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
