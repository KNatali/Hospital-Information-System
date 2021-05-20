using Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class LijekService
    {
        public LijekRepository lijekRepoisitory = new LijekRepository();

        public LijekService() { }
        public List<Lijek> DobaviOdobrene()
        {
            List<Lijek> lijekovi = new List<Lijek>();
            List<Lijek> odobreniLekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            foreach(Lijek lijek in lijekovi)
            {
                if(lijek.Status == 0)
                {
                    odobreniLekovi.Add(lijek);
                }

            }
            return odobreniLekovi;
        }
        public List<Lijek> DobaviOdbijene()
        {
            List<Lijek> lijekovi = new List<Lijek>();
            List<Lijek> odbijeniLekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            foreach (Lijek lijek in lijekovi)
            {
                if (lijek.Status == Model.OdobravanjeLekaEnum.Odbijen)
                {
                    odbijeniLekovi.Add(lijek);
                }

            }
            return odbijeniLekovi;
        }

    }
}
