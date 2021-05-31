using Controller;
using Model;
using ProjekatSIMS.Commands;
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
        private PregledController pregledController;
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

        public PrikazPregledaDoktorViewModel(NavigationService service)
        {
            this.navService = service;
            UcitajPreglede();
            Detalji = new RelayCommand(OnPogledaj, CanPogledaj);
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

            List<Pregled> pregledi = new List<Pregled>();
            Pregledi = new ObservableCollection<Pregled>();


            pregledController = (Application.Current as App).PregledController;



            /*pregledi = pregledController.();
            foreach (Pregled p in pregledi)
            {
                if (p.doktor.Jmbg == "1511990855023" && p.StatusPregleda == StatusPregleda.Zakazan)
                {
                    Pregledi.Add(p);
                }
            }*/



        }
        private bool CanPogledaj()
        {
            return SelectedPregled != null;
        }

        private void OnPogledaj()
        {
            Pregledi.Remove(SelectedPregled);
            MessageBox.Show("ehhe");
            DetaljiPregledaDoktor d = new DetaljiPregledaDoktor(SelectedPregled);
            // this.Opacity = 0.3;
            d.ShowDialog();
            // this.Opacity = 1;
        }

    }
}
