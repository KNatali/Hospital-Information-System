using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProjekatSIMS.ViewModelPacijent
{
    
    public class PregledajZdravstveniKartonViewModel
    {
        public ObservableCollection<Anamneza> Anamneze { get; set; }
        public ObservableCollection<Recept> Recepti { get; set; }
        public ObservableCollection<Uput> Uputi { get; set; }
        public ObservableCollection<UputBolnickoLijecenje> UputiBolnickoLecenje { get; set; }
        public AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        public ReceptRepository receptRepository = new ReceptRepository();
        public UputBolnickoLijecenjeRepository uputBolnickoLijecenjeRepository = new UputBolnickoLijecenjeRepository();
        public UputRepository uputRepository = new UputRepository();

        public PregledajZdravstveniKartonViewModel()
        {
            LoadAnamneze();
            LoadRecepti();
            LoadUputi();
            LoadUputiBolnickoLecenje();
        }
        public void LoadAnamneze()
        {
            ObservableCollection<Anamneza> anamneze = new ObservableCollection<Anamneza>();
            anamneze = anamnezaRepository.DobaviSveOC();
            Anamneze = anamneze;
        }
        public void LoadRecepti()
        {
            ObservableCollection<Recept> recepti = new ObservableCollection<Recept>();
            recepti = receptRepository.DobaviSveRecepteOC();
            Recepti = recepti;
        }
        public void LoadUputi()
        {
            ObservableCollection<Uput> uputi = new ObservableCollection<Uput>();
            uputi = uputRepository.DobaviUputeOC();
            Uputi = uputi;
        }
        public void LoadUputiBolnickoLecenje()
        {
            ObservableCollection<UputBolnickoLijecenje> uputi = new ObservableCollection<UputBolnickoLijecenje>();
            uputi = uputBolnickoLijecenjeRepository.DobaviSveUputeOC();
            UputiBolnickoLecenje = uputi;
        }
    }
}
