using System;
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
using Model;
using Controller;

namespace ProjekatSIMS.WindowSekretar
{
    public partial class NedeljniIzvestajWindow : Window
    {
        private PregledController pregledController;
        public List<Pregled> Pregledi { get; set; }
        public Pregled pregled { get; set; }
        public NedeljniIzvestajWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Tip.ItemsSource = Enum.GetValues(typeof(TipPregleda));
            /*List<Pregled> tabelaPregleda = new List<Pregled>();
            Pregledi = new List<Pregled>();
            pregledController = (Application.Current as App).PregledController;
            tabelaPregleda = pregledController.DobaviSveSekretar();
            foreach (Pregled p in tabelaPregleda)
            {
                Pregledi.Add(p);
            }*/
        }
        private void Prikazi(object sender, SelectionChangedEventArgs e)
        {
            dataGridPregledi.Visibility = Visibility.Visible;
            Pregledi = new List<Pregled>();
            List<Pregled> pregledi = new List<Pregled>();
            pregledController = new PregledController();
            pregledi = pregledController.DobaviSveSekretar();
            TipPregleda tippregleda = (TipPregleda)Tip.SelectedIndex;
            if (tippregleda.ToString() == "Standardni")
            {
                foreach (Pregled p in pregledi)
                {
                    if (DateTime.Compare((DateTime)Od.SelectedDate, p.Pocetak) <= 0 && DateTime.Compare((DateTime)Do.SelectedDate, p.Pocetak) >= 0)
                    {
                        Pregledi.Add(p);
                    }
                }
            }
            else if (tippregleda.ToString() == "Operacija")
            {
            }
        }
    }
}
