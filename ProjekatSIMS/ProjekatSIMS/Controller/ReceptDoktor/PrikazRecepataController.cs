using Model;
using ProjekatSIMS.Service.ReceptDoktor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.ReceptDoktor
{
    public class PrikazRecepataController
    {
        private PrikazRecepataService prikazRecepataService = new PrikazRecepataService();

        public List<Recept> PrikazRecepata(int id)
        {
            return prikazRecepataService.PrikazRecepata(id);
        }
    }
}
