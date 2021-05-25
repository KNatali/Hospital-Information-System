using Controller;
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

    public partial class AzuriranjeAnamnezeDoktor : Page
    {
        private AzuriranjeAnamnezeController azuriranjeAnamnezeController = new AzuriranjeAnamnezeController();
        public ZdravsteniKarton zk = new ZdravsteniKarton();
        public Pacijent pacijent;
        public Anamneza anamneza;
        public AzuriranjeAnamnezeDoktor(Pacijent p,Anamneza an)
        {
            InitializeComponent();
            this.DataContext = this;
            Datum.Text = an.Datum.ToString();
            Opis.Text = an.OpisAnamneze;
            pacijent = p;
            anamneza = an;

        }

        private void Azuriranje(object sender, RoutedEventArgs e)
        {
            azuriranjeAnamnezeController.AzuriranjeAnamneze(anamneza, Opis.Text, pacijent);
            
           /* List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();

            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"))
            {
                string json = r.ReadToEnd();
                kartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            foreach (ZdravsteniKarton k in kartoni)
            {
                if (k.pacijent.Jmbg == pacijent.Jmbg)
                {
                    if (k.anamneza != null)
                    {
                        
                        foreach (Anamneza i in k.anamneza)
                        {

                            if (i.OpisAnamneze == anamneza.OpisAnamneze)

                                i.OpisAnamneze= Opis.Text;
                               
                        }
                    }

                }
            }

            string newJson = JsonConvert.SerializeObject(kartoni);
            File.WriteAllText(@"..\..\..\Fajlovi\ZdravstveniKarton.txt", newJson);
           */
            PrikazAnamneza pa = new PrikazAnamneza(pacijent);

            this.NavigationService.Navigate(pa);


        }

     }
  }
