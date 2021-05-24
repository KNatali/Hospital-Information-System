using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class HitanPregledRepository
    {
        private String pacijenti = @"..\..\..\Fajlovi\Pacijent.txt";
        private List<Pacijent> listaPacijenata;
        public HitanPregledRepository()
        {

        }
        public HitanPregledRepository(String lokacija)
        {
            pacijenti = lokacija;
        }
        public List<Pacijent> DobaviSvePacijente()
        {
            using (StreamReader r = new StreamReader(pacijenti))
            {
                string json = r.ReadToEnd();
                listaPacijenata = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            return listaPacijenata;
        }

        public void SacuvajHitanNalog(List<Pacijent> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(pacijenti, newJson);
        }
    }
}
