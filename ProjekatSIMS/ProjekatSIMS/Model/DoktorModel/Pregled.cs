/***********************************************************************
 * Module:  Pregled.cs
 * Author:  nata1
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Model.DoktorModel
{
    public class Pregled
    {
        public Boolean ZakaziPregled()
        {
            
            return true;
        }

        public Boolean OtkaziPregledDoktor()
        {
            string line;
            List<String> lines = new List<string>();

            using (StreamReader file = new StreamReader(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt"))
            {

                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");
                    if (parts[0] != this.Id.ToString())  //svi redovi iz fajla se prepisuju sem onoga gdje se id poklapa
                    {
                        lines.Add(line);
                    }
                }

                file.Close();
            }
            File.WriteAllLinesAsync(@"C:\Users\nata1\Projekat\ProjekatSIMS\Pregled.txt", lines);
            return true;

        }

        public Boolean PomjeriPregledDoktor()
        {
            // TODO: implement
            return true;
        }

        public void ZapocniPregledDoktor()
        {
            // TODO: implement
        }

        public void ZavrsiPregledDoktor()
        {
            // TODO: implement
        }

        public Boolean OtkaziPregledPacijent()
        {
            // TODO: implement
            return true;
        }

        public Boolean IzmeniPregledPacijent(DateTime datumPregleda, Model.Doktor doktor)
        {
            // TODO: implement
            return true;
        }


        public void PrikaziPregledePacijent()
        {
            // TODO: implement
        }

        public Pregled ZakaziPregledePacijent()
        {
            // TODO: implement
            return null;
        }

        public int Id { get; set; }
        public DateTime Pocetak { get; set; }
        public int Trajanje { get; set; }
        public TipPregleda Tip { get; set; }
        public Model.PacijentModel.StatusPregleda StatusPregleda { get; set; }

        public Model.UpravnikModel.Prostorija prostorija { get; set; }
        public Model.Doktor doktor { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Model.Doktor GetDoktor()
        {
            return doktor;
        }

      public void SetDoktor(Model.Doktor newDoktor)
      {
         if (this.doktor != newDoktor)
         {
            if (this.doktor != null)
            {
               Model.Doktor oldDoktor = this.doktor;
               this.doktor = null;
               oldDoktor.RemovePregled(this);
            }
            if (newDoktor != null)
            {
               this.doktor = newDoktor;
               this.doktor.AddPregled(this);
            }
         }
      }
        public Model.Pacijent pacijent;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Model.Pacijent GetPacijent()
      {
         return pacijent;
      }

        public void SetPacijent(Model.Pacijent newPacijent)
        {
            if (this.pacijent != newPacijent)
            {
                if (this.pacijent != null)

                {
                    if (this.doktor != null)
                    {
                        Model.Doktor oldDoktor = this.doktor;
                        this.doktor = null;
                        oldDoktor.RemovePregled(this);
                    }
                   
                }
            }
        }
        

       

           


        

    }
}