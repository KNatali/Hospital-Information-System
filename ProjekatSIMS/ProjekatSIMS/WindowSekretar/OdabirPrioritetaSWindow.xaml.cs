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
    public partial class OdabirPrioritetaSWindow : Window
    {
        public Pacijent pacijent { get; set; }
        public OdabirPrioritetaSWindow(Pacijent p)
        {
            InitializeComponent();
            this.DataContext = this;
            pacijent = p;
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zakazi_termin(object sender, RoutedEventArgs e)
        {
            ComboBoxItem prioritet = (ComboBoxItem)Prioritet.SelectedItem;
            string odabranPrioritet = prioritet.Content.ToString();
            OdabirPrioritetaZakazivanja(odabranPrioritet);
            this.Close();
        }
        private void OdabirPrioritetaZakazivanja(string odabranPrioritet)
        {
            if (odabranPrioritet == "-")
                ZakazivanjeBezPrioriteta();
            else if (odabranPrioritet == "Kod određenog doktora")
                ZakazivanjeSaPrioritetomDoktor();
            else if (odabranPrioritet == "U određeno vreme")
                ZakazivanjeSaPrioritetomVreme();
        }
        private void ZakazivanjeSaPrioritetomVreme()
        {
            PrioritetDatumSWindow pda = new PrioritetDatumSWindow(pacijent);
            pda.Show();
        }

        private void ZakazivanjeSaPrioritetomDoktor()
        {
            PrioritetDoktorSWindow pd = new PrioritetDoktorSWindow(pacijent);
            pd.Show();
        }

        private void ZakazivanjeBezPrioriteta()
        {
            ZakaziTerminSWindow zt = new ZakaziTerminSWindow(pacijent);
            zt.Show();
        }
    }
}
