using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.UpravnikWindows.ViewModelUpravnik
{
    class ProstorijeViewModel
    {
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();

        public ObservableCollection<Prostorija> Prostorije
        {
            get { return prostorije; }
            set
            {
                prostorije = value;
            }
        }
        public ProstorijeViewModel()
        {
            Prostorije = new ObservableCollection<Prostorija>(prostorijaRepository.DobaviSve());
        }

    }
}
