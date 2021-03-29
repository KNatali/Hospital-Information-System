using Model;
using Model.SekretarModel;
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
    public partial class PregledPacijenata : Window
    {
        public CuvanjePacijenta fajl { get; set; }
        public PregledPacijenata()
        {
            InitializeComponent();
            this.DataContext = this;
            fajl = new CuvanjePacijenata(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt");
            /*DateTime datum1 = new DateTime(1999,02,17);
            Pacijent p = new Pacijent
            {
                Jmbg = "152",
                Ime = "Milan",
                Prezime = "anic",
                Adresa = "dd",
                BrojTelefona = "065",
                DatumRodjenja = datum1,
                Email = "scsc"
            };
            fajl.Sacuvaj(p);*/
        }
        
    }
}
