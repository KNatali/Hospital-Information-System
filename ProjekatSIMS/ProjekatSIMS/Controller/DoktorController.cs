using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public class DoktorController
    {
        public Service.DoktorService doktorService = new DoktorService();
        public List<Doktor> DobaviSve()
        {
            return doktorService.DobaviSve();
        }
    }
}
