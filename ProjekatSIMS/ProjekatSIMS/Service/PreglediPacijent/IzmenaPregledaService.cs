using Model;
using ProjekatSIMS.Service.PreglediPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjekatSIMS.Service
{
    public class IzmenaPregledaService
    {
        
        public static PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public List<Pregled> Pregledi = fajl.DobaviSvePregledePacijent();
        public ZauzetiTerminiService zauzetiTermini = new ZauzetiTerminiService();
        public Boolean IzmeniPregled(DateTime noviDatum,Pregled p)
        {
            if ((p.Pocetak.AddHours(24) > noviDatum))
            {
                MessageBox.Show("Pregled se moze izmeniti najmanje 24h pre zakazanog termina!");
                return true;
                
            }
            else if (p.Pocetak.AddHours(48) <= noviDatum)
            {
                MessageBox.Show("Pregled se moze pomeriti najvise za dva dana unapred.");
                return true;
            }
            else if(zauzetiTermini.DaLiJeTerminZauzet(noviDatum) == true)
            {
                MessageBox.Show("Ovaj termin je zauzet. Ponudicemo Vam novi termin spram Vaseg prioriteta.");
                return true;
            }
            return false;
        }

      
    }
    
}

