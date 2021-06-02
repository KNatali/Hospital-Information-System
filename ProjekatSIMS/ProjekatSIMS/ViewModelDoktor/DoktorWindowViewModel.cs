using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class DoktorWindowViewModel : BindableBase
    {

        public RelayCommand<string> NavCommand { get; private set; }
    

        private BindableBase currentViewModel;
        private NavigationService navService;


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public void Prikaz()
        {
            PocetnaStranicaDoktorViewModel vm = new PocetnaStranicaDoktorViewModel(this.NavService);
            PocetnaStranicaDoktorView pocetna = new PocetnaStranicaDoktorView(vm);
            this.NavService.Navigate(pocetna);
        }


        public DoktorWindowViewModel(NavigationService navService)
        {

            NavCommand = new RelayCommand<string>(OnNav);

            // CurrentViewModel = pocetnaViewModel;
            this.navService = navService;
            Prikaz();

        }


        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "pocetna":
                    PocetnaStranicaDoktorViewModel vm = new PocetnaStranicaDoktorViewModel(this.NavService);
                    PocetnaStranicaDoktorView pocetna = new PocetnaStranicaDoktorView(vm);
                    this.NavService.Navigate(pocetna);
                    break;
                case "prikazPregleda":
                    PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavService);
                    PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
                    this.NavService.Navigate(kalendar);
                    break;
                case "pretragaPacijenta":
                    PretragaPacijentaDoktorViewModel pp = new PretragaPacijentaDoktorViewModel(this.NavService);
                    PretragaPacijentaDoktorView pretraga = new PretragaPacijentaDoktorView(pp);
                    this.NavService.Navigate(pretraga);
                    break;
                /* case "zakazivanjePregleda":
                     this.NavService.Navigate(
                new Uri("Views/PrikazPregledaDoktorView.xaml", UriKind.Relative));
                     break;
                 case "zakazivanjeOperacije":
                     this.NavService.Navigate(
                new Uri("Views/PrikazPregledaDoktorView.xaml", UriKind.Relative));
                     break;*/
                case "mojProfil":
                    ProfilDoktorViewModel pr = new ProfilDoktorViewModel(this.NavService);
                    ProfilDoktorView d = new ProfilDoktorView(pr);
                    this.NavService.Navigate(d);
                    break;

            }
        }


    }
}
