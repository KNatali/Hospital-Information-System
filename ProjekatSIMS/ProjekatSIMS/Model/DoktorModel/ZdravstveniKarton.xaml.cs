using Model;
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

namespace ProjekatSIMS.Model.DoktorModel
{
  
    public partial class ZdravstveniKarton : Window
    {
        public ZdravstveniKarton(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            Jmbg.Text = pacijent.Jmbg;
            Ime.Text = pacijent.Ime;
            Prezime.Text = pacijent.Prezime;
            Datum.Text = pacijent.DatumRodjenja.ToString();
            Email.Text = pacijent.Email;
            Broj.Text = pacijent.BrojTelefona;
            Adresa.Text = pacijent.Adresa;

        }
    }
}
