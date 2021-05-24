using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Repository
{
   public class AnamnezaRepository
   {

        private const string putanja = @"..\..\..\Fajlovi\Anamneza.txt";
        public void SacuvajAnamnezu(List<Anamneza> anamneze)
        {
            string newJson = JsonConvert.SerializeObject(anamneze);
            File.WriteAllText(putanja, newJson);
        }
    
      
      public List<Anamneza> DobaviSveAnamneze()
      {

            List<Anamneza> anamneze = new List<Anamneza>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                anamneze = JsonConvert.DeserializeObject<List<Anamneza>>(json);
            }
           
            return anamneze;
        }
   
   }
}