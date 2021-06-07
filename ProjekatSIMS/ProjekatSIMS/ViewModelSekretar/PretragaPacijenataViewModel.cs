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
    public class PretragaPacijenataViewModel : BindableBase
    {
        //public RelayCommand<string> NavCommand { get; private set; }
        private NavigationService navService;
        public ObservableCollection<Pacijent> Pacijenti { get; set; }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public PretragaPacijenataViewModel(NavigationService service)
        {
            this.navService = service;
            UcitajPacijente();
        }
        public void UcitajPacijente()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Pacijent.txt"))
            {
                string json = r.ReadToEnd();
                pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(json);
            }
            Pacijenti = new ObservableCollection<Pacijent>(pacijenti);
        }
    }
}
