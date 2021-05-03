using Model;
using Newtonsoft.Json;
using Repository;
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
    public partial class HitanPregledSWindow : Window
    {
        public Pacijent pac { get; set; }
        public Pregled pre { get; set; }
        public List<Doktor> Doktori { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public HitanPregledSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.GetListaPregledaSekretar();
        }

        private void Prikaz(object sender, RoutedEventArgs e)
        {
            //Pregled pre = new Pregled();
            Doktor d = new Doktor();
            //pre.Pocetak = DateTime.Now;
            //pre.Pocetak.AddHours(1);
            List<Pregled> Pregledi1 = new List<Pregled>();
            List<Pregled> ListaPregleda = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            ListaPregleda = fajl.GetListaPregledaSekretar();

            Specijalizacija spec = (Specijalizacija)Oblasti.SelectedIndex;
            if (spec.ToString() == "Opsta")
            {
                dataGridPregledi.Visibility = Visibility.Visible;
                foreach (Pregled pr in ListaPregleda)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Opsta)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
                //dataGridPregledi.ItemsSource = Pregledi1;   //refresh tabele
            }
            else if (spec.ToString() == "Kardiologija")
            {
                dataGridPregledi.Visibility = Visibility.Visible;
                foreach (Pregled pr in Pregledi)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Kardiologija)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
            }
            else if (spec.ToString() == "Hirurgija")
            {
                dataGridPregledi.Visibility = Visibility.Visible;
                foreach (Pregled pr in Pregledi)
                {
                    if (pr.doktor.Specijalizacija == Specijalizacija.Hirurgija)
                    {
                        Pregledi1.Add(pr);
                        pre = pr;
                    }
                }
            }
        }
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            /*string str = Oblasti.Text;
            ComboBoxItem cbi = (ComboBoxItem)Oblasti.SelectedItem;
            string opcija = cbi.Content.ToString();
            string val = Oblasti.SelectedValue.ToString();
            if (opcija == "Opšta")
            {
                
            }
            else if (opcija == "Kardiologija")
            {
                
            }
            else if (opcija == "Hirurgija")
            {

            }*/
        }
    }
    
}
