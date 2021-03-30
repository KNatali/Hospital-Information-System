/***********************************************************************
 * Module:  Pregled.cs
 * Author:  nata1
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;

namespace Model.DoktorModel
{
    public class Pregled
    {
        public Boolean ZakaziPregled()
        {
            // TODO: implement
            return true;
        }

        public Boolean OtkaziPregledDoktor()
        {
            // TODO: implement
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

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoktor</param>
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
        public Model.Pacijent pacijent { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Model.Pacijent GetPacijent()
        {
            return pacijent;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newPacijent</param>
        public void SetPacijent(Model.Pacijent newPacijent)
        {
            if (this.pacijent != newPacijent)
            {
                if (this.pacijent != null)
                {
                    Model.Pacijent oldPacijent = this.pacijent;
                    this.pacijent = null;
                    oldPacijent.RemovePregled(this);
                }
                if (newPacijent != null)
                {
                    this.pacijent = newPacijent;
                    this.pacijent.AddPregled(this);
                }
            }
        }

    }
}