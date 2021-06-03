using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using ProjekatSIMS.ViewDoktor;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class TutorijalDoktorViewModel1: BindableBase
    {

        
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
            TutorijalDoktor1ViewModel vm = new TutorijalDoktor1ViewModel(this.NavService);
            TutorijalDoktor1View pocetna = new TutorijalDoktor1View(vm);
            this.NavService.Navigate(pocetna);
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
        public TutorijalDoktorViewModel1(NavigationService navService)
        {

            this.navService = navService;
            Prikaz();

        }
    }
}
