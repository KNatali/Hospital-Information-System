using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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
   
    public partial class LekoviWindow : Window
    {
        
        public LekoviWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LijekRepository lekRepository = new LijekRepository();
            List<Lijek> l = lekRepository.DobaviSveLekove();

            List<Lijek> Lekovi = new List<Lijek>();
            foreach(Lijek lek in l)
            {
                if(lek.Status == 0)
                {
                    Lekovi.Add(lek);
                }
            }
            dgrLekovi.ItemsSource = Lekovi;

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            DodajLek dl = new DodajLek();
            dl.Show();
        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            Lijek lek = (Lijek)dgrLekovi.SelectedItems[0];
            LijekRepository lekRepository = new LijekRepository();
            lekRepository.obrisiLek(lek);



        }
        private void pregledaj(object sender, RoutedEventArgs e)
        {
            Lijek lek = (Lijek)dgrLekovi.SelectedItems[0];
            PregledajLek pl = new PregledajLek(lek);
            pl.Show();
        }
    }
}
