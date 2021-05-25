using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IzdavanjeAnamnezeService
    {
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        public void KreiranjeAnamneze(String opis, DateTime datumIzdavanja,Pacijent pacijent )
        {
            Anamneza novaAnamneza = new Anamneza(opis,datumIzdavanja);
            ZdravsteniKarton zdravstveniKartonPacijenta=zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            if (zdravstveniKartonPacijenta.anamneza == null)
               zdravstveniKartonPacijenta.anamneza = new List<Anamneza>();
            zdravstveniKartonPacijenta.anamneza.Add(novaAnamneza);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKartonPacijenta);


        }
    }
}
