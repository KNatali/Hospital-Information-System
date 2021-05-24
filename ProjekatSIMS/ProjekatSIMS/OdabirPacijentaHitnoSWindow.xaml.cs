using Model;
using ProjekatSIMS.Model;
using Repository;
using System;
using Controller;
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
    public partial class OdabirPacijentaHitnoSWindow : Window
    {
        private DateTime danasnjiDatum;
        private HitanPregledController hitanPregledController;
        public List<Pacijent> Pacijenti { get; set; }
        public Pacijent pac { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public OdabirPacijentaHitnoSWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            danasnjiDatum = DateTime.Now;
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            UcitavanjePacijenataUTabelu();
        }
        private void UcitavanjePacijenataUTabelu()
        {
            List<Pacijent> tabelaPacijenata = new List<Pacijent>();
            Pacijenti = new List<Pacijent>();
            hitanPregledController = new HitanPregledController();
            tabelaPacijenata = hitanPregledController.DobaviSvePacijente();
            foreach (Pacijent p in tabelaPacijenata)
                Pacijenti.Add(p);
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete zakazivanje hitnog pregleda?", "PROVERA", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
                this.Close();
        }

        private void Zakazi_pregled(object sender, RoutedEventArgs e)
        {
            List<SlobodanTermin> slobodniTermini = new List<SlobodanTermin>();
            ComboBoxItem izborPacijenta = (ComboBoxItem)Nalog.SelectedItem;
            string izborPac = izborPacijenta.Content.ToString();
            /*ComboBoxItem izborOblasti = (ComboBoxItem)Oblasti.SelectedItem;
            string izborObl = izborOblasti.Content.ToString();*/
            Specijalizacija izborObl = (Specijalizacija)Oblasti.SelectedIndex;
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            if (izborPac == "Kreiraj hitan nalog")
            {
                //Pacijent p = KreiranjeHitnogNaloga();
                Pacijent noviPacijent = new Pacijent();
                PacijentController pacijentController = new PacijentController();
                PopunjavanjePoljaZaHitanNalog(noviPacijent);
                if (pacijentController.KreiranjeProfila(noviPacijent) == true)
                {
                    MessageBox.Show("Kreiran je hitan profil pacijenta.");
                }

                /*if (izborObl.ToString()==Specijalizacija.Opsta.ToString())
                {
                    foreach(SlobodanTermin st in slobodniTermini)
                    {
                        if (st.PocetakTermina == danasnjiDatum.AddMinutes(30) && izborObl.ToString() == st.doktor.Specijalizacija.ToString())
                        {
                            Pregled zakaziPregled = new Pregled();
                            zakaziPregled.pacijent = noviPacijent;
                            zakaziPregled.doktor = st.doktor;
                            zakaziPregled.Pocetak = danasnjiDatum.AddMinutes(30);
                            zakaziPregled.Tip = TipPregleda.Operacija;
                            zakaziPregled.Trajanje = 30;
                            
                            Pregledi.Add(zakaziPregled);
                            fajl.SacuvajPregledSekretar(Pregledi);
                            SlanjeNotifikacija();
                        }
                        else
                            MessageBox.Show("Nema slobodnih termina u narednih pola sata kod doktora iz odabrane oblasti.");
                    }
                }*/
                HitanPregledSWindow hp = new HitanPregledSWindow(noviPacijent);
                hp.Show();
                this.Close();
            }
            else if (izborPac == "Odaberi postojeći nalog")
            {
                Pacijent p = (Pacijent)dataGridPacijenti.SelectedItems[0];
                HitanPregledSWindow hp = new HitanPregledSWindow(p);
                hp.Show();
                this.Close();
            }
        }
        private void PopunjavanjePoljaZaHitanNalog(Pacijent noviPacijent)
        {
            noviPacijent.Jmbg = Jmbg.Text;
            noviPacijent.Ime = Ime.Text;
            noviPacijent.Prezime = Prezime.Text;
        }
        private void CuvanjeUFajl(Pregled zakaziPregled)
        {
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi.Add(zakaziPregled);
            fajl.SacuvajPregledSekretar(Pregledi);
        }
        private static void SlanjeNotifikacija()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno zakazan. " +
                "Poslato je obaveštenje pacijentu i doktoru o predstojećem pregledu.";
            popup.Popup();
        }
        private void PrikazTabeleSaSvimPacijentima()
        {
            dataGridPacijenti.Visibility = Visibility.Visible;
            dataGridPacijenti.ItemsSource = Pacijenti;
            LabelaJMBG.Visibility = Visibility.Hidden;
            LabelaIme.Visibility = Visibility.Hidden;
            LabelaPrezime.Visibility = Visibility.Hidden;
            Jmbg.Visibility = Visibility.Hidden;
            Ime.Visibility = Visibility.Hidden;
            Prezime.Visibility = Visibility.Hidden;
        }

        private void PrikazPoljaZaKreiranjeHitnogNaloga()
        {
            LabelaJMBG.Visibility = Visibility.Visible;
            LabelaIme.Visibility = Visibility.Visible;
            LabelaPrezime.Visibility = Visibility.Visible;
            Jmbg.Visibility = Visibility.Visible;
            Ime.Visibility = Visibility.Visible;
            Prezime.Visibility = Visibility.Visible;
            dataGridPacijenti.Visibility = Visibility.Hidden;
        }

        private void Prikazi(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)Nalog.SelectedItem;
            string opcija = cbi.Content.ToString();
            if (opcija == "Kreiraj hitan nalog")
            {
                PrikazPoljaZaKreiranjeHitnogNaloga();
            }
            else if (opcija == "Odaberi postojeći nalog")
            {
                PrikazTabeleSaSvimPacijentima();
            }
        }
    }
}
