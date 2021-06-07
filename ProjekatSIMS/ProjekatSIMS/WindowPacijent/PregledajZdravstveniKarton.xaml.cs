using Model;
using ProjekatSIMS.Controller.AnamnezaPacijent;
using ProjekatSIMS.Controller.ReceptPacijent;
using ProjekatSIMS.Controller.UputiPacijent;
using Repository;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PregledajZdravstveniKarton : Page

    {
        public List<Recept> Recepti
        {
            get;
            set;
        }
        public List<Anamneza> Anamneze
        {
            get;
            set;
        }
        public List<Uput> Uputi
        {
            get;
            set;
        }
        public List<UputBolnickoLijecenje> UputiBolnickoLecenje
        {
            get;
            set;
        }
        public Pacijent trenutniPacijent { get; set; }
        public ReceptiPacijentController receptController = new ReceptiPacijentController();
        public AnamnezaPacijentController anamnezaController = new AnamnezaPacijentController();
        public UputController uputController = new UputController();
        public UputBolnickoLecenjeController UputBolnickoLecenjeController = new UputBolnickoLecenjeController();
        public PregledajZdravstveniKarton(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;

            trenutniPacijent = pacijent;

            Recepti = receptController.DobaviSveRecepte();
            Anamneze = anamnezaController.DobaviSve();
            Uputi = uputController.DobaviUpute();
            UputiBolnickoLecenje = UputBolnickoLecenjeController.DobaviSveUpute();
             
            
        }

        private void Zatvori(object sender, System.Windows.RoutedEventArgs e)
        {
            PocetnaPacijent pocetna = new PocetnaPacijent(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }

       
    }
}
