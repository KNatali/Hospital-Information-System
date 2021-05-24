using Model;
using ProjekatSIMS.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Service
{
    public class IzdavanjeUputaBolnickoLijecenjeService
    {
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private UputBolnickoLijecenjeRepository uputRepository = new UputBolnickoLijecenjeRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
        public List<SlobodniKrevetDTO> DobaviSlobodneSobe(DateTime pocetakIntervala, DateTime krajIntervala)
        {

            List<Prostorija> sobe = prostorijaRepository.DobaviSobe();
            return SlobodneSobeISlobodniKreveti(pocetakIntervala, krajIntervala, sobe);

        }

        private List<SlobodniKrevetDTO> SlobodneSobeISlobodniKreveti(DateTime pocetakIntervala, DateTime krajIntervala, List<Prostorija> sobe)
        {
            List<SlobodniKrevetDTO> slobodneSobeIKreveti = new List<SlobodniKrevetDTO>();
            List<int> krevetiId = new List<int>();
            foreach (Prostorija s in sobe)
            {
              
                krevetiId = DobaviKrevete(s);
                List<int> zauzetiKreveti = ZauzetiKrevetiZaInterval(pocetakIntervala, krajIntervala);
                List<int> slobodniKreveti = new List<int>();
                slobodniKreveti = RedukovanjeSlobodnihKreveta(krevetiId, zauzetiKreveti);
             
                if (slobodniKreveti.Count != 0)
                {
                    SlobodniKrevetDTO sk = new SlobodniKrevetDTO(s.id, slobodniKreveti);
                    slobodneSobeIKreveti.Add(sk);
                }

            }
            return slobodneSobeIKreveti;
        }

        public List<int> RedukovanjeSlobodnihKreveta(List<int> krevetiId, List<int> zauzetiKreveti)
        {
            List<int> slobodniKreveti = krevetiId;
            
            foreach (int k in zauzetiKreveti)
            {
                if (krevetiId.Contains(k))
                    slobodniKreveti.Remove(k);
            }
            return slobodniKreveti;
        }

        public List<int> DobaviKrevete(Prostorija soba)
        {
            List<int> krevetiId = new List<int>();
            foreach (Inventar i in soba.inventar)
            {
                if (i.ime == "krevet")
                    krevetiId.Add(i.id);
            }
            return krevetiId;

        }

        private List<int> ZauzetiKrevetiZaInterval(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<int> zauzetiKreveti = new List<int>();
            List<UputBolnickoLijecenje> uputi = uputRepository.DobaviSveUpute();
            if (uputi != null)
            {
                foreach (UputBolnickoLijecenje u in uputi)
                {
                    if (DateTime.Compare(pocetakIntervala, u.IntervalPocetak) >= 0 && DateTime.Compare(pocetakIntervala, u.IntervalKraj) < 0 ||
                         DateTime.Compare(krajIntervala, u.IntervalPocetak) > 0 && DateTime.Compare(krajIntervala, u.IntervalKraj) <= 0)
                        zauzetiKreveti.Add(u.KrevetId);

                }
            }
            return zauzetiKreveti;

        }

        public void CuvanjeUputa(UputBolnickoLijecenje uput,Pacijent pacijent)
        {
            uputRepository.SacuvajUput(uput);
            DodavanjeUputaUZdravstveniKarton(uput, pacijent);
        }

        public void DodavanjeUputaUZdravstveniKarton(UputBolnickoLijecenje uput, Pacijent pacijent)
        {
            ZdravsteniKarton zdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveniKartonZaPacijenta(pacijent);
            
            if (zdravstveniKarton.UputiZaBolnickoLijecenje == null)
                zdravstveniKarton.UputiZaBolnickoLijecenje = new List<UputBolnickoLijecenje>();
            zdravstveniKarton.UputiZaBolnickoLijecenje.Add(uput);
            zdravstveniKartonRepository.AzurirajKarton(zdravstveniKarton);
        }

        
    }
}
