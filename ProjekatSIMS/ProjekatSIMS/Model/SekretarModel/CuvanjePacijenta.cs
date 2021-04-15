using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model.SekretarModel
{
    public class CuvanjePacijenta
    {
        public CuvanjePacijenta(String l)
        {
            lokacija = l;
        }
        public void Sacuvaj(List<Pacijent> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(lokacija, newJson);
        }

        public List<Pacijent> DobaviPacijente()
        {
            /*pacijenti = new List<Pacijent>();
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

                    pacijenti.Add(p);
                }
                file.Close();
            }*/
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
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

        public object JsonConvert { get; private set; }
    }
}