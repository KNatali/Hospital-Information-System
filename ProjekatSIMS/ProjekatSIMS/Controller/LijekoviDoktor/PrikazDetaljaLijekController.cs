using Model;
using ProjekatSIMS.DTO;
using ProjekatSIMS.Service.LijekoviDoktor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.LijekoviDoktor
{
    public class PrikazDetaljaLijekController
    {
        private PrikazDetaljaLijekaService prikazDetaljaLijekaService = new PrikazDetaljaLijekaService();

        public LijekDetaljiDTO PrikazDetalja(Lijek selectedLijek)
        {
            return prikazDetaljaLijekaService.PrikazDetalja(selectedLijek);

        }
    }
}
