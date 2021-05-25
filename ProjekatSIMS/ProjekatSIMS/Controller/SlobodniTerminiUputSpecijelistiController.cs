using ProjekatSIMS.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class SlobodniTerminiUputSpecijelistiController
    {
        private SlobodniTerminiUputSpecijalistiService slobodniTerminiUputSpecijalistiService = new SlobodniTerminiUputSpecijalistiService();

        public List<DateTime> PrikazSlobodnihTermina(SlobodniTerminiUputSpecijalistiDTO podaci)
        {
            return slobodniTerminiUputSpecijalistiService.PrikazSlobodnihTermina(podaci);
        }
    }
}
