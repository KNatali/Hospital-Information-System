using Model;
using Model.DoktorModel;
using Model.PacijentModel;
using Model.UpravnikModel;
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

namespace ProjekatSIMS.Model.PacijentModel
{
    /// <summary>
    /// Interaction logic for VidiWindow.xaml
    /// </summary>
    public partial class VidiWindow : Window
    {
        public CuvanjePregledaPacijent fajl { get; set; }
        public VidiWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            fajl = new CuvanjePregledaPacijent(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\PregledPacijent.txt");
            DateTime pocetak = new DateTime(2020, 10, 11);
            Pacijent pa = new Pacijent { jmbg = "152", ime = "Milan", prezime = "anic", adresa = "dd", brojTelefona = "065", datumRodjenja = pocetak, email = "scsc" };
            Doktor d = new Doktor { Jmbg = "152", Ime = "Milos", Prezime = "anissc", Adresa = "dd", BrojTelefona = "065", DatumRodjenja = pocetak, Email = "scscghg" };

            Pregled p = new Pregled { Id = 1, Pocetak = pocetak, Trajanje = 30, pacijent = pa, doktor = d };
            fajl.Sacuvaj(p);
        }
    }
}
