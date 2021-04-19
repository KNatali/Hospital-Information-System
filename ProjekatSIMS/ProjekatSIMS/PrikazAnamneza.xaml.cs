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
        public List<Anamneza> Anamneze {get; set;  } 
        public PrikazAnamneza(Pacijent p)
        {
            InitializeComponent();
   
            this.DataContext = this;



            List<Anamneza> anamneze = new List<Anamneza>();
            Anamneze = new List<Anamneza>();
            using (StreamReader r = new StreamReader(@"..\..\Fajlovi\Anamneza.txt"))
            {
                string json = r.ReadToEnd();
                anamneze = JsonConvert.DeserializeObject<List<Anamneza>>(json);
            }
            foreach (Anamneza a in anamneze)
            {
                if (a.zdravsteniKarton.pacijent.Jmbg==p.Jmbg)
                {
                    Anamneze.Add(a);
                }
            }

        }
    }
}
