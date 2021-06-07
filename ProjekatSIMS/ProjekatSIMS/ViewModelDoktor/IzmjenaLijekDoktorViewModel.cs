using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class IzmjenaLijekDoktorViewModel : BindableBase
    {
        private NavigationService navService;
        private Lijek izabraniLijek;
        private String opis;
        private String naziv;
        private String noviSastojak;
        public Lijek alternativniLijek;
        private StringWrapper selectedSastojak;
        private StringWrapper selectedAlternativniLijek;

        private LijekRepository lijekRepository = new LijekRepository();
        private IzmjenaLijekaDoktorController izmjenaLijekaController = new IzmjenaLijekaDoktorController();
        private CuvanjeIzmjenaLijekaDoktorController cuvanjeIzmjenaLijekaDoktorController = new CuvanjeIzmjenaLijekaDoktorController();
        public ObservableCollection<Lijek> SviLijekovi { get; set; }
        public ObservableCollection<StringWrapper> Sastojci { get; set; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get; set; }

        private RelayCommand dodajSastojak;
        private RelayCommand dodajALternativniLijek;
        private RelayCommand sacuvaj;
        private RelayCommand odustani;
        private RelayCommand ukloniSastojak;
        private RelayCommand ukloniAlternativiLijek;
        private Lijek selectedLijek;

        public StringWrapper SelectedSastojak
        {
            get { return selectedSastojak; }
            set
            {
                selectedSastojak = value;
                //ukloniSastojak.RaiseCanExecuteChanged();
            }
        }

        public Lijek SelectedLijek
        {
            get { return selectedLijek; }
            set
            {
                selectedLijek = value;
                Sacuvaj.RaiseCanExecuteChanged();

            }
        }

        public StringWrapper SelectedAlternativniLijek
        {
            get { return selectedAlternativniLijek; }
            set
            {
                selectedAlternativniLijek = value;
                //ukloniSastojak.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand DodajSastojak
        {
            get { return dodajSastojak; }
            set
            {
                dodajSastojak = value;
            }
        }

        public RelayCommand Odustani
        {
            get { return odustani; }
            set
            {
                odustani = value;
            }
        }

        public RelayCommand Sacuvaj
        {
            get { return sacuvaj; }
            set
            {
                sacuvaj = value;
            }
        }
        public RelayCommand DodajAlternativniLijek
        {
            get { return dodajALternativniLijek; }
            set
            {
                dodajALternativniLijek = value;
            }
        }

        public RelayCommand UkloniSastojak
        {
            get { return ukloniSastojak; }
            set
            {
                ukloniSastojak = value;
            }
        }

        public RelayCommand UkloniAlternativiLijek
        {
            get { return ukloniAlternativiLijek; }
            set
            {
                ukloniAlternativiLijek = value;
            }
        }

        public string NoviSastojak
        {
            get { return noviSastojak; }
            set
            {
                if (noviSastojak != value)
                {
                    noviSastojak = value;
                    OnPropertyChanged("NoviSastojak");
                    //DodajSastojak.RaiseCanExecuteChanged();
                }
            }
        }
        public Lijek AlternativniLijek
        {
            get { return alternativniLijek; }
            set
            {
                if (alternativniLijek != value)
                {
                    alternativniLijek = value;

                    DodajAlternativniLijek.RaiseCanExecuteChanged();
                }
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
        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public Lijek IzabraniLijek
        {
            get { return izabraniLijek; }
            set
            {
                izabraniLijek = value;

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

        public void Ucitaj(Lijek izabraniLijek)
        {
            Sastojci = new ObservableCollection<StringWrapper>();
            AlternativniLijekovi = new ObservableCollection<StringWrapper>();
            Naziv=izabraniLijek.NazivLeka;
            Opis = izabraniLijek.Opis;
            foreach(String l in izabraniLijek.Alergeni)
            {
                StringWrapper s = new StringWrapper();
                s.Text = l;
                Sastojci.Add(s);
            }
            foreach (String a in izabraniLijek.AlternativniLekovi)
            {
                StringWrapper s = new StringWrapper();
                s.Text = a;
                AlternativniLijekovi.Add(s);
            }
            List<Lijek> lijekovi = lijekRepository.DobaviSve();
            SviLijekovi = new ObservableCollection<Lijek>(lijekovi);

        }

        public void Executed_DodajSastojak()
        {

            if (IzabraniLijek.Alergeni == null)
                IzabraniLijek.Alergeni = new List<String>();
            IzabraniLijek.Alergeni.Add(NoviSastojak);

            StringWrapper sw = new StringWrapper();
            sw.Text = NoviSastojak;
            Sastojci.Add(sw);

        }
        public bool CanExecute_DodajSastojak()
        {
            // return (NoviSastojak!=null);
            return true;

        }

        public void  Executed_UkloniSastojak()
        {
            Sastojci.Remove(SelectedSastojak);
        }

        public void Executed_UkloniAlternativniLijek()
        {
            AlternativniLijekovi.Remove(SelectedAlternativniLijek);
        }

        public void Executed_DodajAlternativniLijek()
        {

           // IzabraniLijek.AlternativniLekovi = izmjenaLijekaController.DodavanjeALternativnihLijekova(IzabraniLijek.NazivLeka, IzabraniLijek);
            if (IzabraniLijek.AlternativniLekovi == null)
                IzabraniLijek.AlternativniLekovi = new List<String>();
            IzabraniLijek.AlternativniLekovi.Add(AlternativniLijek.NazivLeka);
           
            StringWrapper sw = new StringWrapper();
            sw.Text = AlternativniLijek.NazivLeka;
            AlternativniLijekovi.Add(sw);
        }

        public bool CanExecute_DodajAlternativniLijek()
        {

            return AlternativniLijek != null;
        }

        public void Executed_Sacuvaj()
        {
            Lijek l = new Lijek();
            l.NazivLeka = Naziv;
            l.Opis = Opis;
            l.Status = IzabraniLijek.Status;

            cuvanjeIzmjenaLijekaDoktorController.SacuvajIzmjene(l, Sastojci, AlternativniLijekovi);
            this.NavService.GoBack();

          
        }

        public void Executed_Odustani()
        {
            if (IzabraniLijek.Status == Model.OdobravanjeLekaEnum.Ceka)
            {
                EvidencijaLijekovaNovoViewModel ev = new EvidencijaLijekovaNovoViewModel(this.NavService, TipLijekaPremaPrikazu.Neverifikovan);
                EvidencijaLIjekovaNovo n = new EvidencijaLIjekovaNovo(ev);
                this.NavService.Navigate(n);

            }
            else
            {
                EvidencijaLijekovaNovoViewModel ev = new EvidencijaLijekovaNovoViewModel(this.NavService, TipLijekaPremaPrikazu.Neverifikovan);

                VerifikovaniLijekoviNovo v = new VerifikovaniLijekoviNovo(ev);
                this.NavService.Navigate(v);
            }
           
        }
        public IzmjenaLijekDoktorViewModel(NavigationService service, Lijek lijek)
        {
            this.navService = service;
            this.izabraniLijek = lijek;
            Ucitaj(lijek);
            this.DodajSastojak = new RelayCommand(Executed_DodajSastojak, CanExecute_DodajSastojak);
            this.DodajAlternativniLijek = new RelayCommand(Executed_DodajAlternativniLijek, CanExecute_DodajAlternativniLijek);
            this.Sacuvaj = new RelayCommand(Executed_Sacuvaj);
            this.Odustani = new RelayCommand(Executed_Odustani);
            this.UkloniSastojak = new RelayCommand(Executed_UkloniSastojak);
            this.UkloniAlternativiLijek = new RelayCommand(Executed_UkloniAlternativniLijek);
        }
    }
}
 