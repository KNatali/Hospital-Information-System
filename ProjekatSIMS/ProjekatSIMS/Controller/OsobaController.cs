using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class OsobaController
   {
        public Service.OsobaService osobaService = new OsobaService();
        public Model.Pacijent KreiranjeHitnogNalogaController(String jmbg, String ime, String prezime)
      {
         // TODO: implement
         return null;
      }
        public List<Pacijent> DobaviSvePacijenteSekretar()
        {
            return osobaService.DobaviSvePacijente();
        }

    }
}