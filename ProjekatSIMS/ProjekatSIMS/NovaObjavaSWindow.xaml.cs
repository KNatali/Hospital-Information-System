using Model;
using Repository;
using System;
using Controller;
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

namespace ProjekatSIMS
{
    public partial class NovaObjavaSWindow : Window
    {
        public NovaObjavaSWindow()
        {
            InitializeComponent();
        }

        private void Otkazi_postavljanje(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete postavljanje obaveštenja?", "PROVERA", MessageBoxButton.YesNo);
            if (ret==MessageBoxResult.Yes)
                this.Close();
        }
        private void Postavi_obavestenje(object sender, RoutedEventArgs e)
        {
            Notifikacija novoObavestenje = new Notifikacija();
            NotifikacijaController notifikacijaController = new NotifikacijaController();
            PopunjavanjePoljaZaNovoObavestenje(novoObavestenje);
            if (notifikacijaController.PisanjeObavestenja(novoObavestenje) == true)
            {
                MessageBox.Show("Obaveštenje je uspešno postavljeno.", "OBAVEŠTENJE");
                this.Close();
            }
        }
        private void PopunjavanjePoljaZaNovoObavestenje(Notifikacija novoObavestenje)
        {
            novoObavestenje.Naslov = Naslov.Text;
            novoObavestenje.Tekst = Tekst.Text;
            novoObavestenje.Datum = DateTime.Now;
        }
    }
}
