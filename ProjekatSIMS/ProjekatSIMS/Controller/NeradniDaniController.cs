using System;
using Model;
using Service;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller
{
    public class NeradniDaniController
    {
        public Service.NeradniDaniService neradniDaniService = new Service.NeradniDaniService();
        public List<NeradniDani> DobaviSve()
        {
            return neradniDaniService.DobaviSve();
        }
    }
}
