using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Model;
using ProjekatSIMS.ViewDoktor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class EvidencijaLijekovaViewModel : BindableBase
    {

        private NavigationService navService;
        public ObservableCollection<Lijek> Lijekovi { get; set; }
        public ObservableCollection<StringWrapper> Sastojci { get; set; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get; set; }
        private RelayCommand prikazDetaljaLijeka;
        private RelayCommand izmijeniLijek;
        private Lijek selectedLijek;
        private String opis;




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

        public Lijek SelectedLijek
        {
            get { return selectedLijek; }
            set
            {
                selectedLijek = value;
                PrikazDetaljaLijeka.RaiseCanExecuteChanged();
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



        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public void PrikazLijekova()
        {
            List<Lijek> sviLijekovi = new List<Lijek>();
            Lijekovi = new ObservableCollection<Lijek>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Lijek.txt"))
            {
                string json = r.ReadToEnd();
                sviLijekovi = JsonConvert.DeserializeObject<List<Lijek>>(json);
            }
            foreach (Lijek l in sviLijekovi)
            {
                if (l.Status == OdobravanjeLekaEnum.Ceka)
                    Lijekovi.Add(l);
            }
            Sastojci = new ObservableCollection<StringWrapper>();
            AlternativniLijekovi = new ObservableCollection<StringWrapper>();


        }

        public void Executed_PrikazDetalja()
        {
            List<String> sastojci = SelectedLijek.Alergeni;
            // Sastojci = new ObservableCollection<StringWrapper>();
            Sastojci.Clear();
            AlternativniLijekovi.Clear();

            List<String> alternativni = SelectedLijek.AlternativniLekovi;

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

            //Sastojci = new ObservableCollection<String>(sastojci);

            Opis = SelectedLijek.Opis;
        }

        public bool CanExecute_PrikazDetalja()
        {
            return true;
            //return SelectedLijek != null;
        }

        public void Executed_IzmijeniLijek()
        {


            IzmjenaLijekDoktorViewModel il = new IzmjenaLijekDoktorViewModel(this.NavService, SelectedLijek);
            IzmjenaLijekDoktorView izmjena = new IzmjenaLijekDoktorView(il);
            this.NavService.Navigate(izmjena);
        }






        public EvidencijaLijekovaViewModel(NavigationService service)
        {
            this.navService = service;
            PrikazLijekova();

            this.PrikazDetaljaLijeka = new RelayCommand(Executed_PrikazDetalja, CanExecute_PrikazDetalja);
            this.IzmijeniLijek = new RelayCommand(Executed_IzmijeniLijek);
        }

    }
}
