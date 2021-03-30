using Model.DoktorModel;
using Model.PacijentModel;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.Model.PacijentModel
{

    public partial class OtkaziWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public OtkaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Pregled.txt");
            Pregledi = fajl.DobaviSve();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItem;
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\Pregled.txt");
            List<Pregled> pregledi = fajl.DobaviSve();
        }
    }
}
