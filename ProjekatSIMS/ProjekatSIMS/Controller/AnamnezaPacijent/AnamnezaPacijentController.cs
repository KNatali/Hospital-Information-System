using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.AnamnezaPacijent
{
    public class AnamnezaPacijentController
    {
        public AnamnezaRepository anamnezaRepository = new AnamnezaRepository();

        public List<Anamneza> DobaviSve()
        {
            return anamnezaRepository.DobaviSve();
        }
    }
}
