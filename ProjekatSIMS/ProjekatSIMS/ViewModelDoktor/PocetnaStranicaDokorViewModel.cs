using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using Model;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class PocetnaStranicaDoktorViewModel : BindableBase
    {
        private NavigationService navService;

        private RelayCommand prikazLijekova;
        private RelayCommand modifikacijaInventara;
        private RelayCommand izvjestajLijekova;

        public RelayCommand PrikazLijekova
        {
            get { return prikazLijekova; }
            set
            {
                prikazLijekova = value;
            }
        }

        public RelayCommand ModifikacijaInventara
        {
            get { return modifikacijaInventara; }
            set
            {
                modifikacijaInventara = value;
            }
        }

        public RelayCommand IzvjestajLijekova
        {
            get { return izvjestajLijekova; }
            set
            {
                izvjestajLijekova = value;
            }
        }


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public void Executed_PrikazLijekova()
        {
            EvidencijaLijekovaNovoViewModel e = new EvidencijaLijekovaNovoViewModel(this.NavService, TipLijekaPremaPrikazu.Neverifikovan);
            EvidencijaLIjekovaNovo evi = new EvidencijaLIjekovaNovo(e);
            this.NavService.Navigate(evi);
           /* EvidencijaLijekovaViewModel e = new EvidencijaLijekovaViewModel(this.NavService,TipLijekaPremaPrikazu.Neverifikovan);
            EvidencijaLijekovaView lijekovi = new EvidencijaLijekovaView(e);
            this.NavService.Navigate(lijekovi);*/

        }

        public void Executed_ModifikacijaInventara()
        {
            ModifikacijaInventaraDoktor modifikacija = new ModifikacijaInventaraDoktor();
            this.navService.Navigate(modifikacija);
        }
        public void Proba()
        {
            MessageBox.Show("Proba");
        }

        public bool CanExecute_PrikazLijekova()
        {
            return true;
        }

        public void Executed_IzvjestajLijekova()
        {
            PopunjavanjeIzvjestajaDoktorViewModel e = new PopunjavanjeIzvjestajaDoktorViewModel(this.NavService);
            PopunjavanjeIzvjestajaDoktorView izvjestaj = new PopunjavanjeIzvjestajaDoktorView(e);
            this.NavService.Navigate(izvjestaj);
        }


        public PocetnaStranicaDoktorViewModel(NavigationService service)
        {
            this.navService = service;

            this.PrikazLijekova = new RelayCommand(Executed_PrikazLijekova, CanExecute_PrikazLijekova);
            this.ModifikacijaInventara = new RelayCommand(Executed_ModifikacijaInventara);
            this.IzvjestajLijekova = new RelayCommand(Executed_IzvjestajLijekova);
        }
    }
}
