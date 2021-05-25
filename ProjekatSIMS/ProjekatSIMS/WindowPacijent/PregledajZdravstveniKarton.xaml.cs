using Model;
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
        public PregledajZdravstveniKarton()
        {
            InitializeComponent();
            this.DataContext = this;
          
            ReceptRepository receptRepository = new ReceptRepository();
            Recepti = receptRepository.DobaviSveRecepte();

            AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
            Anamneze = anamnezaRepository.DobaviSve();

            UputRepository uputRepository = new UputRepository();
            Uputi = uputRepository.DobaviUpute();

            UputBolnickoLijecenjeRepository uputBolnickoLijecenjeRepository = new UputBolnickoLijecenjeRepository();
            UputiBolnickoLecenje = uputBolnickoLijecenjeRepository.DobaviSveUpute();
             
            
        }
    }
}
