﻿using Model;
using Repository;
using Controller;
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
using ProjekatSIMS.Controller;

namespace ProjekatSIMS
{
    public partial class ManipulacijaRadaDoktoraSWindow : Window
    {
        private NeradniDaniController neradniDaniController;
        public Doktor dok { get; set; }
        public List<NeradniDani> NeradniDani { get; set; }
        public ManipulacijaRadaDoktoraSWindow(Doktor doktor)
        {
            InitializeComponent();
            this.DataContext = this;
            dok = doktor;
            List<NeradniDani> tabelaNeradnihDana = new List<NeradniDani>();
            NeradniDani = new List<NeradniDani>();
            Obrazlozenje.ItemsSource = Enum.GetValues(typeof(VrsteNeradnihDana));
            neradniDaniController = new NeradniDaniController();
            tabelaNeradnihDana = neradniDaniController.DobaviSve();
            foreach (NeradniDani n in tabelaNeradnihDana)
            {
                if (n.doktor.Jmbg == doktor.Jmbg)
                    NeradniDani.Add(n);
            }
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Odobri_neradneDane(object sender, RoutedEventArgs e)
        {
            /*NeradniDani nd = new NeradniDani();
            nd.NeradnoOd = (DateTime)Od.SelectedDate;
            nd.NeradnoDo = (DateTime)Do.SelectedDate;
            nd.Vrsta = (VrsteNeradnihDana)Obrazlozenje.SelectedIndex;
            nd.doktor = dok;
             
            NeradniDaniRepository fajl = new NeradniDaniRepository(@"..\..\..\Fajlovi\NeradniDani.txt");
            List<NeradniDani> ListaDana = fajl.DobaviNeradneDane();
            ListaDana.Add(nd);
            fajl.SacuvajNeradanDan(ListaDana);
            dataGridNeradniDani.ItemsSource = ListaDana;
            //this.Close();*/
            NeradniDani novoOdobrenje = new NeradniDani();
            neradniDaniController = new NeradniDaniController();
            PopunjavanjePoljaZaGodisnjiOdmor(novoOdobrenje);
            if (neradniDaniController.OdobriNeradneDane(novoOdobrenje) == true)
            {
                MessageBox.Show("Doktoru su odobreni neradni dani.");
                this.Close();
            }
        }
        private void PopunjavanjePoljaZaGodisnjiOdmor(NeradniDani novoOdobrenje)
        {
            novoOdobrenje.NeradnoOd = (DateTime)Od.SelectedDate;
            novoOdobrenje.NeradnoDo = (DateTime)Do.SelectedDate;
            novoOdobrenje.Vrsta = (VrsteNeradnihDana)Obrazlozenje.SelectedIndex;
            novoOdobrenje.doktor = dok;
        }
    }
}
