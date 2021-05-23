using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IzdavanjeAnamnezeService
    {
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        public void KreiranjeAnamneze(String opis, DateTime datumIzdavanja, ZdravsteniKarton karton )
        {
            Anamneza novaAnamneza = new Anamneza(karton,opis,datumIzdavanja);
            List<Anamneza> sveAnamneze = new List<Anamneza>();

            
        }
    }
}
