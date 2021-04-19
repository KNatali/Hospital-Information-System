using Model;
using Newtonsoft.Json;
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
    /// Interaction logic for PrikazAnamneza.xaml
    /// </summary>
    public partial class PrikazAnamneza : Page
    {
        public List<Anamneza> Anamneze { get; set; }
        public Pacijent pacijent {get; set;}
        public PrikazAnamneza(Pacijent p)
        {
            InitializeComponent();
   
            this.DataContext = this;
            pacijent = p;


            List<ZdravsteniKarton> kartoni= new List<ZdravsteniKarton>();
            Anamneze = new List<Anamneza>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json = r.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg==p.Jmbg)
                {
                    if (k.anamneza != null)
                    {
                        foreach (Anamneza a in k.anamneza)
                        
                            Anamneze.Add(a);
                        
                    }
                   
                }
            }

        }

        private void ZdravstveniKarton(object sender, RoutedEventArgs e)
        {
            ZdravstveniKartonDoktor z = new ZdravstveniKartonDoktor(pacijent);
            // this.NavigationService.Navigate(new Uri("ZdravstveniKartonDoktor.xaml", UriKind.Relative));
            this.NavigationService.Navigate(z);
        }
    }
}
