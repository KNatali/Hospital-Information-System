using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AzuriranjeAnamnezeService
    {
        
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();

        public void AzuriranjeAnamneze(Anamneza staraAnamneza, String noviOpis)
        {
            staraAnamneza.OpisAnamneze = noviOpis;
            anamnezaRepository.AzurirajAnamnezu(staraAnamneza);

           

        }

       
    }
}
