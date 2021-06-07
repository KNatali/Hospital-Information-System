using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.PreglediPacijent
{
    public class ZauzetiTerminiService
    {
        public static PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public List<Pregled> Pregledi = fajl.DobaviSvePregledePacijent();
        public Boolean DaLiJeTerminZauzet(DateTime noviDatum)
        {
            foreach (Pregled pregled in Pregledi)
            {
                if (pregled.Pocetak == noviDatum)
                {
                    return true;

                }
            }
            return false;
        }
    }
}
