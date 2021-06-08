using System;
using Model;
using Repository;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class NeradniDaniService
    {
        public NeradniDaniRepository neradniDaniRepository = new NeradniDaniRepository(@"..\..\..\Fajlovi\NeradniDani.txt");
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");

        public List<NeradniDani> DobaviSve()
        {
            return neradniDaniRepository.DobaviNeradneDane();
        }
        public Boolean OdobriNeradneDane(NeradniDani neradniDani)
        {
            List<NeradniDani> sviNeradniDani = neradniDaniRepository.DobaviNeradneDane();
            sviNeradniDani.Add(Odobri(neradniDani));
            neradniDaniRepository.SacuvajNeradanDan(sviNeradniDani);
            return true;
        }
        private NeradniDani Odobri(NeradniDani polje)
        {
            NeradniDani neradniDani = new NeradniDani();
            neradniDani.interval.PocetnoVrijeme = polje.interval.PocetnoVrijeme;
            neradniDani.interval.KrajnjeVrijeme = polje.interval.KrajnjeVrijeme;
            neradniDani.Vrsta = polje.Vrsta;
            neradniDani.doktor = polje.doktor;
            return neradniDani;
        }
    }
}
