using Model;
using Repository;
using Controller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjekatSIMS.Controller;

namespace ProjekatSIMS
{
    public partial class ManipulacijaRadaDoktoraSWindow : Window
    {
        private NeradniDaniController neradniDaniController;
        private PregledController pregledController;
        private DateTime datumOd;
        private DateTime datumDo;
        public Doktor doktor { get; set; }
        public List<NeradniDani> NeradniDani { get; set; }
        public ManipulacijaRadaDoktoraSWindow(Doktor d)
        {
            InitializeComponent();
            this.DataContext = this;
            doktor = d;
            List<NeradniDani> tabelaNeradnihDana = new List<NeradniDani>();
            NeradniDani = new List<NeradniDani>();
            Obrazlozenje.ItemsSource = Enum.GetValues(typeof(VrsteNeradnihDana));
            neradniDaniController = new NeradniDaniController();
            tabelaNeradnihDana = neradniDaniController.DobaviSve();
            foreach (NeradniDani n in tabelaNeradnihDana)
            {
                if (n.doktor == d.Jmbg)
                {
                    NeradniDani.Add(n);
                }
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Odobri_neradneDane(object sender, RoutedEventArgs e)
        {
            NeradniDani novoOdobrenje = new NeradniDani();
            neradniDaniController = new NeradniDaniController();
            PopunjavanjePoljaZaGodisnjiOdmor(novoOdobrenje);
            if (neradniDaniController.OdobriNeradneDane(novoOdobrenje) == true)
            {
                ProveraZakazanihPregledaDoktora(novoOdobrenje);
                this.Close();
            }
        }
        private void PopunjavanjePoljaZaGodisnjiOdmor(NeradniDani novoOdobrenje)
        {
            datumOd = (DateTime)Od.SelectedDate;
            datumDo = (DateTime)Do.SelectedDate;
            novoOdobrenje.interval.PocetnoVrijeme = datumOd.Date;
            novoOdobrenje.interval.KrajnjeVrijeme = datumDo.Date;
            novoOdobrenje.Vrsta = (VrsteNeradnihDana)Obrazlozenje.SelectedIndex;
            novoOdobrenje.doktor = doktor.Jmbg;
        }
        private void ProveraZakazanihPregledaDoktora(NeradniDani novoOdobrenje)
        {
            List<Pregled> pregledi = new List<Pregled>();
            pregledController = new PregledController();
            pregledi = pregledController.DobaviSveSekretar();
            foreach (Pregled p in pregledi)
            {
                ProveraDatumaZakazanogTermina(novoOdobrenje, p);
            }
        }
        private void ProveraDatumaZakazanogTermina(NeradniDani novoOdobrenje, Pregled p)
        {
            if (DateTime.Compare(novoOdobrenje.interval.PocetnoVrijeme, p.Pocetak) <= 0 && DateTime.Compare(novoOdobrenje.interval.KrajnjeVrijeme, p.Pocetak) >= 0)
            {
                ProveraDoktoraZakazanogTermina(novoOdobrenje, p);
            }
        }
        private void ProveraDoktoraZakazanogTermina(NeradniDani novoOdobrenje, Pregled p)
        {
            if (novoOdobrenje.doktor == p.doktor.Jmbg)
            {
                PomeranjeZakazanogTermina(p);
            }
        }
        private void PomeranjeZakazanogTermina(Pregled p)
        {
            //if (pregledController.OtkazivanjeSekretar(p))
            //{
                if(pregledController.IzmenaPregledaSekretar(p, p.Pocetak.AddDays(1)))
                {
                    MessageBox.Show("Pomereni su pregledi koje je doktor imao u periodu odobrenog godišnjeg odmora.", "OBAVEŠTENJE");
                }
            //}
        }
    }
}