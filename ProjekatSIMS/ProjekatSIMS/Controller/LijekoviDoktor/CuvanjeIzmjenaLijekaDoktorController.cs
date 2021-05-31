using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Model;
using ProjekatSIMS.Repository;
using Service;

namespace Controller
{
    public class CuvanjeIzmjenaLijekaDoktorController
    {
        private CuvanjeIzmjeneLijekaDoktorService cuvanjeIzmjenaLijekaDoktorService = new CuvanjeIzmjeneLijekaDoktorService();
        public void SacuvajIzmjene(Lijek lijek, ItemCollection sastojci, ItemCollection alternativniLijekovi)
        {
            cuvanjeIzmjenaLijekaDoktorService.SacuvajIzmjene(lijek, sastojci, alternativniLijekovi);
        }
    }
}
