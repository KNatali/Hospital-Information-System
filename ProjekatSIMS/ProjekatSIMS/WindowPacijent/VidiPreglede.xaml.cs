using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class VidiPreglede : Page
    {
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public VidiPreglede()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();
        }
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            PacijentMainWindow pmw = new PacijentMainWindow();
            this.NavigationService.Navigate(pmw);
        }
    }
}
