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
        public void SacuvajSve(List<Anamneza> anamneze)
        {
            string newJson = JsonConvert.SerializeObject(anamneze);
            File.WriteAllText(putanja, newJson);
        }

        public void Sacuvaj(Anamneza anamneza)
        {
            List<Anamneza> anamneze = DobaviSve();
            anamneze.Add(anamneza);
            SacuvajSve(anamneze);
        }
    
      
      public List<Anamneza> DobaviSve()
      {

            List<Anamneza> anamneze = new List<Anamneza>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                anamneze = JsonConvert.DeserializeObject<List<Anamneza>>(json);
            }
           
            return anamneze;
        }

        public List<Anamneza> DobaviAnamnezeZaKarton(int id)
        {
            List<Anamneza> sve = DobaviSve();
            List<Anamneza> anamneze = new List<Anamneza>();
            foreach(Anamneza a in sve)
            {
                if (a.IdKartona == id)
                    anamneze.Add(a);
            }

            return anamneze;


        }

        public void AzurirajAnamnezu(Anamneza anamneza)
        {
            List<Anamneza> sveAnamneze = DobaviSve();
            foreach(Anamneza a in sveAnamneze)
            {
                if (a.Id == anamneza.Id)
                    a.OpisAnamneze = anamneza.OpisAnamneze;
            }
            SacuvajSve(sveAnamneze);

        }
   
   }
}