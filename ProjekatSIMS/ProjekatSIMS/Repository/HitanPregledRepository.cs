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
        private String pregledi = @"..\..\..\Fajlovi\Pregled.txt";
        private List<Pacijent> listaPacijenata;
        private List<Pregled> listaPregleda;
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
        public List<Pregled> DobaviSvePreglede()
        {
            using (StreamReader r = new StreamReader(pregledi))
            {
                string json = r.ReadToEnd();
                listaPregleda = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return listaPregleda;
        }

        public void SacuvajHitanNalog(List<Pacijent> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(pacijenti, newJson);
        }
        public void SacuvajPregled(List<Pregled> p)
        {
            string newJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(pregledi, newJson);
        }
    }
}
