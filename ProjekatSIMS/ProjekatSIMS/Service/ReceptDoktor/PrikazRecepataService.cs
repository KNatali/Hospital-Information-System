using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service.ReceptDoktor
{
    public class PrikazRecepataService
    {
        private ReceptRepository receptRepository = new ReceptRepository();
        public List<Recept> PrikazRecepata(int id)
        {
            return receptRepository.DobaviRecepteZaKarton(id);
        }
    }
}
