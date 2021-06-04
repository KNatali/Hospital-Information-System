using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.ViewModelPacijent
{
    public class VidiPregledeViewModel
    {
        public ObservableCollection<Pregled> Pregledi { get; set; }
        public PregledController pregledController = new PregledController();
        public Pacijent trenutniPacijent { get; set; }

        public VidiPregledeViewModel(Pacijent pacijent)
        {

            trenutniPacijent = pacijent;
            UcitajPreglede();
        }

       

        public void UcitajPreglede()
        {
            ObservableCollection<Pregled> pregledi = new ObservableCollection<Pregled>();
            pregledi = pregledController.DobaviPregledeZaPacijentaOC(trenutniPacijent);
            Pregledi = pregledi;
        }
    }
}
