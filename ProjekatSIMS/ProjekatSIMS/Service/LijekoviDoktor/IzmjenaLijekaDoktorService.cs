using Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewModelDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Service
{
    public class IzmjenaLijekaDoktorService
    {
        private LijekRepository lijekRepository = new LijekRepository();
        public List<String> DodavanjeSastojka(String noviSastojak, Lijek lijek)
        {
            List<String> sastojciNovi = new List<String>();
            DaLiJeUnijetTekst(noviSastojak, lijek);
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
            List<String> alternativniNovi = new List<String>();
            if (lijek.AlternativniLekovi == null)
                lijek.AlternativniLekovi = new List<String>();
            lijek.AlternativniLekovi.Add(noviAlternativniLijek);
           foreach (String s in lijek.AlternativniLekovi)
                alternativniNovi.Add(s);
            return alternativniNovi;
        }


        public void SacuvajIzmjene(Lijek lijek, ObservableCollection<StringWrapper> sastojci, ObservableCollection<StringWrapper> alternativniLijekovi)
        {
            DodavanjeSastojaka(lijek, sastojci);
            DodavanjeALternativnihLijekova(lijek, alternativniLijekovi);
            lijekRepository.AzurirajLijek(lijek);


        }

        private static void DodavanjeALternativnihLijekova(Lijek lijek, ObservableCollection<StringWrapper> alternativniLijekovi)
        {
            lijek.AlternativniLekovi = new List<String>();
            foreach (StringWrapper i in alternativniLijekovi)
                lijek.AlternativniLekovi.Add(i.Text);
        }

        private static void DodavanjeSastojaka(Lijek lijek, ObservableCollection<StringWrapper> sastojci)
        {
            lijek.Alergeni = new List<String>();
            foreach (StringWrapper i in sastojci)
                lijek.Alergeni.Add(i.Text);
        }


    }
}
