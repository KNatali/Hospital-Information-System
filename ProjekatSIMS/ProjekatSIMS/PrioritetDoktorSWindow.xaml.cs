using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
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
using Tulpep.NotificationWindow;

namespace ProjekatSIMS
{
    public partial class PrioritetDoktorSWindow : Window
    {
        public List<Doktor> Doktori { get; set; }
        public List<SlobodanTermin> Termini { get; set; }
        public PrioritetDoktorSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Doktor> doktori = new List<Doktor>();
            Doktori = new List<Doktor>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            Doktori = fajl.DobaviDoktore();
        }
        /*public PrioritetDoktorSWindow(String ime, String prezime)
        {
            InitializeComponent();
            this.DataContext = this;
            Doktor selektovani = (Doktor)dataGridDoktori.SelectedItems[0];
            //selektovani.Ime = ime;
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajl.DobaviSveSlobodneTermineZaDoktora(selektovani.Ime, selektovani.Prezime);
        }*/
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Doktor selektovani = (Doktor)dataGridDoktori.SelectedItems[0];
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0];
            Pregled p = new Pregled();
            String jmbgp = Jmbg_pacijent.Text;
            int trajanje = 30;

            p.Tip = TipPregleda.Standardni;
            p.Pocetak = st.Termin;
            p.Trajanje = trajanje;
            Pacijent pac = new Pacijent { Jmbg = jmbgp };
            p.pacijent = pac;
            p.doktor = selektovani;
            p.StatusPregleda = StatusPregleda.Zakazan;


            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.GetListaPregledaSekretar();

            pregledi.Add(p);

            fajl.SacuvajPregledSekretar(pregledi);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno zakazan. " +
                "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
            popup.Popup();
            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Prikazi(object sender, RoutedEventArgs e)
        {
            Doktor selektovani = (Doktor)dataGridDoktori.SelectedItems[0];
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajl.DobaviSveSlobodneTermineZaDoktora(selektovani.Ime, selektovani.Prezime);
        }
    }
}
