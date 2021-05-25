using Model;
using ProjekatSIMS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Repository;

namespace Service
{
    public class IzdavanjeReceptaService
    {
      
        private ReceptRepository receptRepository = new ReceptRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();

        
        public void IzdavanjeRecepta(ReceptDTO receptDTO)
        {

            DateTime datumPrveKonzumacijeLijeka = FormiranjeVremenaPrveKonzumacije(receptDTO);

            string ucestalostKoriscenja = KreiranjeTekstaZaUputstvo(receptDTO);
            Recept r = KreiranjeRecepta(datumPrveKonzumacijeLijeka, ucestalostKoriscenja,receptDTO);
            DodavanjeReceptaUZdravstveniKarton(r,receptDTO.Pacijent);
            receptRepository.DodajRecept(r);
            
        }
        public void DodavanjeReceptaUZdravstveniKarton(Recept recept,Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            if (zdravstveniKarton.Recepti == null)
                zdravstveniKarton.Recepti = new List<Recept>();
            zdravstveniKarton.Recepti.Add(recept);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKarton);
        }
        private DateTime FormiranjeVremenaPrveKonzumacije(ReceptDTO receptDTO)
        {
            DateTime izabraniDatum = receptDTO.DatumPrveKonzumacije;
            DateTime datumPrveKonzumacijeLijeka = izabraniDatum.AddHours(receptDTO.Sat);
            datumPrveKonzumacijeLijeka = datumPrveKonzumacijeLijeka.AddMinutes(receptDTO.Minut);
            return datumPrveKonzumacijeLijeka;
        }

        private Recept KreiranjeRecepta(DateTime datum1, string ucestalostKoriscenja,ReceptDTO receptDTO)
        {
            Recept r = new Recept();
            r.DatumPropisivanjaLeka = datum1;
            r.Kolicina = receptDTO.KolicinaLijeka ;
            r.NazivLeka = receptDTO.NazivLijeka;
            r.Uputstvo = "Terapija traje " +receptDTO.TrajanjeTerapije + " dana i lijek se uzima " + ucestalostKoriscenja;
            return r;
        }

        private string KreiranjeTekstaZaUputstvo(ReceptDTO receptDTO)
        {
            String ucestalostKoriscenja = "";
            if (receptDTO.KolicinaLijeka == "1")
                ucestalostKoriscenja = "svaki dan";
            else if (Convert.ToDouble(receptDTO.PeriodIzmedjuKonzumacija) < 5)
                ucestalostKoriscenja = "svaka " + receptDTO.PeriodIzmedjuKonzumacija + " dana";
            else
                ucestalostKoriscenja = "svakih " + receptDTO.PeriodIzmedjuKonzumacija + " dana";

            return ucestalostKoriscenja;
        }
    }
}
