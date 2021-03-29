
using Model.UpravnikModel;
using System;

namespace Model
{
   public class Upravnik
   {
      public String id { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String email { get; set; }
        public String telefon { get; set; }

        public RegistrovaniKorisnik registrovaniKorisnik { get; set; }
        public System.Collections.ArrayList prostorija;
      
      
      public System.Collections.ArrayList GetProstorija()
      {
         if (prostorija == null)
            prostorija = new System.Collections.ArrayList();
         return prostorija;
      }
      
      public void SetProstorija(System.Collections.ArrayList newProstorija)
      {
         RemoveAllProstorija();
         foreach (Prostorija oProstorija in newProstorija)
            AddProstorija(oProstorija);
      }
      
      public void AddProstorija(Prostorija newProstorija)
      {
         if (newProstorija == null)
            return;
         if (this.prostorija == null)
            this.prostorija = new System.Collections.ArrayList();
         if (!this.prostorija.Contains(newProstorija))
            this.prostorija.Add(newProstorija);
      }
      
     
      public void RemoveProstorija(Prostorija oldProstorija)
      {
         if (oldProstorija == null)
            return;
         if (this.prostorija != null)
            if (this.prostorija.Contains(oldProstorija))
               this.prostorija.Remove(oldProstorija);
      }
      
     
      public void RemoveAllProstorija()
      {
         if (prostorija != null)
            prostorija.Clear();
      }
   
   }
}