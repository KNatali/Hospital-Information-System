using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor.TutorijalView;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor.TutorijalViewModel
{
    public class TutorijalDoktor7ViewModel
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
            TutorijalDoktor8ViewModel e = new TutorijalDoktor8ViewModel(this.NavService);
            TutorijalDoktor8View pocetna = new TutorijalDoktor8View(e);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_Back()
        {
            TutorijalDoktor6ViewModel e = new TutorijalDoktor6ViewModel(this.NavService);
            TutorijalDoktor6View pocetna = new TutorijalDoktor6View(e);
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

        public TutorijalDoktor7ViewModel(NavigationService service)
        {
            this.navService = service;
            this.Next = new RelayCommand(Executed_Next);
            this.Back = new RelayCommand(Executed_Back);


        }
    }
}
