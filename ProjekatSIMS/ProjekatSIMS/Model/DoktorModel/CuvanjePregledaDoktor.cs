
using Model.PacijentModel;
using Model.UpravnikModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.DoktorModel
{
   public class CuvanjePregledaDoktor 
    { 

        private String lokacijaFajla;
        private List<Pregled> pregledi;


        public CuvanjePregledaDoktor(String lokacija)
        {
            lokacijaFajla = lokacija;
        }
      public void Sacuvaj(List<Pregled> pregledi)
      {

            string newJson = JsonConvert.SerializeObject(pregledi);
            File.WriteAllText(lokacijaFajla, newJson);

        }
      
      public List<Pregled> UcitajSvePreglede()
      {


            using (StreamReader r = new StreamReader(lokacijaFajla))
            {
                string json = r.ReadToEnd();
                pregledi = JsonConvert.DeserializeObject<List<Pregled>>(json);
            }
            return pregledi;
        }
      
      
      
   
   }
}