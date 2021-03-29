using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.PacijentModel
{
   public class CuvanjePregledaPacijent
   {

       private String LokacijaFajla;

        public CuvanjePregledaPacijent(String lokacija)
        {
            LokacijaFajla = lokacija;
        }
        public List<Pregled> DobaviSve()
      {
         // TODO: implement
         return null;
      }
      
      public void Sacuvaj(Pregled pregled)
      {
            String linija = "";

            String id = pregled.Id.ToString();
            String pocetak = pregled.Pocetak.ToString();
            String trajanje = pregled.Trajanje.ToString();
            //String tip = pregled.Tip.ToString();
            String idPacijenta = pregled.pacijent.jmbg.ToString();
            String idDoktora = pregled.doktor.Jmbg.ToString();
            // String status = pregled.StatusPergleda.ToString();

            // linija += id + "," + pocetak + "," + trajanje + "," + tip + "," + idPacijenta + "," + idDoktora + "," + status;
            linija += id + "," + pocetak + "," + trajanje + "," + idPacijenta + "," + idDoktora;
            using StreamWriter file = new StreamWriter(LokacijaFajla);



            file.WriteLineAsync(linija);
        }
      
      public Pregled DobaviJedan()
      {
         // TODO: implement
         return null;
      }
      
      public Pacijent DobaviPacijenta()
      {
         // TODO: implement
         return null;
      }
   
      
   
   }
}