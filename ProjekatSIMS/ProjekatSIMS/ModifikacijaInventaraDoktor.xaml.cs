using Model;
using ProjekatSIMS.DTO;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{
    public partial class ModifikacijaInventaraDoktor : Page
    {

        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private InventarRepository inventarRepository = new InventarRepository();
        private List<ModifikacijaInventaraDTO> Modifikacija { get; set; }
        private List<Prostorija> Sale { get; set; }
        private Prostorija SelectedSala { get; set; }
        private List<ModifikacijaInventaraDTO> modifikacije;

        private Inventar SelectedInventar { get; set; }
        public ModifikacijaInventaraDTO SelectedModifikacija { get; set; }

        public ModifikacijaInventaraDoktor()
        {
            InitializeComponent();
            this.DataContext = this;
            modifikacije = new List<ModifikacijaInventaraDTO>();
            Sala.ItemsSource = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Sala);
            Prikaz();


        }

        public void Prikaz()
        {

            Tabela.ItemsSource = null;

            Tabela.ItemsSource = modifikacije;
        }



        private void InventarProstorije(object sender, RoutedEventArgs e)
        {
            Prostorija p = (Prostorija)Sala.SelectedItem;
            List<Inventar> inv = inventarRepository.DobaviInventarIzProstorije(p.id);
            if (inv != null)
                Inventar.ItemsSource = inv;


        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            PocetnaStranicaDoktorViewModel p = new PocetnaStranicaDoktorViewModel(this.NavigationService);
            PocetnaStranicaDoktorView pocetna = new PocetnaStranicaDoktorView(p);
            this.NavigationService.Navigate(pocetna);


        }

        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            SelectedSala = (Prostorija)Sala.SelectedItem;
            SelectedInventar = (Inventar)Inventar.SelectedItem;
            int kolicina = Convert.ToInt32(Kolicina.Text);

            if (SelectedSala == null || SelectedInventar == null)
                MessageBox.Show("Morate izabrati lijek i inventar da bi dodali u listu");
            else
            {
                ModifikacijaInventaraDTO mod = new ModifikacijaInventaraDTO(SelectedSala.id, SelectedInventar.ime, kolicina);
                modifikacije.Add(mod);
                Prikaz();
            }

        }

        private void UkloniInventar(object sender, RoutedEventArgs e)
        {
            SelectedModifikacija = (ModifikacijaInventaraDTO)Tabela.SelectedItem;

            modifikacije.Remove(SelectedModifikacija);
            Prikaz();


        }
    }
}
