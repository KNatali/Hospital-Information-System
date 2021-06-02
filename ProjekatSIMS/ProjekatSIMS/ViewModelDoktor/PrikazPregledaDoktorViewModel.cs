using Controller;
using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Controller.PregledDoktor;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class PrikazPregledaDoktorViewModel : BindableBase
    {
        public ObservableCollection<Pregled> Pregledi { get; set; }
        private PrikazPregledaDoktorController prikazPregledaDoktorController = new PrikazPregledaDoktorController();
        private Pregled selectedPregled;
        public RelayCommand Detalji { get; set; }

        private NavigationService navService;


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

       

        public Pregled SelectedPregled
        {
            get { return selectedPregled; }
            set
            {
                selectedPregled = value;
                Detalji.RaiseCanExecuteChanged();
            }
        }

        public void UcitajPreglede()
        {
            Pregledi = new ObservableCollection<Pregled>();
            List<Pregled> pregledi =  prikazPregledaDoktorController.PrikazPregleda();
            foreach(Pregled p in pregledi)
            {
                Pregledi.Add(p);
            }

           



        }
      /*  private bool CanPogledaj()
        {
            return SelectedPregled != null;
        }*/

        private void OnPogledaj()
        {
            // Pregledi.Remove(SelectedPregled);

            DetaljiPregledaDoktorViewModel e = new DetaljiPregledaDoktorViewModel(this.NavService, selectedPregled) ;
            DetaljiPregledaDoktorView lijekovi = new DetaljiPregledaDoktorView(e);
            //this.NavService.Navigate(lijekovi);
           // DetaljiPregledaDoktor d = new DetaljiPregledaDoktor(SelectedPregled);
            // this.Opacity = 0.3;
            lijekovi.ShowDialog();
            // this.Opacity = 1;
        }

        public PrikazPregledaDoktorViewModel(NavigationService service)
        {
            this.navService = service;
            UcitajPreglede();
            Detalji = new RelayCommand(OnPogledaj);
        }

    }
}
