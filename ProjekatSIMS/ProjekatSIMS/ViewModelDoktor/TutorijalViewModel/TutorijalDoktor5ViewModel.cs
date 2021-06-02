using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor5ViewModel
    {
        private NavigationService navService;
        private RelayCommand next;
        private RelayCommand back;
        public RelayCommand Next
        {
            get { return next; }
            set
            {
                next = value;
            }
        }
        public RelayCommand Back
        {
            get { return back; }
            set
            {
                back = value;
            }
        }

        public void Executed_Next()
        {
            TutorijalDoktor6ViewModel e = new TutorijalDoktor6ViewModel(this.NavService);
            TutorijalDoktor6View pocetna = new TutorijalDoktor6View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Back()
        {
            TutorijalDoktor4ViewModel e = new TutorijalDoktor4ViewModel(this.NavService);
            TutorijalDoktor4View pocetna = new TutorijalDoktor4View(e);
            this.NavService.Navigate(pocetna);

        }

        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public TutorijalDoktor5ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Next = new RelayCommand(Executed_Next);
            this.Back = new RelayCommand(Executed_Back);


        }
    }
}
