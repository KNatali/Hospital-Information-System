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
                    /*KreiranjePacijentaViewModel kpa = new KreiranjePacijentaViewModel(this.NavService);
                    KreiranjePacijentaView kreiranjePacijenta = new KreiranjePacijentaView();
                    kreiranjePacijenta.Show();*/
                    ViewModelSekretar.KreiranjeProfila knp = new ViewModelSekretar.KreiranjeProfila(this.NavService);
                    ViewSekretar.KreiranjeProfila kreiranjeProfila = new ViewSekretar.KreiranjeProfila();
                    kreiranjeProfila.Show();
                    break;
                case "kreiranjeDoktora":
                    KreiranjeDoktoraViewModel kd = new KreiranjeDoktoraViewModel(this.NavService);
                    KreiranjeDoktoraView kreiranjeDoktora = new KreiranjeDoktoraView();
                    kreiranjeDoktora.Show();
                    break;
                case "pretragaPacijenta":
                    /*PretragaPacijenataViewModel pp = new PretragaPacijenataViewModel(this.NavService);
                    PretragaPacijenataView pretragaPacijenata = new PretragaPacijenataView(pp);
                    pretragaPacijenata.Show();*/
                    PretraziPacijenteSWindow pp = new PretraziPacijenteSWindow();
                    pp.Show();
                    break;
                case "pretragaDoktora":
                    /*PretragaDoktoraViewModel pd = new PretragaDoktoraViewModel(this.NavService);
                    PretragaDoktoraView pretragaDoktora = new PretragaDoktoraView();
                    pretragaDoktora.Show();*/
                    PretraziDoktoreSWindow pd = new PretraziDoktoreSWindow();
                    pd.Show();
                    break;
                case "hitno":
                    /*HitnoZakazivanjeViewModel hz = new HitnoZakazivanjeViewModel(this.NavService);
                    HitnoZakazivanjeView hitnoZakazivanje = new HitnoZakazivanjeView(hz);
                    hitnoZakazivanje.Show();*/
                    OdabirPacijentaHitnoSWindow op = new OdabirPacijentaHitnoSWindow();
                    op.Show();
                    break;
                case "kalendarPregleda":
                    /*KalendarPregledaViewModel kp = new KalendarPregledaViewModel(this.NavService);
                    KalendarPregledaView kalendarPregleda = new KalendarPregledaView(kp);
                    kalendarPregleda.Show();*/
                    KalendarPregledaSWindow kp = new KalendarPregledaSWindow();
                    kp.Show();
                    break;
                case "zauzetostProstorija":
                    ZauzetostProstorijaSWindow zp = new ZauzetostProstorijaSWindow();
                    zp.Show();
                    break;
                case "oglasnaTabla":
                    /*OglasnaTablaViewModel ot = new OglasnaTablaViewModel(this.NavService);
                    OglasnaTablaView oglasnaTabla = new OglasnaTablaView(ot);
                    oglasnaTabla.Show();*/
                    OglasnaTablaSWindow ot = new OglasnaTablaSWindow();
                    ot.Show();
                    break;
                case "naplataPregleda":
                    NaplataPregledaSWindow np = new NaplataPregledaSWindow();
                    np.Show();
                    break;
                /*case "odjavljivanje":
                    break;*/
            }
        }
    }
}
