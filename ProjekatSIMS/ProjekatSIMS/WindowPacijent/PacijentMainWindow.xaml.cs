
using Controller;
using Microsoft.Toolkit.Uwp.Notifications;
using Model;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Controller.ReceptPacijent;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PacijentMainWindow : Window
    {
        private NavigationService NavigationService { get; set; }
        public PodsetnikController podsetnikController = new PodsetnikController();
        public ReceptiPacijentController receptiController = new ReceptiPacijentController();
        public ZakazivanjePregledaController zakazivanjePregledaController = new ZakazivanjePregledaController();
        public Pacijent trenutniPacijent { get; set; }
        public String imePrezime { get; set; }
        


        public PacijentMainWindow(Pacijent pacijent)
        {

            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            imePrezime = trenutniPacijent.Ime + " " + trenutniPacijent.Prezime;
            PacijentFrame.Content = new PocetnaPacijent(trenutniPacijent);
            List<Podsetnik> podsetnici = podsetnikController.DobaviSvePodsetnike();
            List<Pregled> pregledi = zakazivanjePregledaController.DobaviPregledeZaPacijenta(trenutniPacijent);
            List<Recept>Recepti = receptiController.DobaviSveRecepte();

            foreach(Pregled preg in pregledi)
            {
                int vremePregleda = DateTime.Compare(preg.Pocetak.AddDays(-1), DateTime.UtcNow);
                if(vremePregleda == 0)
                {
                    {
                        new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddText("Imate zakazan pregled u ")
                        .AddText(preg.Pocetak.ToString())
                        .Show();
                    }
                }
            }


            foreach (Podsetnik p in podsetnici)
            {
                if (podsetnikController.DaLiTrebaPoslatiObavestenje(p.datumZavrsetkaObavestenja, p.datumPocetkaObavestenja) == true)
                {
                    {
                        new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddText(p.nazivPodsetika)
                       .AddText(p.opisPodsetnika)
                       .Show(
                            toast =>
                            {
                                toast.ExpirationTime = DateTime.UtcNow.AddMinutes(10);
                            }
                            );
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
            PacijentFrame.Content = new ZakaziPregled(trenutniPacijent);
        }

        private void VidiPreglede(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new VidiPreglede(trenutniPacijent);
        }

        private void IzmeniPregled(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new IzmeniPregledPacijenta(trenutniPacijent);
        }

        private void OceniBolnicu(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new OceniBolnicuPacijent();
        }

        private void OceniLekara(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new OceniLekaraPacijent();
        }

        private void KreirajPodsetnik(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new KreiranjePodsetnika(trenutniPacijent);
        }

        private void VidiPodsetnike(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new PregledPodsetnika();
        }

        private void IzmeniPodsetnik(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new IzmenaPodsetnika(trenutniPacijent);
        }

        private void PregledajKarton(object sender, RoutedEventArgs e)
        {
           PacijentFrame.Content = new PregledajZdravstveniKarton(trenutniPacijent);
        }
        private void PocetnaStranica(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new PocetnaPacijent(trenutniPacijent);
        }

        private void OdjaviSe(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VidiOcene(object sender, RoutedEventArgs e)
        {
            PacijentFrame.Content = new VidiOcenePacijent(trenutniPacijent);
        }
    }
}
