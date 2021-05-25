using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class InventarService
   {

        public InventarRepository inventarRepository = new InventarRepository();
   
        public InventarService() { }

        public Inventar pronadjiInventarPoId(int idTrazenogInventara)
        {
            List<Inventar> inventar = new List<Inventar>();
            inventar = inventarRepository.DobaviSavInventar();
            foreach(Inventar i in inventar)
            {
                if(i.id == idTrazenogInventara)
                {
                    return i;
                }
            }
            return null;
        }
   }
}