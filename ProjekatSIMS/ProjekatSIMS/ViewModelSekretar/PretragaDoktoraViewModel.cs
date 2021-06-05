using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class PretragaDoktoraViewModel : BindableBase
    {
        //public RelayCommand<string> NavCommand { get; private set; }
        private NavigationService navService;
        public ObservableCollection<Doktor> Doktori { get; set; }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public PretragaDoktoraViewModel(NavigationService service)
        {
            this.navService = service;
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
