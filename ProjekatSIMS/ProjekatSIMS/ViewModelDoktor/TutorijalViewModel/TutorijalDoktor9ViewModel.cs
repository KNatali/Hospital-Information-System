using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor9ViewModel
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
            TutorijalDoktor10ViewModel e = new TutorijalDoktor10ViewModel(this.NavService);
            TutorijalDoktor10View pocetna = new TutorijalDoktor10View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Back()
        {
            TutorijalDoktor8ViewModel e = new TutorijalDoktor8ViewModel(this.NavService);
            TutorijalDoktor8View pocetna = new TutorijalDoktor8View(e);
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

        public TutorijalDoktor9ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Next = new RelayCommand(Executed_Next);
            this.Back= new RelayCommand(Executed_Back);


        }
    }
}
