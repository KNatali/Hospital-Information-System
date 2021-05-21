using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.DTO;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for IzdajReceptDoktor.xaml
    /// </summary>
    /// 

    public partial class IzdajReceptDoktor : Page
    {
        public List<Lijek> Lijekovi { get; set; }
        public ZdravsteniKarton zdravstveniKarton { get; set; }
        public Lijek izabraniLijek { get; set; }
        private ReceptController receptController = new ReceptController();
        private LijekRepository lijekRepository = new LijekRepository();
        private ReceptRepository receptRepository = new ReceptRepository();
        private ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();

        public Pacijent Pacijent { get; set; }
        public IzdajReceptDoktor(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            UcitavanjePodataka(p);

        }

        private void UcitavanjePodataka(Pacijent p)
        {
            Pacijent = p;
            Ime.Text = p.Ime;
            Prezime.Text = p.Prezime;
            Lijekovi = new List<Lijek>();
            List<Lijek> lijekovi = new List<Lijek>();
            lijekovi = lijekRepository.DobaviSve();
            foreach (Lijek l in lijekovi)
            {
                Lijekovi.Add(l);
            }
        }

        private void IzdavanjeRecepta(object sender, RoutedEventArgs e)
        {
            izabraniLijek = (Lijek)Lijek.SelectedItem;
            int izabranoTrajanje = Convert.ToInt32(Trajanje.Text);
            DateTime izabraniDatum = (DateTime)Datum.SelectedDate;
            String izabraniPeriod = Period.Text;
            double sat = Convert.ToDouble(Sat.Text);
            double minut = Convert.ToDouble(Minut.Text);
            String izabranaKolicina = Kolicina.Text;

            ReceptDTO receptDTO = new ReceptDTO(Pacijent,izabraniLijek.NazivLeka, izabranoTrajanje, izabraniDatum, sat, minut,izabraniPeriod, izabranaKolicina);

            receptController.IzdavanjeRecepta(receptDTO);
           

            MessageBox.Show("Uspjesno je izdat recept");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(Pacijent);
            this.NavigationService.Navigate(z);

        }

       /* private DateTime FormiranjeVremenaPrveKonzumacije()
        {
            DateTime izabraniDatum = (DateTime)Datum.SelectedDate;
            DateTime datum1 = new DateTime();
            double sat = Convert.ToDouble(Sat.Text);
            double minut = Convert.ToDouble(Minut.Text);
            datum1 = izabraniDatum.AddHours(sat);
            datum1 = datum1.AddMinutes(minut);
            return datum1;
        }

        private Recept KreiranjeRecepta(DateTime datum1, string ucestalostKoriscenja)
        {
            Recept r = new Recept();
            r.DatumPropisivanjaLeka = datum1;
            r.Kolicina = Kolicina.Text;
            r.zdravsteniKarton = zdravstveniKarton;
            r.NazivLeka = izabraniLijek.NazivLeka;
            r.Uputstvo = "Terapija traje " + Trajanje.Text + " dana i lijek se uzima " + ucestalostKoriscenja;
            return r;
        }

        private string KreiranjeTekstaZaUputstvo()
        {
            String ucestalostKoriscenja = "";
            if (Period.Text == "1")
                ucestalostKoriscenja = "svaki dan";
            else if (Convert.ToDouble(Period.Text) < 5)
                ucestalostKoriscenja = "svaka " + Period.Text + " dana";
            else
                ucestalostKoriscenja = "svakih " + Period.Text + " dana";
          
            return ucestalostKoriscenja;
        }
       */
        private void Alergican(object sender, SelectionChangedEventArgs e)
        {

            izabraniLijek = (Lijek)Lijek.SelectedItem;
            if(receptController.IsPacijentAlergican(izabraniLijek, Pacijent))
                MessageBox.Show("Pacijent je alergican na izabrani lijek. Izaberi novi!");
           
            
            

        }

       /* private void IsPcijentAlergicanNaLijek(List<string> alergeni)
        {
            if (izabraniLijek.Alergeni != null)
            {
                foreach (String s in izabraniLijek.Alergeni)
                {
                    if (alergeni.Contains(s))
                    {
                        MessageBox.Show("Pacijent je alergican na izabrani lijek. Izaberi novi!");
                        return;
                    }


                }
            }
        }

        private List<string> DobavljanjeAlergenaPacijenta(List<string> alergeni, List<ZdravsteniKarton> kartoni)
        {
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == Pacijent.Jmbg)
                {
                    zdravstveniKarton = k;
                    if (k.Alergeni == null)
                        alergeni = new List<String>();
                    else
                        alergeni = k.Alergeni;
                    break;
                }
            }

            return alergeni;
        }*/
    }
}
