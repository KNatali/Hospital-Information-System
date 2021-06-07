using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.DTO;
using ProjekatSIMS.Repository;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class PopunjavanjeIzvjestajaDoktorViewModel : BindableBase
    {
        private NavigationService navService;
        private LijekRepository lijekRepository = new LijekRepository();
        public ObservableCollection<Lijek> Lijekovi { get; set; }
        public ObservableCollection<IzvjestajLijekDTO> Izvjestaj { get; set; }
      
        private DateTime datumOd;
        private DateTime datumDo;
        private int kolicina;
        private Lijek selectedLijek;
        private IzvjestajLijekDTO selectedIzvjestaj;
        private RelayCommand dodavanjeUListu;
        private RelayCommand sacuvaj;
        private RelayCommand odustani;
        private RelayCommand ukloniIzvjestaj;

        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public DateTime DatumOd
        {
            get { return datumOd; }
            set
            {
                if (datumOd != value)
                {
                    datumOd = value;
                    OnPropertyChanged("DatumOd");
                }
            }
        }
        public DateTime DatumDo
        {
            get { return datumDo; }
            set
            {
                if (datumDo != value)
                {
                    datumDo = value;
                    OnPropertyChanged("DatumDo");
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

        public Lijek SelectedLijek
        {
            get { return selectedLijek; }
            set
            {
                selectedLijek = value;
                DodavanjeUListu.RaiseCanExecuteChanged();

            }
        }

        public IzvjestajLijekDTO SelectedIzvjestaj
        {
            get { return selectedIzvjestaj; }
            set
            {
                selectedIzvjestaj = value;
               

            }
        }
        public RelayCommand DodavanjeUListu
        {
            get { return dodavanjeUListu; }
            set
            {
                dodavanjeUListu = value;
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

        public RelayCommand Odustani
        {
            get { return odustani; }
            set
            {
                odustani = value;
            }
        }

        public RelayCommand UkloniIzvjestaj
        {
            get { return ukloniIzvjestaj; }
            set
            {
                ukloniIzvjestaj = value;
            }
        }
        public bool CanExecute_DOdavanjeUListu()
        {
            return SelectedLijek != null;
        }

        public void Executed_DodavanjeUListu()
        {
            IzvjestajLijekDTO noviRed = new IzvjestajLijekDTO(SelectedLijek.Id,SelectedLijek.NazivLeka, Kolicina);
            Izvjestaj.Add(noviRed);
        }



        public void Executed_Sacuvaj()
        {
            IntervalDatuma datum= new IntervalDatuma(DatumOd, DatumDo);
            IzvjestajLijekova i = new IzvjestajLijekova(datum,Izvjestaj);
            this.NavService.Navigate(i);
        }

        public void Executed_Odustani()
        {
            PocetnaStranicaDoktorViewModel p = new PocetnaStranicaDoktorViewModel(this.NavService);
            PocetnaStranicaDoktorView pocetna = new PocetnaStranicaDoktorView(p);
            this.NavService.Navigate(pocetna);

        }

        public void Executed_UkloniIzvjestaj()
        {
            Izvjestaj.Remove(SelectedIzvjestaj);
        }

        public void Ucitaj()
        {
            Izvjestaj = new ObservableCollection<IzvjestajLijekDTO>();
            List<Lijek> lijekovi = lijekRepository.DobaviSve();
            Lijekovi = new ObservableCollection<Lijek>(lijekovi);
            DatumOd = DateTime.Now;
            DatumDo = DateTime.Now;
        }

        public PopunjavanjeIzvjestajaDoktorViewModel(NavigationService service)
        {
            this.navService = service;
            Ucitaj();
            this.DodavanjeUListu = new RelayCommand( Executed_DodavanjeUListu, CanExecute_DOdavanjeUListu);
            this.Sacuvaj = new RelayCommand(Executed_Sacuvaj);
            this.Odustani = new RelayCommand(Executed_Odustani);
            this.UkloniIzvjestaj = new RelayCommand(Executed_UkloniIzvjestaj);

        }
    }
}
