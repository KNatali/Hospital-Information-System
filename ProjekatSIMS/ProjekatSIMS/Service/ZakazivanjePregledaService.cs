using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class ZakazivanjePregledaService
    {
        public int MAKSIMALNO_OTKAZIVANJA = 10;
        public PregledRepository pregledRepository = new PregledRepository();
    }
}
