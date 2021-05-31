using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
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
        public ObservableCollection<Lijek> SviLijekovi { get; set; }
        public ObservableCollection<StringWrapper> Sastojci { get; set; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get; set; }

        private RelayCommand dodajSastojak;
        private RelayCommand dodajALternativniLijek;
        private RelayCommand sacuvaj;

        public RelayCommand DodajSastojak
        {
            get { return dodajSastojak; }
            set
            {
                dodajSastojak = value;
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

        public void Ucitaj()
        {
            Sastojci = new ObservableCollection<StringWrapper>();
            AlternativniLijekovi = new ObservableCollection<StringWrapper>();
            Naziv = IzabraniLijek.NazivLeka;
            Opis = IzabraniLijek.Opis;
            List<String> sastojci = IzabraniLijek.Alergeni;
            List<String> alternativni = IzabraniLijek.AlternativniLekovi;


            foreach (String s in sastojci)
            {
                StringWrapper sw = new StringWrapper();
                sw.Naziv = s;
                Sastojci.Add(sw);
            }
            foreach (String a in alternativni)
            {
                StringWrapper sw = new StringWrapper();
                sw.Naziv = a;
                AlternativniLijekovi.Add(sw);
            }
            List<Lijek> lijekovi = new List<Lijek>();
            //dobavljanje svih iljekova
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                lijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            SviLijekovi = new ObservableCollection<Lijek>(lijekovi);

        }

        public void Executed_DodajSastojak()
        {

            if (IzabraniLijek.Alergeni == null)
                IzabraniLijek.Alergeni = new List<String>();
            IzabraniLijek.Alergeni.Add(NoviSastojak);

            StringWrapper sw = new StringWrapper();
            sw.Naziv = NoviSastojak;

            Sastojci.Add(sw);

        }
        public bool CanExecute_DodajSastojak()
        {
            // return (NoviSastojak!=null);
            return true;

        }

        public void Executed_DodajAlternativniLijek()
        {
            if (IzabraniLijek.AlternativniLekovi == null)
                IzabraniLijek.AlternativniLekovi = new List<String>();
            IzabraniLijek.AlternativniLekovi.Add(AlternativniLijek.NazivLeka);

            StringWrapper sw = new StringWrapper();
            sw.Naziv = AlternativniLijek.NazivLeka;

            AlternativniLijekovi.Add(sw);
        }

        public bool CanExecute_DodajAlternativniLijek()
        {

            return AlternativniLijek != null;
        }

        public void Executed_Sacuvaj()
        {
            Lijek l = new Lijek();
            l.NazivLeka = IzabraniLijek.NazivLeka;
            l.Opis = Opis;
            l.Status = IzabraniLijek.Status;
            l.Alergeni = new List<String>();
            l.AlternativniLekovi = new List<String>();

            foreach (StringWrapper i in Sastojci)

            {
                l.Alergeni.Add(i.Naziv);

            }


            foreach (StringWrapper i in AlternativniLijekovi)
            {
                l.AlternativniLekovi.Add(i.Naziv);

            }

            foreach (Lijek li in SviLijekovi)

            {
                if (li.NazivLeka == l.NazivLeka)
                {
                    li.Opis = l.Opis;
                    li.Alergeni = l.Alergeni;
                    li.AlternativniLekovi = l.AlternativniLekovi;
                }

            }
            //upisivanje u fajl
            string newJson = JsonConvert.SerializeObject(SviLijekovi);
            File.WriteAllText(@"..\..\..\Fajlovi\Lijek.txt", newJson);

            this.NavService.GoBack();
        }
        public IzmjenaLijekDoktorViewModel(NavigationService service, Lijek lijek)
        {
            this.navService = service;
            this.izabraniLijek = lijek;
            Ucitaj();
            this.DodajSastojak = new RelayCommand(Executed_DodajSastojak, CanExecute_DodajSastojak);
            this.DodajAlternativniLijek = new RelayCommand(Executed_DodajAlternativniLijek, CanExecute_DodajAlternativniLijek);
            this.Sacuvaj = new RelayCommand(Executed_Sacuvaj);
        }
    }
}
