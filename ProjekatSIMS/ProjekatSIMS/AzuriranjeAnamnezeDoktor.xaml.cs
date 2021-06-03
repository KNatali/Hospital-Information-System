using Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{

    public partial class AzuriranjeAnamnezeDoktor : Page
    {
        private AzuriranjeAnamnezeController azuriranjeAnamnezeController = new AzuriranjeAnamnezeController();

        public Pacijent pacijent;
        public Anamneza anamneza;
        public AzuriranjeAnamnezeDoktor(Pacijent p,Anamneza an)
        {
            InitializeComponent();
            this.DataContext = this;
            Datum.Text = an.Datum.ToString();
            Opis.Text = an.OpisAnamneze;
            pacijent = p;
            anamneza = an;

        }

        private void Azuriranje(object sender, RoutedEventArgs e)
        {
            azuriranjeAnamnezeController.AzuriranjeAnamneze(anamneza, Opis.Text);
            PrikazAnamneza pa = new PrikazAnamneza(pacijent);

            this.NavigationService.Navigate(pa);


        }

        private void Odustani(object sender, RoutedEventArgs e)
        {

            this.NavigationService.GoBack();


        }

    }
  }
