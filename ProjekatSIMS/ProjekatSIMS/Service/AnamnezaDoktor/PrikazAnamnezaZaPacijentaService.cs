using Model;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class PrikazAnamnezaZaPacijentaService
    {
       
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        public List<Anamneza> PrikazAnamneza(Pacijent pacijent)
        {
            List<Anamneza> anamneze = new List<Anamneza>();
            anamneze = anamnezaRepository.DobaviAnamnezeZaKarton(pacijent.IdKartona);
            return anamneze;
          
        }


    }
}
