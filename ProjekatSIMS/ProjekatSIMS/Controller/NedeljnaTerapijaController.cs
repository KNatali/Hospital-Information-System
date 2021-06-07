using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
    public class NedeljnaTerapijaController
    {
        public NedeljnaTerapijaRepository nedeljna = new NedeljnaTerapijaRepository();

        public List<NedeljnaTerapija> DobaviSve()
        {
            return nedeljna.DobaviSve();
        }
    }
}
