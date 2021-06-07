using Controller;
using Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PregledLekara : Page
    {
        public List<Doktor> doktori { get; set; }
        public DoktorController doktorController = new DoktorController();
        public PregledLekara()
        {
            InitializeComponent();
            this.DataContext = this;
            doktori = doktorController.DobaviSve();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
