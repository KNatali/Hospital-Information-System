using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class PacijentRepository
    {
        private string lokacija = @"..\..\..\Fajlovi\Pacijent.txt";
        private const string putanja = @"..\..\..\Fajlovi\Pacijent.txt";
        private string v;
        private List<Pacijent> pacijenti;

        public PacijentRepository(string l)
        {
            this.lokacija = l;
        }

        public PacijentRepository()
        {

        }

        public List<Pacijent> DobaviSve()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            return pacijenti;

        }

        public void Sacuvaj(List<Pacijent> pacijenti)
        {
            string newJson = JsonConvert.SerializeObject(pacijenti);
            File.WriteAllText(putanja, newJson);
        }
    }
}
