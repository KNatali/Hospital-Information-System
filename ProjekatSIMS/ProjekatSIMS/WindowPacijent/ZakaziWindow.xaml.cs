using Controller;
using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace ProjekatSIMS.WindowPacijent
{

    public partial class ZakaziWindow : Window
    {
        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public bool jesteMaliciozniKorisnik = false;
        public int MAKSIMAMLNO_OTKAZIVANJA = 10;
        public List<Pacijent> Pacijenti { get; set; }
        public ZakaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ZakaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = new Pregled();
            String ime = Ime.Text;
            String prezime = Prezime.Text;
            String imeDoktora = ImeDoktora.Text;
            String prezimeDoktora = PrezimeDoktora.Text;
            String jmbg = Jmbg.Text;
            DateTime datum = (DateTime)Date.SelectedDate;
            double sati = Convert.ToDouble(Sati.Text);
            double minuti = Convert.ToDouble(Minuti.Text);
            DateTime datum1 = new DateTime();

            datum1 = datum.AddHours(sati);
            datum1 = datum1.AddMinutes(minuti);
            int trajanje = 30;
            DateTime datum2 = datum1.AddMinutes(trajanje);

            PregledController pregCont = new PregledController();
            
            if(pregCont.ZakazivanjePregledaPacijent(ime,prezime,imeDoktora,prezime,datum1,jmbg) == true)
            {
                MessageBox.Show("Pregled je uspesno zakazan!");
                this.Close();
            }
            else if(pregCont.DaLiJeTerminZauzet() == true){
                if (DoktorPrioritet.IsChecked == true)
                {
                    DoktorPrioritetWindow dpw = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, ime, prezime);
                    dpw.Show();
                }
                else
                {
                    VremePrioritetWindow vpw = new VremePrioritetWindow(datum1, ime, prezime);
                    vpw.Show();
                }
            }
            else
            {
                MessageBox.Show("Pregled nije zakazan.");
                this.Close();
            }
            






            /*PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.DobaviSvePregledePacijent();


            Pacijenti = new List<Pacijent>();
            PacijentRepository f = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = f.UcitajSvePacijente();

            int zauzetPregledFlag = 0;

           

            

            if (DaLiJeKorisnikMaliciozan(ime,prezime) == false)
            {

                foreach (Pregled preg in pregledi)
                {
                    if ((preg.Pocetak) == datum1)
                    {
                        MessageBox.Show("Odabrali ste termin koji je zauzet, na osnovu Vaseg prioriteta cemo Vam predloziti slobodne termine.");
                        zauzetPregledFlag = 1;
                        break;
                    }
                }
                if (zauzetPregledFlag == 0)
                {
                    p.Tip = TipPregleda.Standardni;
                    p.Pocetak = datum1;
                    p.Trajanje = trajanje;
                    Pacijent pac = new Pacijent { Jmbg = jmbg, Ime = ime, Prezime = prezime };
                    p.pacijent = pac;
                    Doktor dr = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
                    p.doktor = dr;
                    p.StatusPregleda = StatusPregleda.Zakazan;

                    ProstorijaRepository file = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
                    List<Prostorija> prostorije = file.DobaviSveProstorije();
                    foreach (Prostorija pr in prostorije)
                    {
                        if (pr.slobodna == true)
                        {
                            p.prostorija = pr;
                            pr.slobodna = false;
                            break;
                        }
                    }



                    pregledi.Add(p);

                    fajl.SacuvajPregledPacijent(pregledi);

                    MessageBox.Show("Pregled je uspesno zakazan.");

                    this.Close();
                }
                else if (zauzetPregledFlag == 1)
                {
                    if (DoktorPrioritet.IsChecked == true)
                    {
                        DoktorPrioritetWindow dpw = new DoktorPrioritetWindow(imeDoktora, prezimeDoktora, ime, prezime);
                        dpw.Show();
                    }
                    else
                    {
                        VremePrioritetWindow vpw = new VremePrioritetWindow(datum1, ime, prezime);
                        vpw.Show();
                    }
                }
            }
            else
            {
                this.Close();
            }
            */


        }

       /* private bool DaLiJeKorisnikMaliciozan(String imePacijenta, String prezimePacijenta)
        {
            foreach (Pacijent pacijent in Pacijenti)
            {
                if ((pacijent.Ime == imePacijenta) && (pacijent.Prezime == prezimePacijenta) && (pacijent.otkazaoPregled >= MAKSIMAMLNO_OTKAZIVANJA))
                {

                    MessageBox.Show("Zakazali ste i otkazali previse pregleda u proteklom periodu, privremeno Vam je zabranjeno zakazivanje pregleda.");
                    jesteMaliciozniKorisnik = true;
                    break;


                }

            }
            return jesteMaliciozniKorisnik;
        }
       */
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DoktorPrioritet.IsChecked == true)
            {
                MessageBox.Show("Odabrali ste doktora kao prioritet u slucaju da Vas termin nije slobodan.");
                prioritetDoktor = 1;
            }
            else if (VremePrioritet.IsChecked == true)
            {
                MessageBox.Show("Odabrali ste vreme kao prioritet u slucaju da Vas doktor nije slobodan.");
                prioritetVreme = 1;
            }

        }
        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            DoktorPrioritet.Foreground = Brushes.Blue;
            VremePrioritet.Foreground = Brushes.Blue;

        }
    }
}
