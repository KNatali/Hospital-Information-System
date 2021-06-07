using Controller;
using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.DTO;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class IzdajReceptDoktorViewModel : BindableBase
    {
        private NavigationService navService;
        private IzdavanjeReceptaController receptController = new IzdavanjeReceptaController();
        private AlergijeNaLijekController alergijeNaLijekController = new AlergijeNaLijekController();
        private LijekRepository lijekRepository = new LijekRepository();
  
        public ObservableCollection<Lijek> Lijekovi { get; set; }
        private Lijek selectedLijek;
        public Pacijent pacijent { get; set; }
        private String ime;
        private String prezime;
        private int kolicina;
        private DateTime datum;
        private int sati;
        private int minuti;
        private int dani;
        private int trajanje;
        private int period;


        private String trajanjeError;
        private String satiError;
        private String daniError;

        public String TrajanjeError
        {
            get { return trajanjeError; }
            set
            {
                trajanjeError = value;
                OnPropertyChanged("TrajanjeError");
            }
        }

        public String SatiError
        {
            get { return satiError; }
            set
            {
                satiError = value;
                OnPropertyChanged("SatiError");
            }
        }

        public String DaniError
        {
            get { return daniError; }
            set
            {
                daniError = value;
                OnPropertyChanged("DaniError");
            }
        }

        private bool TrajanjeValidacija()
        {
            if (Trajanje == 0)
            {
                TrajanjeError = "Trajanje ne može da bude nula.";
                return false;
            }
            else if (Trajanje < 0)
            {
                TrajanjeError = "Trajanje ne može da bude negativan broj.";
                return false;
            }
            return true;
        }

        private bool SatiValidacija()
        {
            if ((Sati>24 || Sati<0) || (Minuti<0 || Minuti>60))
            {
                SatiError = "Sati se krecu u rasponu od 0 do 24 a minuti u rasponu od 0 do 60";
                return false;
            }
           
            return true;
        }

        private bool DaniValidacija()
        {
            if (Period ==0)
            {
                DaniError = "Trajanje terapije ne može biti manje od jednog dana.";
                return false;
            }

            else if (Period < 0)
            {
                DaniError = "Broj dana ne može biti negativan broj!.";
                return false;
            }
            return true;
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

        private void BrisiTextBlokove()
        {
            this.TrajanjeError = "";
            this.SatiError = "";
            this.DaniError = "";
        }

        private bool Validacije()
        {
            if (SatiValidacija() == false) return false;
            if (TrajanjeValidacija() == false) return false;
           
            if (DaniValidacija() == false) return false;
          
            return true;
        }

        private RelayCommand sacuvaj;

        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public DateTime Datum
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

        public int Trajanje
        {
            get { return trajanje; }
            set
            {
                if (trajanje != value)
                {
                    trajanje = value;
                    OnPropertyChanged("Trajanje");
                }
            }
        }
        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                if (kolicina != value)
                {
                    kolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public String Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }



             public String Prezime
        {
            get { return prezime; }
            set
            {
                if (prezime != value)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        public int Sati
        {
            get { return sati; }
            set
            {
                if (sati != value)
                {
                    sati = value;
                    OnPropertyChanged("Sati");
                }
            }
        }

        public int Minuti
        {
            get { return minuti; }
            set
            {
                if (minuti != value)
                {
                    minuti = value;
                    OnPropertyChanged("Minuti");
                }
            }
        }

        public int Dani
        {
            get { return dani; }
            set
            {
                if (dani != value)
                {
                    dani = value;
                    OnPropertyChanged("Dani");
                }
            }
        }

        public int Period
        {
            get { return period; }
            set
            {
                if (period != value)
                {
                    period = value;
                    OnPropertyChanged("Period");
                }
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

        private void UcitavanjePodataka()
        {
            Datum = DateTime.Now;
            Ime = pacijent.Ime;
            Prezime= pacijent.Prezime;
            Lijekovi = new ObservableCollection<Lijek>();
            List<Lijek> lijekovi = lijekRepository.DobaviSve();
            foreach (Lijek l in lijekovi)
            {
                Lijekovi.Add(l);
            }
        }

        private void IzdavanjeRecepta()
        {
            BrisiTextBlokove();
            if (Validacije() == false) return;
            try
            {
                

                ReceptDTO receptDTO = new ReceptDTO(pacijent, SelectedLijek.NazivLeka ,Trajanje, Datum, Sati, Minuti, Period.ToString(), Kolicina.ToString());
                receptController.IzdavanjeRecepta(receptDTO);


                MessageBox.Show("Uspjesno je izdat recept");
                ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
                this.NavService.Navigate(z);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Popunite sve podatke");
            }


        }

        public IzdajReceptDoktorViewModel(NavigationService service,Pacijent p)
        {
            this.navService = service;
            pacijent = p;
            UcitavanjePodataka();
          

            this.Sacuvaj=new RelayCommand(IzdavanjeRecepta);
          

        }
    }
}
