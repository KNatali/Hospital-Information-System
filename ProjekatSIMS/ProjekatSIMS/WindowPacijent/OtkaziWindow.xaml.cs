using Model;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjekatSIMS
{
 
    public partial class OtkaziWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        
        public OtkaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

            Pacijenti = new List<Pacijent>();
            PacijentRepository file = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = file.UcitajSvePacijente();
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Pregled odabraniPregled = (Pregled)dataGridPregledi.SelectedItems[0]; //ovo je odabrani pregled za otkazivanje
            string ime;
            string prezime;
            ime = odabraniPregled.pacijent.Ime;
            prezime = odabraniPregled.pacijent.Prezime;

            //ako je pacijent otkazao pregled to mu se broji
            foreach(Pacijent pacijent in Pacijenti)
            {
                if( (pacijent.Prezime == prezime) && (pacijent.Ime == ime))
                {
                    pacijent.otkazaoPregled++;
                }
            }
            string newJ = JsonConvert.SerializeObject(Pacijenti);
            File.WriteAllText(@"..\..\..\Fajlovi\Pacijent.txt", newJ);



            using (StreamReader file = new StreamReader(@"..\..\..\Fajlovi\Pregled.txt"))
            {

                Pregledi.Remove(odabraniPregled);

            }
            string newJson = JsonConvert.SerializeObject(Pregledi);
            File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
            MessageBox.Show("Vas pregled je otkazan.");
            this.Close();
           





        }
    }
}
