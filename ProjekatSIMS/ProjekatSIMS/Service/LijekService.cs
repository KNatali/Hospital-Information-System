using Model;
using ProjekatSIMS.Model;
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
        public List<Lijek> DobaviPoStatusu(OdobravanjeLekaEnum statusLeka) 
        {
            List<Lijek> lijekovi = new List<Lijek>();
            List<Lijek> trazeniLekovi = new List<Lijek>();
            lijekovi = lijekRepoisitory.DobaviSve();
            foreach(Lijek lijek in lijekovi)
            {
                if(lijek.Status == statusLeka)
                {
                    trazeniLekovi.Add(lijek);
                }

            }
            return trazeniLekovi;
        }
        

    }
}
