using Model.DoktorModel;
using Model.PacijentModel;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.Model.PacijentModel
{

    public partial class VidiWindow : Window
    {
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public VidiWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Pregled.txt");
            Pregledi = fajl.DobaviSve();


        }

    }
}
