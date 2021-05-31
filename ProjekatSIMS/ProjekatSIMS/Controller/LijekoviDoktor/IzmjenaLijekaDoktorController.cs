using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Controller
{
    public class IzmjenaLijekaDoktorController
    {
        private IzmjenaLijekaDoktorService izmjenaLijekaDoktorService = new IzmjenaLijekaDoktorService();

        public List<String> DodavanjeSastojka(String noviSastojak,Lijek lijek)
        {
            return izmjenaLijekaDoktorService.DodavanjeSastojka(noviSastojak, lijek);
        }

        public List<String> DodavanjeALternativnihLijekova(String noviAlternativniLijek,Lijek lijek)
        {
            return izmjenaLijekaDoktorService.DodavanjeAlternativnihLijekova(noviAlternativniLijek, lijek);
        }

        
    }
}
