using Model;
using Newtonsoft.Json;
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
    /// <summary>
    /// Interaction logic for AnamnezaDoktor.xaml
    /// </summary>
    public partial class AnamnezaDoktor : Page
    {
        public Pacijent pacijent { get; set; }
       
        public AnamnezaDoktor(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
           
            Datum.SelectedDate = DateTime.Now;
            pacijent = p;
        }

        private void KreirajAnamnezu(object sender, RoutedEventArgs e)
        {
            AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
            List<Anamneza> lista = new List<Anamneza>();
            Anamneza a = new Anamneza();
            a.OpisAnamneze = Opis.Text;
            a.datum =(DateTime) Datum.SelectedDate;
            a.zdravsteniKarton.pacijent = pacijent;
           
            if (anamnezaRepository.DobaviSveAnamneze() == null)
                lista.Add(a);
            else
            {
                lista = anamnezaRepository.DobaviSveAnamneze();
                lista.Add(a);
            }

            anamnezaRepository.SacuvajAnamnezu(lista);
            MessageBox.Show("Uspjesno je sacuvana anamneza");
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
        
            this.NavigationService.Navigate(z);

        }
    }
}
