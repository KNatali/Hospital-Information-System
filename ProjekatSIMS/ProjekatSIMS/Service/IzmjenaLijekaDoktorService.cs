using Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Service
{
    public class IzmjenaLijekaDoktorService
    {
        private LijekRepository lijekRepository = new LijekRepository();
        public List<String> DodavanjeSastojka(String noviSastojak, Lijek lijek)
        {
            DaLiJeUnijetTekst(noviSastojak, lijek);
            List<String> sastojciNovi = new List<String>();
            foreach (String s in lijek.Alergeni)
                sastojciNovi.Add(s);
            return sastojciNovi;
        }

        private static void DaLiJeUnijetTekst(string noviSastojak, Lijek lijek)
        {
            if (noviSastojak.Length > 1)
            {
                if (lijek.Alergeni == null)
                    lijek.Alergeni = new List<String>();
                lijek.Alergeni.Add(noviSastojak);
            }
        }

        public List<String> DodavanjeAlternativnihLijekova(String noviAlternativniLijek, Lijek lijek)
        {
            if (lijek.AlternativniLekovi == null)
                lijek.AlternativniLekovi = new List<String>();
            lijek.AlternativniLekovi.Add(noviAlternativniLijek);
            List<String> alternativniNovi = new List<String>();
            foreach (String s in lijek.AlternativniLekovi)
                alternativniNovi.Add(s);
            return alternativniNovi;
        }

        public void SacuvajIzmjene(Lijek lijek, ItemCollection sastojci, ItemCollection alternativniLijekovi)
        {
            AzuriranjeSastojaka(lijek, sastojci);
            DodavanjeALternativnihLijekova(lijek, alternativniLijekovi);

            List<Lijek> sviLijekovi = AzuriranjeLijeka(lijek);
            lijekRepository.Sacuvaj(sviLijekovi);

        }

        private static void DodavanjeALternativnihLijekova(Lijek lijek, ItemCollection alternativniLijekovi)
        {
            lijek.AlternativniLekovi = new List<String>();
            foreach (String i in alternativniLijekovi)
                lijek.AlternativniLekovi.Add(i);
        }

        private static void AzuriranjeSastojaka(Lijek lijek, ItemCollection sastojci)
        {
            lijek.Alergeni = new List<String>();
            foreach (String i in sastojci)
                lijek.Alergeni.Add(i);
        }

        private List<Lijek> AzuriranjeLijeka(Lijek lijek)
        {
            List<Lijek> sviLijekovi = lijekRepository.DobaviSve();
            foreach (Lijek l in sviLijekovi)

            {
                if (l.NazivLeka == lijek.NazivLeka)
                {
                    l.Opis = lijek.Opis;
                    l.Alergeni = lijek.Alergeni;
                    l.AlternativniLekovi = lijek.AlternativniLekovi;
                }
            }
            return sviLijekovi;
        }
    }
}
