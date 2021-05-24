using System;
using Model;
using Repository;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class NeradniDaniService
    {
        public NeradniDaniRepository neradniDaniRepository = new NeradniDaniRepository(@"..\..\..\Fajlovi\NeradniDani.txt");
        public List<NeradniDani> DobaviSve()
        {
            return neradniDaniRepository.DobaviNeradneDane();
        }
    }
}
