using ProjekatSIMS.Commands;
using ProjekatSIMS.ViewSekretar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class Pocetna : BindableBase
    {
        public RelayCommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private NavigationService navService;
        public Pocetna(NavigationService navService)
        {

            NavCommand = new RelayCommand<string>(OnNav);
            this.navService = navService;

        }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "kreiranjePacijenta":
                    KreiranjePacijentaViewModel kpa = new KreiranjePacijentaViewModel(this.NavService);
                    KreiranjePacijentaView kreiranjePacijenta = new KreiranjePacijentaView();
                    kreiranjePacijenta.Show();
                    break;
                case "kreiranjeDoktora":
                    KreiranjeDoktoraViewModel kd = new KreiranjeDoktoraViewModel(this.NavService);
                    KreiranjeDoktoraView kreiranjeDoktora = new KreiranjeDoktoraView();
                    kreiranjeDoktora.Show();
                    break;
                case "pretragaPacijenta":
                    PretragaPacijenataViewModel pp = new PretragaPacijenataViewModel(this.NavService);
                    PretragaPacijenataView pretragaPacijenata = new PretragaPacijenataView(pp);
                    pretragaPacijenata.Show();
                    break;
                case "pretragaDoktora":
                    PretragaDoktoraViewModel pd = new PretragaDoktoraViewModel(this.NavService);
                    PretragaDoktoraView pretragaDoktora = new PretragaDoktoraView(pd);
                    pretragaDoktora.Show();
                    break;
                case "hitno":
                    HitnoZakazivanjeViewModel hz = new HitnoZakazivanjeViewModel(this.NavService);
                    HitnoZakazivanjeView hitnoZakazivanje = new HitnoZakazivanjeView(hz);
                    hitnoZakazivanje.Show();
                    break;
                case "kalendarPregleda":
                    KalendarPregledaViewModel kp = new KalendarPregledaViewModel(this.NavService);
                    KalendarPregledaView kalendarPregleda = new KalendarPregledaView(kp);
                    kalendarPregleda.Show();
                    break;
                case "zauzetostProstorija":
                    ZauzetostProstorijaSWindow zp = new ZauzetostProstorijaSWindow();
                    zp.Show();
                    break;
                case "oglasnaTabla":
                    OglasnaTablaViewModel ot = new OglasnaTablaViewModel(this.NavService);
                    OglasnaTablaView oglasnaTabla = new OglasnaTablaView(ot);
                    oglasnaTabla.Show();
                    break;
                /*case "odjavljivanje":
                    break;*/
            }
        }
    }
}
