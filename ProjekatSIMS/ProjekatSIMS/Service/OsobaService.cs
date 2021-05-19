using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class OsobaService
   {
        public Repository.OsobaRepository osobaRepository = new OsobaRepository();
        public Model.Pacijent KreiranjeHitnogNalogaService(String jmbg, String ime, String prezime)
      {
         // TODO: implement
         return null;
      }
        public List<Pacijent> DobaviSvePacijente()
        {
            return osobaRepository.DobaviPacijente();
        }

    }
}