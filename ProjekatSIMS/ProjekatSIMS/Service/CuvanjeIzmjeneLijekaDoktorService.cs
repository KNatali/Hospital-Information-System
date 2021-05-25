using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Model;
using ProjekatSIMS.Repository;

namespace Service
{
    public class CuvanjeIzmjeneLijekaDoktorService
    {
        private LijekRepository lijekRepository = new LijekRepository();
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
