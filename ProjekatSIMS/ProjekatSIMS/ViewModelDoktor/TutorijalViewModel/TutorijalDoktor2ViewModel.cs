using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor2ViewModel
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
            TutorijalDoktor3ViewModel e = new TutorijalDoktor3ViewModel(this.NavService);
            TutorijalDoktor3View pocetna = new TutorijalDoktor3View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Back()
        {
            TutorijalDoktor1ViewModel e = new TutorijalDoktor1ViewModel(this.NavService);
            TutorijalDoktor1View pocetna = new TutorijalDoktor1View(e);
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

        public TutorijalDoktor2ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Next = new RelayCommand(Executed_Next);
            this.Back = new RelayCommand(Executed_Back);


        }
    }
}
