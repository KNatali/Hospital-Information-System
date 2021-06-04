using Model;
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
        public Pacijent trenutniPacijent { get; set; }
        public VidiOcenePacijent(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            OceneLekara = new List<OcenaLekara>();
            OcenaRepository fajl = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
            OceneLekara = fajl.DobaviSveOceneLekara();
            OceneBolnice = new List<OcenaBolnice>();
            OcenaRepository file = new OcenaRepository(@"..\..\..\Fajlovi\OcenaBolnice.txt");
            OceneBolnice = file.DobaviSveOceneBolnice();
        }

        private void Zatvori(object sender, System.Windows.RoutedEventArgs e)
        {
            Pocetna pocetna = new Pocetna(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }
    }
}
