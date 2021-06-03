using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor10ViewModel
    {
        private NavigationService navService;
        private RelayCommand back;
        private RelayCommand<Page> finish;

        public RelayCommand Back
        {
            get { return back; }
            set
            {
                back = value;
            }
        }

        public RelayCommand<Page> Finish
        {
            get { return finish; }
            set
            {
                finish = value;
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
        public void Executed_Back()
        {
            TutorijalDoktor9ViewModel e = new TutorijalDoktor9ViewModel(this.NavService);
            TutorijalDoktor9View pocetna = new TutorijalDoktor9View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Finish(Page window)
        {
         
            
            DoktorWindowView doktorWindow = new DoktorWindowView();
            doktorWindow.Show();
            var myWindow = Window.GetWindow(window);
            myWindow.Close();



        }

        public TutorijalDoktor10ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Back = new RelayCommand(Executed_Back);
            this.Finish = new RelayCommand<Page>(Executed_Finish);


        }
    }
}
