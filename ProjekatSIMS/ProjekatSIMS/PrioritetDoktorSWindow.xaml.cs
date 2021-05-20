using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Pacijent pac { get; set; }
        public List<Doktor> Doktori { get; set; }
        public List<SlobodanTermin> Termini { get; set; }
        public List<Prostorija> Ordinacije { get; set; }
        public PrioritetDoktorSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            List<Doktor> doktori = new List<Doktor>();
            Doktori = new List<Doktor>();
            OsobaRepository fajl = new OsobaRepository(@"..\..\..\Fajlovi\Doktor.txt");
            Doktori = fajl.DobaviDoktore();
            List<Prostorija> prostorije = new List<Prostorija>();
            Ordinacije = new List<Prostorija>();
            //ucitavanje ordinacija u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Prostorija.txt"))
            {

                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            foreach (Prostorija pr in prostorije)
            {
                //if (pr.vrsta == VrstaProstorije.Ordinacija)
                    Ordinacije.Add(pr);
            }
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Doktor selektovani = (Doktor)dataGridDoktori.SelectedItems[0];
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0];
            Prostorija prostorija = (Prostorija)Ordinacija.SelectedItem;
            Pregled pre = new Pregled();
            int trajanje = 30;

            pre.Tip = TipPregleda.Standardni;
            pre.Pocetak = st.Termin;
            pre.Trajanje = trajanje;
            pre.doktor = selektovani;
            pre.StatusPregleda = StatusPregleda.Zakazan;
            pre.pacijent = pac;
            pre.prostorija = prostorija;

            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.GetListaPregledaSekretar();

            pregledi.Add(pre);

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
        private void Dvoklik(object sender, MouseButtonEventArgs e)
        {
            Doktor selektovani = (Doktor)dataGridDoktori.SelectedItems[0];
            Termini = new List<SlobodanTermin>();
            List<SlobodanTermin> termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            termini = fajl.DobaviSveSlobodneTermine();

            foreach (SlobodanTermin t in termini)
            {

                if (t.ImeDoktora == selektovani.Ime && t.PrezimeDoktora == selektovani.Prezime)
                {
                    Termini.Add(t);
                }

            }
            //dataGridSlobodniTermini.ItemsSource = null;
            Labela.Visibility = Visibility.Visible;
            dataGridSlobodniTermini.Visibility = Visibility.Visible;
            dataGridSlobodniTermini.ItemsSource = Termini;
        }
    }
}
