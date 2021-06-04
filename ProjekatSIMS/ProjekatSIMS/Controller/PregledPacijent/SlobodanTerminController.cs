using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
    public class SlobodanTerminController
    {

        public SlobodanTerminRepository slobodanTerminRepository = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
        public List<SlobodanTermin> DobaviSlobodneTermineZaDatum(DateTime datum)
        {
            return slobodanTerminRepository.DobaviSveSlobodneTermineZaDatum(datum);
        }
        public List<SlobodanTermin> DobaviSlobodneTermineZaLekara(String imeDoktora, String prezimeDoktora)
        {
            return slobodanTerminRepository.DobaviSveSlobodneTermineZaDoktora(imeDoktora,prezimeDoktora);
        }

    }
}
