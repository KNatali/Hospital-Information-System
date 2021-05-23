using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository;
using System;
using Controller;
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
    public partial class NoviAlergenSWindow : Window
    {
        public Pacijent p { get; set; }
        public NoviAlergenSWindow(Pacijent pac)
        {
            InitializeComponent();
            this.DataContext = this;
            p = pac;
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            /*String alergen = Naziv.Text;
                                            List<String> alergeni = new List<String>();
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();

            using (StreamReader sr = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json = sr.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == p.Jmbg)
                {
                    if (k.Alergeni == null)
                        k.Alergeni.Add(alergen);
                    else
                        k.Alergeni.Add(alergen);
                }
            }
            PregledRepository pr = new PregledRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
            pr.SacuvajAlergen(kartoni);*/

            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            ZdravstvenikartonController zdravstveniKartonController = new ZdravstvenikartonController();
            if(zdravstveniKartonController.kreiranjeAlergena(Naziv.Text,p)==true)
            {
                MessageBox.Show("Alergen je dodat u listu alergena.", "OBAVEŠTENJE");
            }
            foreach(ZdravsteniKarton zk in kartoni)
            {
                zk.Alergeni.Add(Naziv.Text);
            }
            

            /*ZdravstveniKarton zk = new ZdravstveniKarton();
            List<String> lista = new List<String>();
            lista.Add(alergen);
            foreach (string item in lista)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;
                //zk.Add(itm);
            }
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");*/

            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
