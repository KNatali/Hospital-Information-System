using Model.DoktorModel;
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
using System.Windows.Shapes;

namespace ProjekatSIMS.Model.DoktorModel
{

    public partial class PrikazPregleda : Window
    {
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazPregleda()
        {
            InitializeComponent();
            this.DataContext = this;

            Pregledi = new List<Pregled>();
            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.UcitajSvePreglede();
        }

        private void OtkaziPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0]; //selektovani red

            CuvanjePregledaDoktor fajl = new CuvanjePregledaDoktor(@"..\..\Fajlovi\Pregled.txt");
            List<Pregled> pregledi = fajl.UcitajSvePreglede();
            foreach (Pregled pr in pregledi)
            {
                if (pr.Id == p.Id)
                {
                    pregledi.Remove(pr);
                    break;
                }
            }
            fajl.Sacuvaj(pregledi);
            
            
               
           MessageBox.Show("Pregled je uspjesno otkazan");
           this.Close();
        }

        private void IzmijeniPregled(object sender, RoutedEventArgs e)
        {
           
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            PrikazPromjena pr = new PrikazPromjena(p);
            pr.Show();


        }

        private void PrikazProfila(object sender, RoutedEventArgs e)
        {
          
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];

           ZdravstveniKarton z = new ZdravstveniKarton(p.pacijent);
            z.Show();


        }

        private void ZapocniPregled(object sender, RoutedEventArgs e)
        {
            Pregled p = (Pregled)dataGridPregledi.SelectedItems[0];
            IzvrsavanjePregleda i = new IzvrsavanjePregleda(p.pacijent);
            i.Show();


        }
    }
}
