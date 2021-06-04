using Model;
using ProjekatSIMS.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class IzdavanjeAnamnezeService
    {
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        public void KreiranjeAnamneze(AnamnezaDTO anamnezaDTO )
        {
            List<Anamneza> sve = anamnezaRepository.DobaviSve();
            Anamneza novaAnamneza = new Anamneza(GenerisiId(sve), anamnezaDTO.Opis, anamnezaDTO.Datum, anamnezaDTO.IdKartona); ;
            DodavanjeAnamnezeUKarton(anamnezaDTO, novaAnamneza);
            anamnezaRepository.Sacuvaj(novaAnamneza);


        }

        private void DodavanjeAnamnezeUKarton(AnamnezaDTO anamnezaDTO, Anamneza novaAnamneza)
        {
            ZdravsteniKarton zdravstveniKartonPacijenta = zdravstveniKartonRepository.DobaviZdravstveniKartonById(anamnezaDTO.IdKartona);
            if (zdravstveniKartonPacijenta.anamneza == null)
                zdravstveniKartonPacijenta.anamneza = new List<int>();
            zdravstveniKartonPacijenta.anamneza.Add(novaAnamneza.Id);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKartonPacijenta);
        }

        public int GenerisiId(List<Anamneza> anamneze)
        {
            if (anamneze ==null)
                return 1;

            else
                return anamneze[anamneze.Count - 1].Id + 1;

        }
    }
}
