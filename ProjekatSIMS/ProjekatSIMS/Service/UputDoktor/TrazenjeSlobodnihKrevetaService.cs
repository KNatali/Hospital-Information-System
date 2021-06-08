using Model;
using ProjekatSIMS.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Service
{
    public class TrazenjeSlobodnihKrevetaService
    {
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private UputBolnickoLijecenjeRepository uputRepository = new UputBolnickoLijecenjeRepository();

        public List<SlobodniKrevetDTO> DobaviSlobodneSobe(IntervalDatuma termin)
        {

            List<Prostorija> sobe = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Soba);
            List<int> zauzetiKreveti = ZauzetiKrevetiZaInterval(termin);
            return SlobodneSobeISlobodniKreveti(zauzetiKreveti, sobe);

        }

        private List<SlobodniKrevetDTO> SlobodneSobeISlobodniKreveti(List<int> zauzetiKreveti, List<Prostorija> sobe)
        {
           List<SlobodniKrevetDTO> slobodneSobeIKreveti = new List<SlobodniKrevetDTO>();
           foreach (Prostorija s in sobe)
            {
                List<int> krevetiId = prostorijaRepository.DobaviKreveteZaSobu(s);
                List<int> slobodniKreveti = RedukovanjeSlobodnihKreveta(krevetiId, zauzetiKreveti);

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

      

        private List<int> ZauzetiKrevetiZaInterval(IntervalDatuma termin)
        {
            List<int> zauzetiKreveti = new List<int>();
            List<UputBolnickoLijecenje> uputi = uputRepository.DobaviSveUpute();
            if (uputi != null)
            {
                foreach (UputBolnickoLijecenje u in uputi)
                {
                    if (termin.DaLiSeTerminiPoklapaju( u.Interval))
                        zauzetiKreveti.Add(u.KrevetId);

                }
            }
            return zauzetiKreveti;

        }

       

    }
}
