using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class PretragaDoktoraViewModel : BindableBase
    {
        private NavigationService navService;
        private RelayCommand nazad;
        private RelayCommand dvoklik;
        private Window thisWindow;
        public ObservableCollection<Doktor> Doktori { get; set; }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
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
        public RelayCommand Dvoklik
        {
            get { return dvoklik; }
            set
            {
                dvoklik = value;
            }
        }
        public PretragaDoktoraViewModel()
        {

        }
        public PretragaDoktoraViewModel(Window thisWindow)
        {
            this.thisWindow = thisWindow;
            Nazad = new RelayCommand(Executed_Dvoklik);
            Dvoklik = new RelayCommand(Executed_Nazad);
        }
        public void Executed_Nazad()
        {
            thisWindow.Close();
        }
        public void Executed_Dvoklik()
        {
            //Doktor d = (Doktor)dataGridDoktori.SelectedItems[0];
            Doktor d = new Doktor();
            Window window = new ViewSekretar.ProfilDoktoraView(d);
            window.Show();
            thisWindow.Close();
        }
        public PretragaDoktoraViewModel(NavigationService service)
        {
            this.navService = service;
            this.Nazad = new RelayCommand(Executed_Nazad);
            this.Dvoklik = new RelayCommand(Executed_Dvoklik);
            UcitajDoktore();
        }
        public void UcitajDoktore()
        {
            List<Doktor> doktori = new List<Doktor>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            Doktori = new ObservableCollection<Doktor>(doktori);
        }
    }
}
