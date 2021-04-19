using System;

namespace Model
{
   public class Osoba
   {
      public String Jmbg { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Email { get; set; }
        public String Adresa { get; set; }
        public String BrojTelefona { get; set; }

        public RegistrovaniKorisnik registrovaniKorisnik;
      public Notifikacija notifikacija;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Notifikacija GetNotifikacija()
      {
         return notifikacija;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newNotifikacija</param>
      public void SetNotifikacija(Notifikacija newNotifikacija)
      {
         if (this.notifikacija != newNotifikacija)
         {
            if (this.notifikacija != null)
            {
               Notifikacija oldNotifikacija = this.notifikacija;
               this.notifikacija = null;
               oldNotifikacija.RemoveOsoba(this);
            }
            if (newNotifikacija != null)
            {
               this.notifikacija = newNotifikacija;
               this.notifikacija.AddOsoba(this);
            }
         }
      }
   
   }
}