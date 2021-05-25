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

            List<Prostorija> sobe = prostorijaRepository.DobaviSobe();
            return SlobodneSobeISlobodniKreveti(termin, sobe);

        }

        private List<SlobodniKrevetDTO> SlobodneSobeISlobodniKreveti(IntervalDatuma termin, List<Prostorija> sobe)
        {
            List<SlobodniKrevetDTO> slobodneSobeIKreveti = new List<SlobodniKrevetDTO>();
            List<int> krevetiId = new List<int>();
            foreach (Prostorija s in sobe)
            {
                krevetiId = DodavanjeSlobodnihKreveta(termin, slobodneSobeIKreveti, s);

            }
            return slobodneSobeIKreveti;
        }

        private List<int> DodavanjeSlobodnihKreveta(IntervalDatuma termin, List<SlobodniKrevetDTO> slobodneSobeIKreveti, Prostorija s)
        {
            List<int> krevetiId = DobaviKrevete(s);
            List<int> zauzetiKreveti = ZauzetiKrevetiZaInterval(termin);
            List<int> slobodniKreveti = new List<int>();
            slobodniKreveti = RedukovanjeSlobodnihKreveta(krevetiId, zauzetiKreveti);

            if (slobodniKreveti.Count != 0)
            {
                SlobodniKrevetDTO sk = new SlobodniKrevetDTO(s.id, slobodniKreveti);
                slobodneSobeIKreveti.Add(sk);
            }

            return krevetiId;
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

        private List<int> ZauzetiKrevetiZaInterval(IntervalDatuma termin)
        {
            List<int> zauzetiKreveti = new List<int>();
            List<UputBolnickoLijecenje> uputi = uputRepository.DobaviSveUpute();
            if (uputi != null)
            {
                foreach (UputBolnickoLijecenje u in uputi)
                {
                    if (DaLiSeTerminiPoklapaju(termin, u))
                        zauzetiKreveti.Add(u.KrevetId);

                }
            }
            return zauzetiKreveti;

        }

        private static bool DaLiSeTerminiPoklapaju(IntervalDatuma termin, UputBolnickoLijecenje u)
        {
            return DateTime.Compare(termin.PocetnoVrijeme, u.IntervalPocetak) >= 0 && DateTime.Compare(termin.PocetnoVrijeme, u.IntervalKraj) < 0 ||
                                     DateTime.Compare(termin.KrajnjeVrijeme, u.IntervalPocetak) > 0 && DateTime.Compare(termin.KrajnjeVrijeme, u.IntervalKraj) <= 0;
        }


    }
}
