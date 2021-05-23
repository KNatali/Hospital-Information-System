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

namespace ProjekatSIMS
{
    public partial class ListaAlergenaSWindow : Window
    {
        private ZdravstvenikartonController zdravstveniKartonController;
        public ZdravsteniKarton zdrkarton { get; set; }
        public List<ZdravsteniKarton> Karton { get; set; }
        public List<String> Alergeni1 { get; set; }
        public Pacijent pac { get; set; }
        public ListaAlergenaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            List<String> alergeni = new List<String>();
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            Alergeni1 = new List<String>();
            zdravstveniKartonController = new ZdravstvenikartonController();
            alergeni = zdravstveniKartonController.DobaviSveAlergene();

            /*using (StreamReader sr = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json = sr.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }*/
            ZdravsteniKarton zk = new ZdravsteniKarton();
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == p.Jmbg)
                {
                    zk = k;
                    if (k.Alergeni == null)

                        alergeni = new List<String>();
                    else

                        alergeni = k.Alergeni;
                }
            }
            foreach (String a in alergeni)
            {
                Alergeni1.Add(a);
            }

        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            this.Close();
            NoviAlergenSWindow na = new NoviAlergenSWindow(pac);
            na.Show();
        }
    }
}
