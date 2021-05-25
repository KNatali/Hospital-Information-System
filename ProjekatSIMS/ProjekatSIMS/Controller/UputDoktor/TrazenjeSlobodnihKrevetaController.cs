using Model;
using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class TrazenjeSlobodnihKrevetaController
    {
        private TrazenjeSlobodnihKrevetaService uputService = new TrazenjeSlobodnihKrevetaService();
        public List<SlobodniKrevetDTO> DobaviSlobodneSobe(IntervalDatuma termin)
        {
          
            return uputService.DobaviSlobodneSobe(termin);
        }

       
    }
}
