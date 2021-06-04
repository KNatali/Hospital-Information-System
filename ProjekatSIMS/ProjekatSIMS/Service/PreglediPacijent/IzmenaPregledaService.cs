using Model;
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
            else if(ProveraZauzetostiTermina(noviDatum) == 1)
            {
                MessageBox.Show("Ovaj termin je zauzet. Ponudicemo Vam novi termin spram Vaseg prioriteta.");
                return true;
            }
            return false;
        }

        public int ProveraZauzetostiTermina(DateTime noviDatum)
        {
            int slobodanTermin = 0;
            foreach (Pregled pregled in Pregledi)
            {
                if (pregled.Pocetak == noviDatum)
                {
                    slobodanTermin = 1;

                }
            }
            return slobodanTermin;
        }
    }
    
}

