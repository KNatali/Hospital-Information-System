using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    
    public partial class VidiOcenePacijent : Page
    {
        public List<OcenaLekara> OceneLekara
        {
            get;
            set;
        }

        public List<OcenaBolnice> OceneBolnice
        {
            get;
            set;
        }
        public VidiOcenePacijent()
        {
            InitializeComponent();
            this.DataContext = this;
            OceneLekara = new List<OcenaLekara>();
            OcenaRepository fajl = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
            OceneLekara = fajl.DobaviSveOceneLekara();
            OceneBolnice = new List<OcenaBolnice>();
            OcenaRepository file = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
            OceneBolnice = file.DobaviSveOceneBolnice();
        }
    }
}
