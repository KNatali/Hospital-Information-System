using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
using Controller;
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
using ProjekatSIMS.Controller;

namespace ProjekatSIMS
{
    public partial class ZakaziTerminSWindow : Window
    {
        public Pacijent pac { get; set; }
        public List<Doktor> Doktori { get; set; }
        public List<Prostorija> Ordinacije { get; set; }
        public NeradniDani neradniDani { get; set; }
        public ZakaziTerminSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            List<Doktor> doktori = new List<Doktor>();
            Doktori = new List<Doktor>();
            //ucitavanje doktora u combobox
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Doktor.txt"))
            {
                string json = r.ReadToEnd();
                doktori = JsonConvert.DeserializeObject<List<Doktor>>(json);
            }
            foreach (Doktor d in doktori)
                Doktori.Add(d);
            Pregledi.ItemsSource = Enum.GetValues(typeof(TipPregleda));
            List<Prostorija> prostorije = new List<Prostorija>();
            Ordinacije = new List<Prostorija>();
            Prostorija prostorija1 = new Prostorija();
            //ucitavanje ordinacija u combobox
            /*using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\Prostorija.txt"))
            {

                string json = r.ReadToEnd();
                prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(json);

            }
            foreach (Prostorija pr in prostorije)
            {
                if (pr.vrsta == VrstaProstorije.Ordinacija)
                {
                    prostorija1 = pr;
                    Ordinacije.Add(prostorija1);
                }
            }*/
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete zakazivanje pregleda pacijenta?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
                this.Close();
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            p.doktor = (Doktor)Doktor.SelectedItem;
            //Prostorija prostorija = (Prostorija)Ordinacija.SelectedItem;
            Prostorija prostorija = new Prostorija();
            DateTime datum = (DateTime)Datum.SelectedDate;

            DaLiJeDoktorNaGodisnjemOdmoru(p, datum); // radi samo sto zakaze iako je na godisnjem odmoru
            double sat;
            double minut;
            TipPregleda tippregleda = (TipPregleda)Pregledi.SelectedIndex;
            if (tippregleda.ToString() == "Standardni")
            {
                p.Tip = TipPregleda.Standardni;
            }
            else
            {
                p.Tip = TipPregleda.Operacija;
            }

            if (Termin.Visibility == Visibility.Visible)
            {
                sat = Convert.ToDouble(Termin.Text.Split(":")[0]);
                minut = Convert.ToDouble(Termin.Text.Split(":")[1]);
            }
            else
            {
                sat = Convert.ToDouble(Sat.Text);
                minut = Convert.ToDouble(Minut.Text);
            }

            DateTime datum1 = new DateTime();
            datum1 = datum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            DateTime datum2 = datum1.AddMinutes(20);
            PregledController pc = new PregledController();
            if (pc.ZakazivanjePregledaSekretar(Termin, pac.Jmbg, p.doktor.Jmbg, prostorija, datum1, datum2) == true)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.informacija;
                popup.TitleText = "OBAVEŠTENJE";
                popup.ContentText = "Pregled je uspešno zakazan. " +
                    "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
                popup.Popup();
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste uspeli da zakažete pregled.");
            }
            /*DateTime neradnoOD = new DateTime(); 
            neradnoOD = neradniDani.NeradnoOd;
            DateTime neradnoDO = new DateTime(); 
            neradnoDO = neradniDani.NeradnoDo;
            int brojNeradnihDana = (neradnoDO - neradnoOD).Days;
            if(neradniDani.doktor.Jmbg==p.doktor.Jmbg)
            {
                //if(neradnoOD==datum || neradnoDO==datum)
                if(datum <= neradniDani.NeradnoDo && datum >= neradniDani.NeradnoOd)
                {
                    MessageBox.Show("Ne možete da zakažete pregled kod odabranog doktora.");
                }
                if (p.doktor.NeradniDani != null)
                {
                    foreach (NeradniDani odmor in p.doktor.NeradniDani)
                    {
                        DateTime pocetakOdmora = odmor.NeradnoOd;
                        DateTime krajOdmora = odmor.NeradnoDo;

                        if (datum <= krajOdmora && datum >= pocetakOdmora)
                        {
                            MessageBox.Show("Odabrani doktor je na godišnjem odmoru.");
                        }
                    }
                }
            }*/

        }

        private void DaLiJeDoktorNaGodisnjemOdmoru(Pregled p, DateTime datum)
        {
            NeradniDaniController neradniDaniController = new NeradniDaniController();
            List<NeradniDani> listaNeradnihDana = neradniDaniController.DobaviSve();
            foreach (NeradniDani neradniDani in listaNeradnihDana)
            {
                if (neradniDani.doktor.Jmbg == p.doktor.Jmbg)
                    PoredjenjeDatumaPregledaSaGodisnjimOdmoromDoktora(datum, neradniDani);
            }
        }

        private void PoredjenjeDatumaPregledaSaGodisnjimOdmoromDoktora(DateTime datum, NeradniDani neradniDani)
        {
            if (DateTime.Compare(datum, neradniDani.NeradnoOd) >= 0 && DateTime.Compare(datum, neradniDani.NeradnoDo) <= 0)
                PorukaOGodisnjemOdmoruDoktora();
        }

        private void PorukaOGodisnjemOdmoruDoktora()
        {
            MessageBox.Show("Izabrani doktor je na godišnjem odmoru u ovom terminu.");
            this.Close();
        }

        /*private void IzborPregleda(object sender, SelectionChangedEventArgs e)
        {
            TipPregleda tippregleda = (TipPregleda)Pregledi.SelectedIndex;
            ImeSale.Visibility = Visibility.Visible;
            Ordinacija.Visibility = Visibility.Visible;
        }*/
    }
}
