using Model;
using Repository;
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

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PregledLekara : Page
    {
        public List<Doktor> doktori { get; set; }
        public PregledLekara()
        {
            InitializeComponent();
            this.DataContext = this;
            DoktorRepository doktorRepository = new DoktorRepository();
            doktori = doktorRepository.DobaviSve();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
