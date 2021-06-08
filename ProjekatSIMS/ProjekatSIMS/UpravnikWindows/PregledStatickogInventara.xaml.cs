using Controller;
using Model;
using ProjekatSIMS.Controller;
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

namespace ProjekatSIMS.UpravnikWindows
{
    public partial class PregledStatickogInventara : Page
    {
        public List<Inventar> StatickiInventar { get; set; }
        public InventarController InventarController { get; set; }

        public PregledStatickogInventara()
        {
            InitializeComponent();
            this.DataContext = this;
            InventarController = new InventarController();
            StatickiInventar = InventarController.InventarService.inventarRepository.DobaviInventarPoVrsti(true);
            dgrStatickaOprema.ItemsSource = StatickiInventar;
        }
        private void ObrisiStatickiInventar(object sender, RoutedEventArgs e)
        {
            Inventar inventarZaBrisanje = (Inventar)dgrStatickaOprema.SelectedItems[0];
            InventarController.InventarService.inventarRepository.ObrisiInventar(inventarZaBrisanje.id);
            StatickiInventar = InventarController.InventarService.inventarRepository.DobaviInventarPoVrsti(true);
            dgrStatickaOprema.ItemsSource = StatickiInventar;
        }
        private void IzmeniStatickiInventar(object sender, RoutedEventArgs e)
        {

        }
       
    }
}