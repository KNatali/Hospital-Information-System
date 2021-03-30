using Model.DoktorModel;
using Model.PacijentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ProjekatSIMS.Model.PacijentModel
{

    public partial class OtkaziWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public OtkaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt");
            Pregledi = fajl.DobaviSve();
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //ovo je odabrani pregled za otkazivanje

            string linija;
            List<String> linije = new List<string>();

            using (StreamReader file = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt"))
            {
                while((linija = file.ReadLine()) != null)
                {
                    string[] parts = linija.Split(",");
                    if (parts[0] != p.Id.ToString())
                        linije.Add(linija);
                }
                file.Close();
            }
            File.WriteAllLinesAsync(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt", linije);
            MessageBox.Show("Vas pregled je otkazan.");
            this.Close();
           




        }
    }
}
