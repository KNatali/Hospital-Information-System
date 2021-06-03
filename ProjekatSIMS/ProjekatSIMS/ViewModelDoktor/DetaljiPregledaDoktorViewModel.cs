using Controller;
using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class DetaljiPregledaDoktorViewModel : BindableBase
    {
        private NavigationService navService;

        private OtkazivanjePregledaDoktorController otkazivanjePregledaDoktorController = new OtkazivanjePregledaDoktorController();
        private Pregled pregled;
        private String vrijeme;
        private String pacijent;
        private String datum;

        private RelayCommand<Window> otkaziPregled;
        private RelayCommand<Window> zatvoriProzor;
        private RelayCommand<Window> zapocniPregled;
        private RelayCommand<Window> zdravstveniKarton;
        private RelayCommand<Window> pomjeriPregled;


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public Pregled Pregled
        {
            get { return pregled; }
            set
            {
                if (pregled != value)
                {
                    pregled = value;
                    OnPropertyChanged("Pregled");
                }
            }
        }

        public String Vrijeme
        {
            get { return vrijeme; }
            set
            {
                if (vrijeme != value)
                {
                    vrijeme = value;
                    OnPropertyChanged("Vrijeme");
                }
            }
        }

        public String Datum
        {
            get { return datum; }
            set
            {
                if (datum != value)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        public String Pacijent
        {
            get { return pacijent; }
            set
            {
                if (pacijent != value)
                {
                    pacijent = value;
                    OnPropertyChanged("Pacijent");
                }
            }
        }

        public RelayCommand<Window> OtkaziPregled
        {
            get { return otkaziPregled; }
            set
            {
                otkaziPregled = value;
            }
        }
        public RelayCommand<Window> ZapocniPregled
        {
            get { return zapocniPregled; }
            set
            {
                zapocniPregled = value;
            }
        }

        public RelayCommand<Window> PomjeriPregled
        {
            get { return pomjeriPregled; }
            set
            {
                pomjeriPregled = value;
            }
        }

        public RelayCommand<Window> ZdravstveniKarton
        {
            get { return zdravstveniKarton; }
            set
            {
                zdravstveniKarton = value;
            }
        }

        public RelayCommand<Window> ZatvoriProzor
        {
            get { return zatvoriProzor; }
            set
            {
                zatvoriProzor = value;
            }
        }

        public void PrikaziDetalje(Pregled p)
        {
            Pacijent = p.pacijent.Ime + " " + p.pacijent.Prezime;
            Datum=p.Pocetak.Month.ToString() + "/" + p.Pocetak.Day.ToString() + "/" + p.Pocetak.Year.ToString();
            DateTime kraj = p.Pocetak.AddMinutes(p.Trajanje);
            Vrijeme= p.Pocetak.Hour.ToString() + ":" + p.Pocetak.Minute.ToString() + "-" + kraj.Hour.ToString() + ":" + kraj.Minute.ToString();
            

        }

        public void Executed_OtkaziPregled(Window window)
        {

            otkazivanjePregledaDoktorController.OtkazivanjePregleda(pregled);
            MessageBox.Show("Uspjesno ste otkazali pregled");
            if (window != null)
            {
                window.Close();
            }
            PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavService);
            PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
            this.NavService.Navigate(kalendar);
            
        }

        public void Executed_ZapocniPregled(Window window)
        {

            if (window != null)
            {
                window.Close();
            }
            IzvrsavanjePregledaDoktor i = new IzvrsavanjePregledaDoktor(pregled);
            
            this.NavService.Navigate(i);

        }

        public void Executed_PomjeriPregled(Window window)
        {

            if (window != null)
            {
                window.Close();
            }
            PomjeriPregledDoktor po = new PomjeriPregledDoktor(Pregled);
            this.NavService.Navigate(po);
        }

        public void Executed_ZdravstveniKarton(Window window)
        {

            if (window != null)
            {
                window.Close();
            }
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(Pregled.pacijent);
            this.NavService.Navigate(z);

        }
        public void Executed_ZatvoriProzor(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        public DetaljiPregledaDoktorViewModel(NavigationService service, Pregled pregled)
        {
            this.NavService = service;
            Pregled = pregled;
            PrikaziDetalje(pregled);
            this.OtkaziPregled = new RelayCommand<Window>(Executed_OtkaziPregled);
            this.ZapocniPregled = new RelayCommand<Window>(Executed_ZapocniPregled);
            this.ZatvoriProzor = new RelayCommand<Window>(Executed_ZatvoriProzor);
            this.PomjeriPregled = new RelayCommand<Window>(Executed_PomjeriPregled);
            this.ZdravstveniKarton = new RelayCommand<Window>(Executed_ZdravstveniKarton);

        }
    }
}
