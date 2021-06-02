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

        public RelayCommand PrikazLijekova
        {
            get { return prikazLijekova; }
            set
            {
                prikazLijekova = value;
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

            EvidencijaLijekovaViewModel e = new EvidencijaLijekovaViewModel(this.NavService,TipLijekaPremaPrikazu.Neverifikovan);
            EvidencijaLijekovaView lijekovi = new EvidencijaLijekovaView(e);
            this.NavService.Navigate(lijekovi);

        }
        public void Proba()
        {
            MessageBox.Show("Proba");
        }

        public bool CanExecute_PrikazLijekova()
        {
            return true;
        }


        public PocetnaStranicaDoktorViewModel(NavigationService service)
        {
            this.navService = service;

            this.PrikazLijekova = new RelayCommand(Executed_PrikazLijekova, CanExecute_PrikazLijekova);

        }
    }
}
