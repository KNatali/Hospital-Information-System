
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.DoktorModel
{
   public class CuvanjePregledaDoktor 
    { 

        private String lokacijaFajla;
   

        public CuvanjePregledaDoktor(String lokacija)
        {
            lokacijaFajla = lokacija;
        }
      public void Sacuvaj(String pregled,Boolean znak)
      {

            
            using StreamWriter file = new StreamWriter(lokacijaFajla,znak);



            file.WriteLineAsync(pregled);

        }
      
      public List<Pregled> UcitajSvePregled()
      {
         // TODO: implement
         return null;
      }
      
      public Pregled UcitajJedanPregled(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Doktor UcitajDoktora()
      {
         // TODO: implement
         return null;
      }
   
      
   
   }
}