using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class OglasnaTablaViewModel
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
        public OglasnaTablaViewModel(NavigationService service)
        {
            this.navService = service;
        }
    }
}
