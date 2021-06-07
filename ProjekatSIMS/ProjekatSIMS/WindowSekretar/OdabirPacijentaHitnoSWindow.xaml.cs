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
            Specijalizacija izborObl = (Specijalizacija)Oblasti.SelectedIndex;
            ComboBoxItem izborPacijenta = (ComboBoxItem)Nalog.SelectedItem;
            string izborPac = izborPacijenta.Content.ToString();
            IzborPacijentaIzComboBoxa(izborObl, izborPac);
        }

        private void IzborPacijentaIzComboBoxa(Specijalizacija izborObl, string izborPac)
        {
            if (izborPac == "Kreiraj hitan nalog")
            {
                IzborKreiranjeHitnogNaloga(izborObl);
            }
            else if (izborPac == "Odaberi postojeći nalog")
                IzborOdabirPostojecegNaloga(izborObl);
        }

        private void IzborOdabirPostojecegNaloga(Specijalizacija izborObl)
        {
            Pacijent pacijent = (Pacijent)dataGridPacijenti.SelectedItems[0];
            ZakaziTerminOpstaPraksaPostojeciPacijent(izborObl, pacijent);
            ZakaziTerminKardiologijaPostojeciPacijent(izborObl, pacijent);
            ZakaziTerminHirurgijaPostojeciPacijent(izborObl, pacijent);
        }

        private void ZakaziTerminHirurgijaPostojeciPacijent(Specijalizacija izborObl, Pacijent pacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Hirurgija.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraHirurga(noviPregled, pacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoPostojeciPacijent(pacijent);
            }
        }

        private void ZakaziTerminKardiologijaPostojeciPacijent(Specijalizacija izborObl, Pacijent pacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Kardiologija.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraKardiologa(noviPregled, pacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoPostojeciPacijent(pacijent);
            }
        }

        private void ZakaziTerminOpstaPraksaPostojeciPacijent(Specijalizacija izborObl, Pacijent pacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Opsta.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraOpstePrakse(noviPregled, pacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoPostojeciPacijent(pacijent);
            }
        }
        private void ZakazivanjeNeuspesnoPostojeciPacijent(Pacijent pacijent)
        {
            HitanPregledSWindow hp = new HitanPregledSWindow(pacijent);
            hp.Show();
            this.Close();
        }

        private void IzborKreiranjeHitnogNaloga(Specijalizacija izborObl)
        {
            Pacijent noviPacijent = new Pacijent();
            PacijentController pacijentController = new PacijentController();
            PopunjavanjePoljaZaHitanNalog(noviPacijent);
            KreiranjeHitnogNalogaPacijenta(izborObl, noviPacijent, pacijentController);
        }

        private void KreiranjeHitnogNalogaPacijenta(Specijalizacija izborObl, Pacijent noviPacijent, PacijentController pacijentController)
        {
            if (pacijentController.KreiranjeProfila(noviPacijent) == true)
            {
                ZakaziTerminOpstaPraksaNoviPacijent(izborObl, noviPacijent);
                ZakaziTerminKardiologijaNoviPacijent(izborObl, noviPacijent);
                ZakaziTerminHirurgijaNoviPacijent(izborObl, noviPacijent);
            }
        }

        private void ZakaziTerminHirurgijaNoviPacijent(Specijalizacija izborObl, Pacijent noviPacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Hirurgija.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraHirurga(noviPregled, noviPacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoNoviPacijent(noviPacijent);
            }
        }

        private void ZakaziTerminKardiologijaNoviPacijent(Specijalizacija izborObl, Pacijent noviPacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Kardiologija.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraKardiologa(noviPregled, noviPacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoNoviPacijent(noviPacijent);
            }
        }

        private void ZakaziTerminOpstaPraksaNoviPacijent(Specijalizacija izborObl, Pacijent noviPacijent)
        {
            if (izborObl.ToString() == Specijalizacija.Opsta.ToString())
            {
                Pregled noviPregled = new Pregled();
                HitanPregledController hitanPregledController = new HitanPregledController();
                if (hitanPregledController.ZakazivanjeKodDoktoraOpstePrakse(noviPregled, noviPacijent) == true)
                    SlanjeObavestenjaDoktoru();
                else
                    ZakazivanjeNeuspesnoNoviPacijent(noviPacijent);
            }
        }
        private void ZakazivanjeNeuspesnoNoviPacijent(Pacijent noviPacijent)
        {
            HitanPregledSWindow hp = new HitanPregledSWindow(noviPacijent);
            hp.Show();
            this.Close();
        }
        private static void SlanjeObavestenjaDoktoru()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.informacija;
            popup.TitleText = "OBAVEŠTENJE";
            popup.ContentText = "Pregled je uspešno zakazan. " +
                "Poslato je obaveštenje doktoru o hitnom pregledu.";
            popup.Popup();
        }

        private void PopunjavanjePoljaZaHitanNalog(Pacijent noviPacijent)
        {
            noviPacijent.Jmbg = Jmbg.Text;
            noviPacijent.Ime = Ime.Text;
            noviPacijent.Prezime = Prezime.Text;
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
