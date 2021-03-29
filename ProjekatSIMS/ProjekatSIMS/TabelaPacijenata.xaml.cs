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
    public partial class TabelaPacijenata : Window
    {
        public CuvanjePacijenta fajl { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
        public TabelaPacijenata()
        {
            InitializeComponent();
            /*this.DataContext = this;
            Pacijenti = new List<Pacijent>();
            CuvanjePacijenta fajl = new CuvanjePacijenta();
            Pacijenti = fajl.DobaviPacijente();
            fajl = new CuvanjePacijenata(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt");
            DateTime datum1 = new DateTime(1999,02,17);
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
        private void Brisanje(object sender, RoutedEventArgs e)
        {
            // selektuje nekog pacijenta u tabeli i onda klikne na brisanje
            if (dataGridPacijenti.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGridPacijenti.SelectedItems.Count; i++)
                {
                    System.Data.DataRowView selektovani = (System.Data.DataRowView)dataGridPacijenti.SelectedItems[i];
                    String str = Convert.ToString(selektovani.Row.ItemArray[10]);
                }
            }
        }
    }
}
