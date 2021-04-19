using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class PregledRepository
    {
        private String LokacijaFajla;
        private List<Pregled> pregledi;


        public PregledRepository(String lokacija)
        {
            LokacijaFajla = lokacija;
        }


        public Model.Pregled SacuvajGuestPregledRepository(DateTime datumPregleda, Model.Pacijent pacijent)
        {
            // TODO: implement
            return null;
        }

        public List<Pregled> GetListaPregledaRepository(DateTime zaDan)
        {
            // TODO: implement
            return null;
        }

        public List<Pregled> GetListaPregledaRepository(String jmbg)
        {
            // TODO: implement
            return null;
        }

        public Model.Pregled GetDatumRepository(DateTime datum)
        {
            // TODO: implement
            return null;
        }

        public List<Pregled> DobaviSvePregledePacijent()
        {
            using (StreamReader sr = new StreamReader(LokacijaFajla))
            {
                string json = sr.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return pregledi;
        }

        public void SacuvajPregledPacijent(List<Pregled> pregledi)
        {
            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(LokacijaFajla, newJson);

        }


        public List<Pregled> DobaviSvePregledeDoktor()
        {
            // TODO: implement
            return null;
        }

        public void SacuvajPregledDoktor()
        {
            // TODO: implement
        }

    }
}