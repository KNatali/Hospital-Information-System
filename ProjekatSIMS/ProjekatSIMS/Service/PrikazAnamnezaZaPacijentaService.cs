using Model;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class PrikazAnamnezaZaPacijentaService
    {
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        public List<Anamneza> PrikazAnamneza(Pacijent pacijent)
        {
            List<Anamneza> anamneze = new List<Anamneza>();
            ZdravsteniKarton karton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            if (karton.anamneza != null)
            {
                foreach (Anamneza a in karton.anamneza)
                    anamneze.Add(a);

            }
            return anamneze;
        }


    }
}
