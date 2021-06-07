using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.UputiPacijent
{
    public class UputController
    {
       public  UputRepository uputRepository = new UputRepository();
        public List<Uput> DobaviUpute()
        {
            return uputRepository.DobaviUpute();
        }
    }
}
