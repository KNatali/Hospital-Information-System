using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.PacijentModel
{
    public class CuvanjePregledaPacijent
    { 

        private String LokacijaFajla;
        private List<Pregled> pregledi;

        public CuvanjePregledaPacijent(String lokacija)
        {
            LokacijaFajla = lokacija;
        }

       

        public List<Pregled> DobaviSve()
        {
            pregledi = new List<Pregled>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Pregled.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");

                    Pregled pregled = new Pregled();
                    pregled.Id = Convert.ToInt32(parts[0]);
                    pregled.Pocetak = Convert.ToDateTime(parts[3]);
                    pregled.Trajanje = Convert.ToInt32(parts[4]);
                    if (parts[5] == "Standardni")
                        pregled.Tip = TipPregleda.Standardni;
                    if (parts[5] == "Operacija")
                        pregled.Tip = TipPregleda.Operacija;
                    
                    pregled.StatusPergleda = StatusPregleda.Zakazan;
                    pregledi.Add(pregled);
                }
                file.Close();
            }
            return pregledi;
        }

        public void Sacuvaj(String pregled, Boolean znak)
        {
         

            using StreamWriter fajl = new StreamWriter(LokacijaFajla, znak);
            fajl.WriteLineAsync(pregled);
        }

       /* public Pregled DobaviJedan(int id)
        {
            // TODO: implement
            return null;
        } */

       /* public Pacijent DobaviPacijenta()
        {
            // TODO: implement
            return null;
        } */



    }
}