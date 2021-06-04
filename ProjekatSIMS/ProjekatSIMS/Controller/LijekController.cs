using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.Controller
{
    public class LijekController
    {
        public LijekService lijekService = new LijekService();

        public LijekController() { }

        public bool IzmenaLeka(String StariNaziv, String NazivLeka, String Opis, ObservableCollection<String> SlicniLekovi, ObservableCollection<String>Sastojci)
        {
            List<String> slLekovi = new List<String>();
            List<String> sastojci = new List<String>();
            PrebaciUListuStringova(Sastojci, sastojci);
            PrebaciUListuStringova(SlicniLekovi, slLekovi);
            if (lijekService.IzmeniLek(StariNaziv, NazivLeka, Opis, sastojci, slLekovi) == true)
            {
                return true;
            }
            else
                return false;
        }

        public void PrebaciUListuStringova(ObservableCollection<String> kolekcija, List<String> novaLista)
        {
            if (kolekcija != null)
            {
                foreach (String s in kolekcija)
                {
                    novaLista.Add(s);
                }
            }
        }
        public Boolean KreiranjeLeka(String Naziv, String Opis, ObservableCollection<String> SlicniLekovi, ObservableCollection<String> Sastojci)
        {
            List<String> slLekovi = new List<String>();
            List<String> sastojci = new List<String>();
            PrebaciUListuStringova(Sastojci, sastojci);
            PrebaciUListuStringova(SlicniLekovi, slLekovi);
            return lijekService.KreirajLek(Naziv, Opis, sastojci, slLekovi);
            
        }
        public Boolean DaLiJeUnetStringUKolekciju(String stringZaProveru, ObservableCollection<String> kolekcija)
        {
            if(kolekcija == null)
            {
                return false;
            }
            foreach(String s in kolekcija)
            {
                if(s == stringZaProveru)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
