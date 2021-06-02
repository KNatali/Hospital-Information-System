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
  
    public partial class IzdajReceptDoktor : Page
    {
        public List<Lijek> Lijekovi { get; set; }
        public ZdravsteniKarton zdravstveniKarton { get; set; }
        public Lijek izabraniLijek { get; set; }
        private IzdavanjeReceptaController receptController = new IzdavanjeReceptaController();
        private AlergijeNaLijekController alergijeNaLijekController = new AlergijeNaLijekController();
        private LijekRepository lijekRepository = new LijekRepository();
     

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
            List<Lijek>  lijekovi = lijekRepository.DobaviSve();
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

      
        private void Alergican(object sender, SelectionChangedEventArgs e)
        {

            izabraniLijek = (Lijek)Lijek.SelectedItem;
            if(alergijeNaLijekController.IsPacijentAlergican(izabraniLijek, Pacijent))
                MessageBox.Show("Pacijent je alergican na izabrani lijek. Izaberi novi!");
           
         }

     
    }
}
