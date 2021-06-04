using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AzuriranjeAnamnezeService
    {
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();

        public void AzuriranjeAnamneze(Anamneza staraAnamneza, String noviOpis)
        {
            staraAnamneza.OpisAnamneze = noviOpis;
            anamnezaRepository.AzurirajAnamnezu(staraAnamneza);

           /* ZdravsteniKarton kartonPacijenta = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            kartonPacijenta.anamneza = PostavljanjeNovogOpisaZaIzabranuAnamnezu(staraAnamneza, noviOpis, kartonPacijenta);
            zdravstveniKartonRepository.AzurirajKarton(kartonPacijenta);*/

        }

        /*private List<Anamneza> PostavljanjeNovogOpisaZaIzabranuAnamnezu(Anamneza staraAnamneza, string noviOpis, ZdravsteniKarton kartonPacijenta)
        {
            List<Anamneza> anamnezePacijenta = kartonPacijenta.anamneza;

            foreach (Anamneza a in anamnezePacijenta)
            {
                if (DateTime.Compare(a.Datum, staraAnamneza.Datum) == 0 & a.OpisAnamneze == staraAnamneza.OpisAnamneze)
                    a.OpisAnamneze = noviOpis;
            }
            return anamnezePacijenta;
        }*/
    }
}
