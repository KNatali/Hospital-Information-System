using Controller;
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
    public partial class HitanPregledSWindow : Window
    {
        private DateTime danasnjiDatum;
        public Pacijent pac { get; set; }
        public Pregled pre { get; set; }
        public List<Doktor> Doktori { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public List<SlobodanTermin> Termini { get; set; }
        public HitanPregledSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            danasnjiDatum = DateTime.Now;
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajlTermina = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajlTermina.DobaviSveSlobodneTermineZaDatum(danasnjiDatum);
        }

        private void Prikaz(object sender, RoutedEventArgs e)
        {
            Doktor d = new Doktor();
            List<Pregled> Pregledi1 = new List<Pregled>();
            List<Pregled> ListaPregleda = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            ListaPregleda = fajl.GetListaPregledaSekretar();
            dataGridPregledi.Visibility = Visibility.Visible;
            dataGridSlobodniTermini.Visibility = Visibility.Hidden;

            Specijalizacija spec = (Specijalizacija)Oblasti.SelectedIndex;
            if (spec.ToString() == "Opsta")
            {
                foreach (Pregled pr in ListaPregleda)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Opsta)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
            }
            else if (spec.ToString() == "Kardiologija")
            {
                foreach (Pregled pr in Pregledi)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Kardiologija)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
            }
            else if (spec.ToString() == "Hirurgija")
            {
                foreach (Pregled pr in Pregledi)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Hirurgija)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
            }
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0];
            Pregled zakaziPregled = new Pregled();
            zakaziPregled.pacijent = pac;
            zakaziPregled.doktor = st.doktor;
            zakaziPregled.Pocetak = danasnjiDatum;
            zakaziPregled.Tip = TipPregleda.Operacija;
            zakaziPregled.Trajanje = 30;
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi.Add(zakaziPregled);
            fajl.SacuvajPregledSekretar(Pregledi);

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno zakazan. " +
                "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
            popup.Popup();
            this.Close();
        }

        private void Slobodni(object sender, RoutedEventArgs e)
        {
            List<SlobodanTermin> slobodniTermini = new List<SlobodanTermin>();
            List<SlobodanTermin> listaTermina = new List<SlobodanTermin>();
            dataGridSlobodniTermini.Visibility = Visibility.Visible;
            dataGridPregledi.Visibility = Visibility.Hidden;
            foreach (SlobodanTermin st in slobodniTermini)
            {
                if (st.Termin==danasnjiDatum)
                {
                    listaTermina.Add(st);
                }
            }
        }
    }
}
