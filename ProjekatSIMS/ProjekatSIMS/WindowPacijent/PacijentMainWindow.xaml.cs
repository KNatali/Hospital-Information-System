
using Microsoft.Toolkit.Uwp.Notifications;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PacijentMainWindow : Window
    {
        private NavigationService NavigationService { get; set; }
        public PodsetnikRepository podsetnikRepository = new PodsetnikRepository();

        public PacijentMainWindow()
        {
            InitializeComponent();
            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnike();
            foreach (Podsetnik p in podsetnici)
            {
                int res1 = DateTime.Compare(p.datumZavrsetkaObavestenja, DateTime.UtcNow);
                int res2 = DateTime.Compare(p.datumPocetkaObavestenja, DateTime.UtcNow);

                if ((res1 < 0) && (res2 < 0))
                {
                    {
                        new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddText(p.nazivPodsetika)
                       .AddText(p.opisPodsetnika)
                       .Show();

                    }
                }
            }

        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new ZakaziPregled();
        }

        private void VidiPreglede(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new VidiPreglede();
        }

        private void IzmeniPregled(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new IzmeniPregledPacijenta();
        }

        private void OceniBolnicu(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new OceniBolnicuPacijent();
        }

        private void OceniLekara(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new OceniLekaraPacijent();
        }

        private void VidiOcene(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new VidiOcenePacijent();
        }

        private void KreirajPodsetnik(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new KreiranjePodsetnika();
        }

        private void VidiPodsetnike(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new PregledPodsetnika();
        }

        private void IzmeniPodsetnik(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new IzmenaPodsetnika();
        }

        private void PregledajKarton(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new PregledajZdravstveniKarton();
        }
    }
}
