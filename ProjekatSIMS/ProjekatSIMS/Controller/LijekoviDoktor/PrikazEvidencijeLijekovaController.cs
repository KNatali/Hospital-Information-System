using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class PrikazEvidencijeLijekovaController
    {
        private PrikazEvidencijeLijekovaService prikazEvidenicijeLijekovaService = new PrikazEvidencijeLijekovaService();
    
        public List<Lijek> PrikazLijekovaPoStatusu(TipLijekaPremaPrikazu tip)
        {
            return prikazEvidenicijeLijekovaService.PrikazLlijekovaPoStatusu(tip);
        }
    }
}
