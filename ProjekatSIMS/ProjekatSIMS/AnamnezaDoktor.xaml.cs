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
        public AnamnezaRepository anamnezaRepository=new AnamnezaRepository();
        public AnamnezaDoktor(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            Datum.SelectedDate = DateTime.Now;
            pacijent = p;
        }

        private void KreirajAnamnezu(object sender, RoutedEventArgs e)
        {

            
            //prikupljanje polja
            String opis = Opis.Text;
            DateTime datum = (DateTime)Datum.SelectedDate;
            //TREBA DODATI ZDRAVSTVENI KARTON
            Anamneza a = new Anamneza();
            a.OpisAnamneze = opis;
            a.datum = datum;
            a.zdravsteniKarton.pacijent = pacijent;

            List<Anamneza> anamneze = new List<Anamneza>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Anamneza.txt")) 
            {
                string json = r.ReadToEnd();
                anamneze = JsonConvert.DeserializeObject<List<Anamneza>>(json);
            }
            anamneze.Add(a);
            anamnezaRepository.SacuvajAnamnezu(anamneze);

        }
    }
}
