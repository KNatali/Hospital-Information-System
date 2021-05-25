using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class IzmjenaPregledaDoktorController
    {
        private IzmjenaPregledaDoktorService izmjenaPregledaDoktorService = new IzmjenaPregledaDoktorService();
    
        public void IzmjeniPregled(Pregled stariPregled,DateTime noviTermin)
        {
            izmjenaPregledaDoktorService.IzmjeniPregled(stariPregled, noviTermin);
        }
    }
}
