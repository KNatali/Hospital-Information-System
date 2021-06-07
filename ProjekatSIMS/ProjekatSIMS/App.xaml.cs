using Controller;
using ProjekatSIMS.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatSIMS
{
    
    public partial class App : Application
    {
        public App()
        {
            PregledController = new PregledController();
        }

        public PregledController PregledController { get; private set; }
        public NotifikacijaController NotifikacijaController { get; internal set; }
        public PacijentController PacijentController { get; internal set; }
        public NeradniDaniController NeradniDaniController { get; internal set; }
    }
}
