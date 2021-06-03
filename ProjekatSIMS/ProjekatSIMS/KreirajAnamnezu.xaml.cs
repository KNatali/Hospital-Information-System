using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.DTO;
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
            AnamnezaDTO anamneza = new AnamnezaDTO(Opis.Text, (DateTime)Datum.SelectedDate, Pacijent.IdKartona);
            izdavanjeAnamnezeController.KreiranjeAnamneze(anamneza);
            MessageBox.Show("Uspjesno je sacuvana anamneza");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(Pacijent);

            this.NavigationService.Navigate(z);


        }

        
    }
}
