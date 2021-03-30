using Model.DoktorModel;
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

namespace ProjekatSIMS.Model.DoktorModel
{
    /// <summary>
    /// Interaction logic for PrikazPromjena.xaml
    /// </summary>
    public partial class PrikazPromjena : Window
    {

        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPromjena(Pregled pregled)
        {
            InitializeComponent();
            this.DataContext = this;


            Pregledi = new List<Pregled>();

            Pregledi.Add(pregled);
            
        }

        private void PotvrdiIzmjenu(object sender, RoutedEventArgs e)
        {

        }
    }
}
