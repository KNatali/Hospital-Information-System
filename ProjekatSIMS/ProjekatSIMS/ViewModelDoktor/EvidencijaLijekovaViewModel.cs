using Controller;
using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Controller.LijekoviDoktor;
using ProjekatSIMS.DTO;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class EvidencijaLijekovaViewModel : BindableBase
    {
        private PrikazEvidencijeLijekovaController prikazEvidencijeLijekovaController = new PrikazEvidencijeLijekovaController();
        private PrikazDetaljaLijekController prikazDetaljaLijekController = new PrikazDetaljaLijekController();
        private VerifikovanjeLijekovaController verifikovanjeLijekovaController = new VerifikovanjeLijekovaController();
        private NavigationService navService;

        private Lijek selectedLijek;
        private String opis;
        private String poruka;
        private double opacity=1;
        public TipLijekaPremaPrikazu Tip { get; set; }
        public ObservableCollection<Lijek> Lijekovi { get; set; }
        public ObservableCollection<StringWrapper> Sastojci { get; set; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get; set; }

        private RelayCommand prikazDetaljaLijeka;
        private RelayCommand izmijeniLijek;
        private RelayCommand verifikovaniLijekovi;
        private RelayCommand prihvatiLijek;
        private RelayCommand odbaciLijek;
        private RelayCommand nazad;


        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }


        public string Opis
        {
            get { return opis; }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set
            {
                if (poruka != value)
                {
                    poruka = value;
                    OnPropertyChanged("Poruka");
                }
            }
        }

        /*public ObservableCollection<StringWrapper> Sastojci
        {
            get { return sastojci; }
            set
            {
                if (sastojci != value)
                {
                    sastojci = value;
                    OnPropertyChanged("Sastojci");
                }
            }
        }*/




        public Lijek SelectedLijek
        {
            get { return selectedLijek; }
            set
            {
                selectedLijek = value;
                PrikazDetaljaLijeka.RaiseCanExecuteChanged();
            }
        }

        public double Opacity
        {
            get { return opacity; }
            set
            {
                opacity = value;
                OnPropertyChanged("Opacity");
            }
        }

        public RelayCommand PrikazDetaljaLijeka
        {
            get { return prikazDetaljaLijeka; }
            set
            {
                prikazDetaljaLijeka = value;
            }
        }
        public RelayCommand IzmijeniLijek
        {
            get { return izmijeniLijek; }
            set
            {
                izmijeniLijek = value;
            }
        }

        public RelayCommand VerifikovaniLijekovi
        {
            get { return verifikovaniLijekovi; }
            set
            {
                verifikovaniLijekovi = value;
            }
        }

        public RelayCommand PrihvatiLijek
        {
            get { return prihvatiLijek; }
            set
            {
                prihvatiLijek = value;
            }
        }

        public RelayCommand OdbaciLijek
        {
            get { return odbaciLijek; }
            set
            {
                odbaciLijek = value;
            }
        }

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }


        public void PrikazLijekova(TipLijekaPremaPrikazu tip)
        {

            List<Lijek> lijekoviNaCekanju = prikazEvidencijeLijekovaController.PrikazLijekovaPoStatusu(tip);
            Lijekovi = new ObservableCollection<Lijek>();
            foreach (Lijek l in lijekoviNaCekanju)
            {
                Lijekovi.Add(l);
            }
            AlternativniLijekovi = new ObservableCollection<StringWrapper>();
            Sastojci = new ObservableCollection<StringWrapper>();





        }

        public void Executed_PrikazDetalja()
        {
            AlternativniLijekovi.Clear();
            Sastojci.Clear();
            LijekDetaljiDTO detalji = prikazDetaljaLijekController.PrikazDetalja(SelectedLijek);
            Opis = detalji.Opis;
            Poruka = detalji.Poruka;
            foreach (StringWrapper s in detalji.Sastojci)
            {
                Sastojci.Add(s);
            }
            foreach (StringWrapper s in detalji.AlternativniLijekovi)
            {
                AlternativniLijekovi.Add(s);
            }



        }

        public bool CanExecute_PrikazDetalja()
        {
            return true;

        }

        public void Executed_IzmijeniLijek()
        {
            IzmjenaLijekDoktorViewModel il = new IzmjenaLijekDoktorViewModel(this.NavService, SelectedLijek);
            IzmjenaLijekDoktorView izmjena = new IzmjenaLijekDoktorView(il);
            this.NavService.Navigate(izmjena);
        }

        public void Executed_VerifikovaniLijekovi()
        {
            EvidencijaLijekovaViewModel e = new EvidencijaLijekovaViewModel(this.NavService, TipLijekaPremaPrikazu.Verifikovan);
            VerifikovaniLijekoviDoktorView lijekovi = new VerifikovaniLijekoviDoktorView(e);
            this.NavService.Navigate(lijekovi);
        }

        public void Executed_PrihvatiLijek()
        {

            verifikovanjeLijekovaController.OdobriLijek(SelectedLijek);
            Lijekovi.Remove(SelectedLijek);

        }

        public void Executed_OdbaciLijek()
        {
           
            this.Opacity = 0.3;
            OdbacivanjePoruka porukaProzor = new OdbacivanjePoruka();
            porukaProzor.ShowDialog();
            this.Opacity = 1;

            verifikovanjeLijekovaController.OdbaciLijek(SelectedLijek, porukaProzor.Poruka);
            Lijekovi.Remove(SelectedLijek);

        }

        public void Executed_Nazad()
        {
            if (Tip == TipLijekaPremaPrikazu.Neverifikovan)
            {
                PocetnaStranicaDoktorViewModel e = new PocetnaStranicaDoktorViewModel(this.NavService);
                PocetnaStranicaDoktorView pocetna = new PocetnaStranicaDoktorView(e);
                this.NavService.Navigate(pocetna);
            }
            else
                this.NavService.GoBack();
           
        }


    


        public EvidencijaLijekovaViewModel(NavigationService service, TipLijekaPremaPrikazu tip)
        {
            this.navService = service;
            Tip = tip;
            PrikazLijekova(tip);

            this.PrikazDetaljaLijeka = new RelayCommand(Executed_PrikazDetalja, CanExecute_PrikazDetalja);
            this.IzmijeniLijek = new RelayCommand(Executed_IzmijeniLijek);
            this.VerifikovaniLijekovi = new RelayCommand(Executed_VerifikovaniLijekovi);
            this.PrihvatiLijek = new RelayCommand(Executed_PrihvatiLijek);
            this.OdbaciLijek = new RelayCommand(Executed_OdbaciLijek);
            this.Nazad = new RelayCommand(Executed_Nazad);

        }

    }
}
