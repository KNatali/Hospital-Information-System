using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.ReceptPacijent
{
   public  class ReceptiPacijentController
    {
        public ReceptRepository receptRepository = new ReceptRepository();

        public List<Recept> DobaviSveRecepte()
        {
           return receptRepository.DobaviSveRecepte();
        }
    }
}
