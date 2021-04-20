using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository;
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
    public partial class NoviAlergenSWindow : Window
    {
        public NoviAlergenSWindow()
        {
            InitializeComponent();
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            String alergen = Naziv.Text;
            ZdravstveniKarton zk = new ZdravstveniKarton();
            List<String> lista = new List<String>();
            lista.Add(alergen);
            foreach (string item in lista)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;
                //zk.Add(itm);
            }
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
            /*List<string> lista = new List<string>();
            lista.Add(alergen);

            JArray newEventJsonItem = new JArray(lista);//Convert newEvent to JArray.

            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\ZdravstveniKarton.txt");
            JObject jsonObject = JObject.Parse(fajl.ReadAllText(@"..\..\..\Fajlovi\ZdravstveniKarton.txt"));
            JArray incomingEvents = jsonObject.Value<JArray>();
            incomingEvents.Add(newEventJsonItem);//Insert new JArray object.

            Console.WriteLine(JsonConvert.SerializeObject(incomingEvents, Formatting.Indented));*/
            this.Close();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
