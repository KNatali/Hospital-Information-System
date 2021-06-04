using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Newtonsoft.Json;

namespace Repository
{
    public class DoktorRepository
    {
        private string lokacija = @"..\..\..\Fajlovi\Doktor.txt";
        private List<Doktor> doktori;
        public DoktorRepository(string l)
        {
            lokacija = l;
        }
        public DoktorRepository()
        {

        }
        public List<Doktor> DobaviSve()
        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            return doktori;
        }

        public Doktor DobaviByRegistracija(String korisnickoIme,String lozinka)
        {
            List<Doktor> svi = DobaviSve();
            foreach(Doktor d in doktori)
            {
                if (d.registrovaniKorisnik.KorisnickoIme == korisnickoIme && d.registrovaniKorisnik.Lozinka == lozinka)
                    return d;
            }
            return null;
        }
        public void Sacuvaj(List<Doktor> doktor)
        {
            string newJson = JsonConvert.SerializeObject(doktor);
            File.WriteAllText(lokacija, newJson);
        }
    }
}
