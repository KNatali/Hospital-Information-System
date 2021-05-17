using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class Podsetnikservice
    {
        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();

        public Boolean kreiranjePodsetnika()
        {
            return true;
        }
    }
}
