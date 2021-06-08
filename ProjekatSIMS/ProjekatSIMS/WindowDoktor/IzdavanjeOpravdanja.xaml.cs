using Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
 
    public partial class IzdavanjeOpravdanja : Page
    {
        private Pacijent pacijent { get; set; }

        public IzdavanjeOpravdanja(Pacijent p)
        {
            InitializeComponent();
            pacijent = p;
            Ime.Text = p.Ime;
            Prezime.Text = p.Prezime;
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();


        }
    }
}
