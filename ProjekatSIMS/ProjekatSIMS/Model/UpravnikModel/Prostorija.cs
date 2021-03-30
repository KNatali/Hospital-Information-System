using Model.DoktorModel;
using ProjekatSIMS.Model.UpravnikModel;
using System;
using System.Collections.Generic;

namespace Model.UpravnikModel
{
    public class Prostorija
    {
        public Boolean Obrisi()
        {
            // TODO: implement
            return true;
        }

        public String id { get; set; }
        public int sprat { get; set; }
        public EnumProstorija vrsta { get; set; }
        public List<Inventar> inventar;
        public Prostorija()
        { }
        public Prostorija(String id, int sprat, EnumProstorija vrsta)
        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = vrsta;

        }
        public Prostorija(String id, int sprat, EnumProstorija vrsta, List<Inventar> inventar)
        {
            this.id = id;
            this.sprat = sprat;
            this.vrsta = vrsta;
            this.inventar = inventar;

        }
        


        public List<Inventar> GetInventar()
        {
            if (inventar == null)
                inventar = new List<Inventar>();
            return inventar;
        }


        public void SetInventar(List<Inventar> newInventar)
        {
            RemoveAllInventar();
            foreach (Inventar oInventar in newInventar)
                AddInventar(oInventar);
        }


        public void AddInventar(Inventar newInventar)
        {
            if (newInventar == null)
                return;
            if (this.inventar == null)
                this.inventar = new List<Inventar>();
            if (!this.inventar.Contains(newInventar))
                this.inventar.Add(newInventar);
        }


        public void RemoveInventar(Inventar oldInventar)
        {
            if (oldInventar == null)
                return;
            if (this.inventar != null)
                if (this.inventar.Contains(oldInventar))
                    this.inventar.Remove(oldInventar);
        }


        public void RemoveAllInventar()
        {
            if (inventar != null)
                inventar.Clear();
        }
        public Pregled[] pregled;

    




    }
}