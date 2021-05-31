using Model;
using ProjekatSIMS.Repository;
using ProjekatSIMS.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.UpravnikWindows.ViewModelUpravnik
{
    
    public class LekoviViewModel
    {
        private ObservableCollection<Lijek> lijekovi = new ObservableCollection<Lijek>();
        private LijekService lijekService = new LijekService();
        public ObservableCollection<Lijek> Lijekovi
        {
            get { return lijekovi; }
            set
            {
                lijekovi = value;
            }
        }
        public LekoviViewModel()
        {
            Lijekovi = new ObservableCollection<Lijek>(lijekService.lijekRepoisitory.DobaviSve());
        }
    }
}
