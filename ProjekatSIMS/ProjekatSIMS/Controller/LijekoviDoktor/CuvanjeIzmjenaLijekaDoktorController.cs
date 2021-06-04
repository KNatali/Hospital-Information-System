using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewModelDoktor;
using Service;

namespace Controller
{
    public class CuvanjeIzmjenaLijekaDoktorController
    {
        private CuvanjeIzmjeneLijekaDoktorService cuvanjeIzmjenaLijekaDoktorService = new CuvanjeIzmjeneLijekaDoktorService();
        public void SacuvajIzmjene(Lijek lijek, ObservableCollection<StringWrapper> sastojci, ObservableCollection<StringWrapper>  alternativniLijekovi)
        {
            cuvanjeIzmjenaLijekaDoktorService.SacuvajIzmjene(lijek, sastojci, alternativniLijekovi);
        }
    }
}
