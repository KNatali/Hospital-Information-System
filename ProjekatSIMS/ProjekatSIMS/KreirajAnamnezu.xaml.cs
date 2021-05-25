using Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    
    public partial class KreirajAnamnezu : Page
    {
        public Pacijent Pacijent { get; set; }
        private IzdavanjeAnamnezeController izdavanjeAnamnezeController = new IzdavanjeAnamnezeController();

        public KreirajAnamnezu(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;

            Datum.SelectedDate = DateTime.Now;
           
            Pacijent = p;
        }

        private void KreiranjeAnamneze(object sender, RoutedEventArgs e)
        {
            izdavanjeAnamnezeController.KreiranjeAnamneze(Opis.Text, (DateTime)Datum.SelectedDate, Pacijent);
            MessageBox.Show("Uspjesno je sacuvana anamneza");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(Pacijent);

            this.NavigationService.Navigate(z);


        }

        
    }
}
