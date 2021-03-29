

using System;
using System.Collections.Generic;
using System.IO;

namespace Model.SekretarModel
{
   public class CuvanjePacijenta
   {
        public CuvanjePacijenta() { }
        public CuvanjePacijenta(String lokacije)
        {
            lokacija = lokacije;
        }
      public void Sacuvaj(Pacijent pacijent)
      {
            String linija = "";

            String jmbg = pacijent.Jmbg.ToString();
            String ime = pacijent.Ime.ToString();
            String prezime = pacijent.Prezime.ToString();
            String telefon = pacijent.BrojTelefona.ToString();
            String email = pacijent.Email.ToString();
            String datum = pacijent.DatumRodjenja.ToLongDateString();
            String adresa = pacijent.Adresa.ToString();

            linija += jmbg + "," + ime + "," + prezime + "," + telefon + "," + email + "," + datum + "," + adresa;
            using StreamWriter file = new StreamWriter(lokacija);
            file.WriteLineAsync(linija);
        }
      
      public List<Pacijent> DobaviPacijente()
      {
         // TODO: implement
         return null;
      }
      
      public Sekretar DobaviSekretara()
      {
         // TODO: implement
         return null;
      }
   
      private String lokacija;
   
   }
}