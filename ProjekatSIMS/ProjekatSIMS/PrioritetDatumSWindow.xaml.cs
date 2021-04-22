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
    public partial class PrioritetDatumSWindow : Window
    {
        public List<Doktor> Doktori { get; set; }
        public List<SlobodanTermin> Termini { get; set; }
        public List<Pregled> Pregledi { get; set; }
        private DateTime datum1;
        private String ime;
        private String prezime;
        public PrioritetDatumSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<SlobodanTermin> termini = new List<SlobodanTermin>();
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\Doktor.txt");
            Termini = fajl.DobaviSveSlobodneTermine();
        }
        public PrioritetDatumSWindow(DateTime datum1)
        {
            this.datum1 = datum1;
            InitializeComponent();
            this.DataContext = this;
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository file = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = file.DobaviSveSlobodneTermineZaDatum(datum1);
        }

        public PrioritetDatumSWindow(DateTime datum1, String ime, String prezime)
        {
            this.datum1 = datum1;
            this.ime = ime;
            this.prezime = prezime;
            InitializeComponent();
            this.DataContext = this;
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository file = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = file.DobaviSveSlobodneTermineZaDatum(datum1);
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0];
            
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar(); 
            Pregled p = new Pregled();
            //Doktor dr = new Doktor { Ime = st.ImeDoktora, Prezime = st.PrezimeDoktora };
            //p.doktor = dr;
            Doktor dr = new Doktor();
            List<Doktor> postojeci = new List<Doktor>();
            OsobaRepository fajldok = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            postojeci = fajldok.DobaviDoktore();
            foreach (Doktor t in postojeci)
            {

                if (t.Ime == st.ImeDoktora && t.Prezime==st.PrezimeDoktora)
                {
                    dr = t;
                    break;
                }
            }
            p.doktor = dr;
            p.Pocetak = st.Termin;
            String jmbgp = Jmbg_pacijent.Text;
            //Pacijent pac = new Pacijent { Jmbg = jmbgp };
            //p.pacijent = pac;
            Pacijent pac = new Pacijent();
            List<Pacijent> postojecipac = new List<Pacijent>();
            PacijentRepository fajlpac = new PacijentRepository();
            postojecipac = fajlpac.UcitajSvePacijente();

            foreach (Pacijent f in postojecipac)
            {

                if (f.Jmbg == jmbgp)
                {
                    pac = f;
                    break;
                }
            }
            p.pacijent = pac;
            Pregledi.Add(p);
            fajl.SacuvajPregledSekretar(Pregledi);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno zakazan. " +
                "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
            popup.Popup();
            this.Close();
        }
    }
}
