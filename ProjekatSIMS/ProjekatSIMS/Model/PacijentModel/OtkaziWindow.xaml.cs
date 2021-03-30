using Model.DoktorModel;
using Model.PacijentModel;
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

namespace ProjekatSIMS.Model.PacijentModel
{
    /// <summary>
    /// Interaction logic for OtkaziWindow.xaml
    /// </summary>
    public partial class OtkaziWindow : Window
    {
        public List<Pregled> Pregledi { get; set; }
        public OtkaziWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent();
            Pregledi = fajl.DobaviSve();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            CuvanjePregledaPacijent fajl = new CuvanjePregledaPacijent();
            List<Pregled> pregledi = fajl.DobaviSve();
        }
    }
}
