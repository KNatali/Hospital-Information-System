using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Model;

namespace ProjekatSIMS.ViewModelSekretar
{
    public class ProfilDoktoraViewModel : BindableBase
    {
        private Doktor doktor;
        private Window thisWindow;
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public Specijalizacija Oblasti { get; set; }
        public string RadnoOd { get; set; }
        public string RadnoDo { get; set; }
        public ProfilDoktoraViewModel()
        {

        }
        public ProfilDoktoraViewModel(Doktor doktor, Window thisWindow)
        {
            this.doktor = doktor;
            this.thisWindow = thisWindow;
            PrikaziPodatke();
        }
        private void PrikaziPodatke()
        {
            Ime = doktor.Ime;
            Prezime = doktor.Prezime;
            BrojTelefona = doktor.BrojTelefona;
            Adresa = doktor.Adresa;
            Jmbg = doktor.Jmbg;
            DatumRodjenja = doktor.DatumRodjenja;
            Mail = doktor.Email;
            Oblasti = doktor.Specijalizacija;
            RadnoOd = doktor.PocetakRadnogVremena;
            RadnoDo = doktor.KrajRadnogVremena;
        }
    }
}
