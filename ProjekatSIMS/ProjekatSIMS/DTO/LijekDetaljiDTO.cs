using ProjekatSIMS.ViewModelDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.DTO
{
    public class LijekDetaljiDTO
    {
        private String opis;
        private ObservableCollection<StringWrapper> sastojci;
        private ObservableCollection<StringWrapper> alternativniLijekovi;
        private String poruka;

        public LijekDetaljiDTO(string opis, ObservableCollection<StringWrapper> sastojci, ObservableCollection<StringWrapper> alternativniLijekovi,String poruka)
        {
            this.Opis = opis;
            this.Sastojci = sastojci;
            this.AlternativniLijekovi = alternativniLijekovi;
            this.Poruka = poruka;
        }

        public string Opis { get => opis; set => opis = value; }
        public ObservableCollection<StringWrapper> Sastojci { get => sastojci; set => sastojci = value; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get => alternativniLijekovi; set => alternativniLijekovi = value; }
        public string Poruka { get => poruka; set => poruka = value; }
    }
}
