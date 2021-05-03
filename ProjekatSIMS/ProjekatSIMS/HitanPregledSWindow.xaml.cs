using Model;
using Newtonsoft.Json;
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
        public List<Doktor> Doktori { get; set; }
        public HitanPregledSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = p;
            //Oblasti.ItemsSource = Enum.GetValues(typeof(Oblast));
        }

        /*private void Prikaz(object sender, RoutedEventArgs e)
        {
            string str = Nalog.Text;
            ComboBoxItem cbi = (ComboBoxItem)Nalog.SelectedItem;
            string opcija = cbi.Content.ToString();
            string val = Nalog.SelectedValue.ToString();
            if (opcija == "Kreiraj hitan nalog")
            {
                LabelaJMBG.Visibility = Visibility.Visible;
                LabelaIme.Visibility = Visibility.Visible;
                LabelaPrezime.Visibility = Visibility.Visible;
                Jmbg.Visibility = Visibility.Visible;
                Ime.Visibility = Visibility.Visible;
                Prezime.Visibility = Visibility.Visible;
                dataGridPacijenti.Visibility = Visibility.Hidden;
            }
            else if (opcija == "Odaberi postojeći nalog")
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
        }*/
        private void Zakazi(object sender, RoutedEventArgs e)
        {
            string str = Oblasti.Text;
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

            }
        }
    }
    
}
