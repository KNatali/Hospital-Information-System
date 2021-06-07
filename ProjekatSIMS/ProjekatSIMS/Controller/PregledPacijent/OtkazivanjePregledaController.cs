using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
    public class OtkazivanjePregledaController
    {
        public OtkazivanjePregledaService otkazivanjePregledaService = new OtkazivanjePregledaService();

        public void BrojacOtkazivanjaPregleda(String ime, String prezime)
        {
            otkazivanjePregledaService.BrojacOtkazivanjaPregleda(ime,prezime);
        }

        public void ProveraVremenaZakazivanja(DateTime sadasnjeVreme)
        {
            otkazivanjePregledaService.ProveraVremenaZakazivanja(sadasnjeVreme);
        }
    }
}
