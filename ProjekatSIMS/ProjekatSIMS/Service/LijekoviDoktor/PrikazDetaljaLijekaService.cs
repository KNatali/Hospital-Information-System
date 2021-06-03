using Model;
using ProjekatSIMS.DTO;
using ProjekatSIMS.ViewModelDoktor;
using System;
using System.Collections.ObjectModel;

namespace ProjekatSIMS.Service.LijekoviDoktor
{
    public class PrikazDetaljaLijekaService
    {

        public LijekDetaljiDTO PrikazDetalja(Lijek selectedLijek)
        {
            string opis = selectedLijek.Opis;
            string poruka = selectedLijek.PorukaOdbaci;
            ObservableCollection<StringWrapper> sastojci = Sastojci(selectedLijek);
            ObservableCollection<StringWrapper> alternativniLijekovi = AlternativniLijekovi(selectedLijek);
            
            LijekDetaljiDTO detalji = new LijekDetaljiDTO(opis, sastojci, alternativniLijekovi,poruka);
            return detalji;
        }

        private static ObservableCollection<StringWrapper> AlternativniLijekovi(Lijek selectedLijek)
        {
            ObservableCollection<StringWrapper> alternativniLijekovi = new ObservableCollection<StringWrapper>();
            foreach (String a in selectedLijek.AlternativniLekovi)
            {
                StringWrapper sw = new StringWrapper();
                sw.Text = a;
                alternativniLijekovi.Add(sw);
            }
            return alternativniLijekovi;
        }

        private static ObservableCollection<StringWrapper> Sastojci(Lijek selectedLijek)
        {
            ObservableCollection<StringWrapper> sastojci = new ObservableCollection<StringWrapper>();
            foreach (String s in selectedLijek.Alergeni)
            {
                StringWrapper sw = new StringWrapper();
                sw.Text = s;
                sastojci.Add(sw);
            }
            return sastojci;
        }
    }
}
