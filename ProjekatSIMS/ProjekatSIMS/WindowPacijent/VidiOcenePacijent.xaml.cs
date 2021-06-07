using Model;
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
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
        public OcenaController ocenaController = new OcenaController();
        public Pacijent trenutniPacijent { get; set; }
        public VidiOcenePacijent(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            OceneLekara = new List<OcenaLekara>();
            OceneLekara = ocenaController.DobaviSveOceneLekara();
            OceneBolnice = new List<OcenaBolnice>();
            OceneBolnice = ocenaController.DobaviSveOceneBolnice();
        }

        private void Zatvori(object sender, System.Windows.RoutedEventArgs e)
        {
            PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }
    }
}
