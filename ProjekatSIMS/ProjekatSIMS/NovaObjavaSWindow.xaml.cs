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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    public partial class NovaObjavaSWindow : Window
    {
        public NovaObjavaSWindow()
        {
            InitializeComponent();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            PorukaProvere();
        }

        private void PorukaProvere()
        {
            MessageBoxResult ret = MessageBox.Show("Da li želite da otkažete postavljanje obaveštenja?", "PROVERA", MessageBoxButton.YesNo);
            switch (ret)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            Notifikacija n = new Notifikacija();
            PopunjavanjePoljaNotifikacije(n);
            UpisivanjeUFajl(n);
            MessageBox.Show("Obaveštenje je uspešno postavljeno.", "OBAVEŠTENJE");
            this.Close();
        }

        private static void UpisivanjeUFajl(Notifikacija n)
        {
            NotifikacijaRepository fajlVesti = new NotifikacijaRepository(@"..\..\..\Fajlovi\Vesti.txt");
            List<Notifikacija> listaNotifikacija = fajlVesti.DobaviNotifikacije();
            listaNotifikacija.Add(n);
            fajlVesti.SacuvajNotifikaciju(listaNotifikacija);
        }

        private void PopunjavanjePoljaNotifikacije(Notifikacija n)
        {
            n.Naslov = Naslov.Text;
            n.Tekst = Tekst.Text;
            n.Datum = DateTime.Now;
        }
    }
}
