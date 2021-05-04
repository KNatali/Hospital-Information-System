using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{
  
    public partial class OceniLekaraWindow : Window
    {
        public List<Pregled> pregledi
        {
            get;
            set;
        }

        public int mozeSeOceniti = 0;

        public OceniLekaraWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            OcenaLekara ol = new OcenaLekara();
            String imeLekara = Ime.Text;
            String prezimeLekara = Prezime.Text;
            String ocenaLekara = Ocena.Text;
            String komentar = Komentar.Text;
            OcenaLekaraRepository fajl = new OcenaLekaraRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
            List<OcenaLekara> oceneLekara = fajl.DobaviSveOceneLekara();

            pregledi = new List<Pregled>();
            PregledRepository file = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            pregledi = file.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.StatusPregleda == StatusPregleda.Zavrsen) && (p.doktor.Prezime == prezimeLekara) && (p.doktor.Ime == imeLekara))
                {
                    mozeSeOceniti = 1;
                    break;
                }
            }

            if(mozeSeOceniti == 1)
            {
                ol.ImeLekara = imeLekara;
                ol.PrezimeLekara = prezimeLekara;
                ol.Ocena = ocenaLekara;
                ol.Komentar = komentar;
                oceneLekara.Add(ol);
                fajl.SacuvajOcenuLekara(oceneLekara);
                MessageBox.Show("Hvala Vam sto ste izdvojili vreme da ocenite lekara!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lekara mozete oceniti samo ako ste prethodno bili na pregledu kod njega. ");
            }


        }
    }
}
