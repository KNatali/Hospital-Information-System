using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class ProfilDoktorViewModel:BindableBase
    {
        private NavigationService navService;
        

        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public ProfilDoktorViewModel(NavigationService service)
        {
            this.navService = service;
            

        }
    }
}
