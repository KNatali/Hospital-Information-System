using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.ViewModelPacijent
{
   public  class TerapijaViewModel
    {
        public ObservableCollection<Recept> Recepti { get; set; }
        public ReceptRepository receptRepository = new ReceptRepository();

        public TerapijaViewModel()
        {
            LoadTerapija();
        }

        public void LoadTerapija()
        {
            ObservableCollection<Recept> recepti = new ObservableCollection<Recept>();

        }
    }
}
