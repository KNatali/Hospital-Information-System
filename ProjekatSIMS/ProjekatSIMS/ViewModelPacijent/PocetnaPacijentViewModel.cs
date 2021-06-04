using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewPacijent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelPacijent
{
    public class PocetnaPacijentViewModel : BindableBase
    {
        private NavigationService navService;

        private RelayCommand Lekari;

        public RelayCommand VidiLekare
        {
            get { return Lekari; }
            set
            {
                Lekari = value;
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

        public void Executed_Lekari()
        {

            VidiLekareViewModel vl = new VidiLekareViewModel(this.NavService);
            VidiLekareView lekari = new VidiLekareView(vl);
            this.NavService.Navigate(lekari);

        }

        public bool CanExecute_Lekari()
        {
            return true;
        }

        public PocetnaPacijentViewModel (NavigationService ns)
        {
            this.navService = ns;
            this.VidiLekare = new RelayCommand(Executed_Lekari,CanExecute_Lekari);
        }
    }
}
