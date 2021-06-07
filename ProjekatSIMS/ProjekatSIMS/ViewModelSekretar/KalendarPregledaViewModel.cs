using Controller;
using Model;
using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class KalendarPregledaViewModel : BindableBase
    {
        private PregledController pregledController = new PregledController();
        private NavigationService navService;
        public ObservableCollection<Pregled> Pregledi { get; set; }
        public RelayCommand Detalji { get; set; }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public KalendarPregledaViewModel(NavigationService service)
        {
            this.navService = service;
            UcitajPreglede();
        }
        public void UcitajPreglede()
        {
            Pregledi = new ObservableCollection<Pregled>();
            List<Pregled> tabelaPregleda = pregledController.DobaviSveSekretar();
            foreach (Pregled p in tabelaPregleda)
                Pregledi.Add(p);
        }
    }
}
