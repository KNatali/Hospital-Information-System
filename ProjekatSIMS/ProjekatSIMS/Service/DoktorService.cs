using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using Model;

namespace Service
{
    public class DoktorService
    {
        public Repository.DoktorRepository doktorRepository = new DoktorRepository();
        public List<Doktor> DobaviSve()
        {
            return doktorRepository.DobaviSve();
        }
    }
}
