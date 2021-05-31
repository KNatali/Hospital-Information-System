using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;

namespace Service
{
    public class VerifikovanjeLijekovaService
    {
        private LijekRepository lijekRepository = new LijekRepository();
        public void OdobriLijek(Lijek lijek )
        {
            List<Lijek> sviLijekovi = new List<Lijek>();
            sviLijekovi = lijekRepository.DobaviSve();
            sviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).Status = OdobravanjeLekaEnum.Odobren;
            lijekRepository.Sacuvaj(sviLijekovi);
        }

        public void OdbaciLijek(Lijek lijek,String poruka)
        {
            List<Lijek> sviLijekovi = new List<Lijek>();
            sviLijekovi = lijekRepository.DobaviSve();
            sviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).Status = OdobravanjeLekaEnum.Odbijen;
            sviLijekovi.Find(p => p.NazivLeka == lijek.NazivLeka).PorukaOdbaci =poruka;
            lijekRepository.Sacuvaj(sviLijekovi);

        }
    }
}
