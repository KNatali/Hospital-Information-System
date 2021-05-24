
using Controller;
using Microsoft.Toolkit.Uwp.Notifications;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
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
        public PodsetnikController podsetnikController = new PodsetnikController();
        public ReceptRepository receptRepository = new ReceptRepository(@"..\..\..\Fajlovi\Recept.txt");

        public PacijentMainWindow()
        {
            InitializeComponent();
            List<Podsetnik> podsetnici = podsetnikRepository.DobaviSvePodsetnike();
            List<Recept>Recepti = receptRepository.DobaviSveRecepte();
            foreach (Podsetnik p in podsetnici)
            {
                if (podsetnikController.DaLiTrebaPoslatiObavestenje(p.datumZavrsetkaObavestenja, p.datumPocetkaObavestenja) == true)
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


            foreach (Recept r in Recepti)
            {
                int vremePrikazivanjaObavestenja = DateTime.Compare(r.DatumPropisivanjaLeka.AddHours(-4), DateTime.UtcNow);

                if (vremePrikazivanjaObavestenja > 0)
                {
                    {
                        new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddText("Danas treba da uzmete svoju terapiju")
                       .AddText(r.NazivLeka + " " + r.Kolicina + " " + r.Uputstvo + ", uzeti u " + r.DatumPropisivanjaLeka.TimeOfDay.ToString())
                       .Show(toast =>
                       {
                           toast.ExpirationTime = DateTime.UtcNow.AddDays(2);
                       }

                            );

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
