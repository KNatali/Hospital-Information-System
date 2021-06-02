using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewModelDoktor;

namespace Service
{
    public class CuvanjeIzmjeneLijekaDoktorService
    {
        private LijekRepository lijekRepository = new LijekRepository();
        public void SacuvajIzmjene(Lijek lijek, ObservableCollection<StringWrapper> sastojci, ObservableCollection<StringWrapper> alternativniLijekovi)
        {
            DodavanjeSastojaka(lijek, sastojci);
            DodavanjeALternativnihLijekova(lijek, alternativniLijekovi);
             List<Lijek> sviLijekovi = AzuriranjeLijeka(lijek);
            lijekRepository.Sacuvaj(sviLijekovi);

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
