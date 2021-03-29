

using System;
using System.Collections.Generic;
using System.IO;

namespace Model.SekretarModel
{
    public class CuvanjePacijenta
    {
        //public CuvanjePacijenta() { }
        /*public CuvanjePacijenta(String lokacije)
        {
            lokacija = lokacije;
        }*/
        public CuvanjePacijenta()
        {
            pacijenti = new List<Pacijent>();
            DateTime datum1 = new DateTime(1999, 10, 10);
            Pacijent p1 = new Pacijent
            {
                Jmbg = "123",
                Adresa = "aaa",
                BrojTelefona = "0123",
                DatumRodjenja = datum1,
                Email = "as@a",
                Ime = "aaaaaaa",
                Prezime = "asadafas"
            };
            pacijenti.Add(p1);
        }
        public void Sacuvaj(Pacijent pacijent)
        {
            /*String linija = "";

            String jmbg = pacijent.Jmbg.ToString();
            String ime = pacijent.Ime.ToString();
            String prezime = pacijent.Prezime.ToString();
            String telefon = pacijent.BrojTelefona.ToString();
            String email = pacijent.Email.ToString();
            String datum = pacijent.DatumRodjenja.ToLongDateString();
            String adresa = pacijent.Adresa.ToString();

            linija += jmbg + "," + ime + "," + prezime + "," + telefon + "," + email + "," + datum + "," + adresa;
            using StreamWriter file = new StreamWriter(lokacija);
            file.WriteLineAsync(linija);*/
            pacijenti.Add(pacijent);
        }

        public List<Pacijent> DobaviPacijente()
        {
            pacijenti = new List<Pacijent>();
            String line;
            using (StreamReader file = new StreamReader(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt"))
            {
                while((line = file.ReadLine()) != null)
                {
                    string[] deo = line.Split(",");
                    Pacijent p = new Pacijent();
                    
                    p.Ime = Convert.ToString(deo[0]);
                    p.Prezime = Convert.ToString(deo[1]);
                    p.Email = Convert.ToString(deo[2]);
                    p.BrojTelefona = Convert.ToString(deo[3]);
                    p.Adresa = Convert.ToString(deo[4]);
                    p.Jmbg = Convert.ToString(deo[5]);
                    p.DatumRodjenja = Convert.ToDateTime(deo[6]);
                }
                file.Close();
            }
            return pacijenti;
        }

        public Sekretar DobaviSekretara()
        {
            // TODO: implement
            return null;
        }

        private String lokacija;
        private List<Pacijent> pacijenti;
    }
}