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

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for SvaStatickaOprema.xaml
    /// </summary>
    public partial class SvaStatickaOprema : Window
    {
        public SvaStatickaOprema()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Inventar> oprema = new List<Inventar>();
            CuvanjeProstorija cuvanje = new CuvanjeProstorija(@"..\..\Fajlovi\Prostorije.txt");
            List<Prostorija> prostorije = new List<Prostorija>();
            prostorije = cuvanje.UcitajProstorije();


            foreach (Prostorija p in prostorije)
            {
                if (p.inventar != null && p.id != "0")
                {
                    oprema.AddRange(p.inventar);
                    //implementirati da se prostorija moze videti, da u fajlu bude upisan samo naziv ne cela prostorija
                }
            }
            dgrStatickaOprema.ItemsSource = oprema;
        }
    }
}
