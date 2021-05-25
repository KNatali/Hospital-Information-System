using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service
{
    public class PrikazEvidencijeLijekovaService
    {
        private LijekRepository lijekRepository = new LijekRepository();
        public List<Lijek> PrikazLlijekovaPoStatusu(TipLijekaPremaPrikazu tip)
        {
            List<Lijek> sviLijekovi = new List<Lijek>();
            sviLijekovi = lijekRepository.DobaviSve();
            List<Lijek> lijekoviZaPrikaz = DovavljanjeLijekovaPremaStatusu(tip, sviLijekovi);
            return lijekoviZaPrikaz;

        }
        public List<Lijek> DovavljanjeLijekovaPremaStatusu(TipLijekaPremaPrikazu tip,List<Lijek> sviLijekovi)
        {
            List<Lijek> lijekoviIzabranaogStatusa = new List<Lijek>();
            foreach (Lijek l in sviLijekovi)
            {
                if (OdgovarajuciStatus(tip,l))
                    lijekoviIzabranaogStatusa.Add(l);
            }
            return lijekoviIzabranaogStatusa;

        }
        public Boolean OdgovarajuciStatus(TipLijekaPremaPrikazu tip,Lijek lijek)
        {
            if (tip == TipLijekaPremaPrikazu.Verifikovan)
                return lijek.Status != OdobravanjeLekaEnum.Ceka;
            else
                return lijek.Status == OdobravanjeLekaEnum.Ceka;
        }
    }
}
