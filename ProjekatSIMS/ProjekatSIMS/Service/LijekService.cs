using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class LijekService
    {
        public LijekRepository lijekRepoisitory = new LijekRepository();

        public LijekService() { }
        public List<Lijek> DobaviPoStatusu(OdobravanjeLekaEnum statusLeka) 
        {
            List<Lijek> lijekovi = new List<Lijek>();
            List<Lijek> trazeniLekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            foreach(Lijek lijek in lijekovi)
            {
                if(lijek.Status == statusLeka)
                {
                    trazeniLekovi.Add(lijek);
                }

            }
            return trazeniLekovi;
        }

        public Lijek DobaviLijekPoNazivu(String nazivLeka)
        {
            List<Lijek> lijekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            foreach(Lijek l in lijekovi)
            {
                if(l.NazivLeka == nazivLeka)
                {
                    return l;
                }
            }
            return null;
        }

        public Boolean IzmeniLek(String StariNaziv, String NazivLeka, String Opis, List<String> Sastojci, List<String> SlicniLekovi)
        {
            List<Lijek> lijekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            if(DobaviLijekPoNazivu(NazivLeka) != null)
            {
                return false;
            }
            foreach (Lijek l in lijekovi)
            {
                if (l.NazivLeka == StariNaziv)
                {
                    l.NazivLeka = NazivLeka;
                    l.Opis = Opis;
                    l.Alergeni = Sastojci;
                    l.AlternativniLekovi = SlicniLekovi;
                }
            }
            return true;
        }
        public Boolean KreirajLek(String NazivLeka, String Opis, List<String> Sastojci, List<String> SlicniLekovi)
        {
            if(DobaviLijekPoNazivu(NazivLeka) != null)
            {
                return false;
            }
            Lijek noviLek = new Lijek(NazivLeka, Opis, Sastojci, SlicniLekovi);
            List<Lijek> lijekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            lijekovi.Add(noviLek);
            lijekRepoisitory.Sacuvaj(lijekovi);


            return true;
        }
        

    }
}
