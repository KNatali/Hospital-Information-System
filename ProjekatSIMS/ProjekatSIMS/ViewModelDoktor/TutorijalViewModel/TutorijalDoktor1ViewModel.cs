using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using ProjekatSIMS.ViewModelDoktor.TutorijalViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class TutorijalDoktor1ViewModel:BindableBase
    {
        public RelayCommand<Page> skip;
        private RelayCommand next;


        private NavigationService navService;


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public RelayCommand<Page> Skip
        {
            get { return skip; }
            set
            {
                skip = value;
            }
        }

        public RelayCommand Next
        {
            get { return next; }
            set
            {
                next = value;
            }
        }

        public void Executed_Skip(Page page)
        {
            DoktorWindowView doktorWindow = new DoktorWindowView();
            doktorWindow.Show();
            var myWindow = Window.GetWindow(page);
            myWindow.Close();


        }

        public void Executed_Next()
        {
            TutorijalDoktor2ViewModel e = new TutorijalDoktor2ViewModel(this.NavService);
            TutorijalDoktor2View pocetna = new TutorijalDoktor2View(e);
            this.NavService.Navigate(pocetna);

        }

        public TutorijalDoktor1ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Skip = new RelayCommand<Page>(Executed_Skip);
            this.Next = new RelayCommand(Executed_Next);


        }


    }
}
