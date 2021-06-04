using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor6ViewModel
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
            TutorijalDoktor7ViewModel e = new TutorijalDoktor7ViewModel(this.NavService);
            TutorijalDoktor7View pocetna = new TutorijalDoktor7View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Back()
        {
            TutorijalDoktor5ViewModel e = new TutorijalDoktor5ViewModel(this.NavService);
            TutorijalDoktor5View pocetna = new TutorijalDoktor5View(e);
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

        public TutorijalDoktor6ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Next = new RelayCommand(Executed_Next);
            this.Back= new RelayCommand(Executed_Back);


        }
    }
}
