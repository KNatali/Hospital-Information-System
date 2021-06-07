using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Controller;
using ProjekatSIMS.Model;
using ProjekatSIMS.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class PocetnaPacijent : Page
    {

        public NedeljnaTerapijaController nedeljnaTerapijaController = new NedeljnaTerapijaController();

        public List<NedeljnaTerapija> Terapija { get; set; }
       
        public Pacijent trenutniPacijent { get; set; }

        public PocetnaPacijent(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;

            Terapija = nedeljnaTerapijaController.DobaviSve();

            
        }

        private void OceniBolnicu(object sender, RoutedEventArgs e)
        {
            OceniBolnicuPacijent ob = new OceniBolnicuPacijent();
            this.NavigationService.Navigate(ob);


        }

        private void OceniLekara(object sender, RoutedEventArgs e)
        {
            OceniLekaraPacijent ol = new OceniLekaraPacijent();
            this.NavigationService.Navigate(ol);
        }

        private void KreirajPodsetnik(object sender, RoutedEventArgs e)
        {
            KreiranjePodsetnika kp = new KreiranjePodsetnika(trenutniPacijent);
            this.NavigationService.Navigate(kp);
        }
        private void PregledLekara(object sender, RoutedEventArgs e)
        {
            PregledLekara pl = new PregledLekara();
            this.NavigationService.Navigate(pl);
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Vidite lekare");
        }
    }
}
