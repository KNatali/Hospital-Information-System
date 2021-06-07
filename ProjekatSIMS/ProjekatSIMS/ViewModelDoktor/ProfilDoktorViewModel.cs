using Model;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class ProfilDoktorViewModel:BindableBase
    {

        private DoktorRepository doktorRepository = new DoktorRepository();
        private NavigationService navService;
        private Doktor doktor;
        private RelayCommand zahtjevZaOdmor;
       

        public RelayCommand ZahtjevZaOdmor
        {
            get { return zahtjevZaOdmor; }
            set
            {
                zahtjevZaOdmor = value;
            }
        }

        public void Executed_ZahtjevZaOdmor()
        {
            ZahtjevZaGodisnjiOdmor zahtjev = new ZahtjevZaGodisnjiOdmor();
            this.navService.Navigate(zahtjev);
        }
        private String jmbg;
         private String ime;
         private String prezime;
         private DateTime datumRodjenja;
         private String adresa;
         private String email;
         private String brojTelefona;
         private int brojSlobodnihDana;


         public NavigationService NavService
         {
             get { return navService; }
             set
             {
                 navService = value;
             }
         }
         public string Jmbg
         {
             get { return jmbg; }
             set
             {
                 if (jmbg != value)
                 {
                     jmbg = value;
                     OnPropertyChanged("Jmbg");
                 }
             }
         }

         public string Ime
         {
             get { return ime; }
             set
             {
                 if (ime != value)
                 {
                     ime = value;
                     OnPropertyChanged("Ime");
                 }
             }
         }

         public string Prezime
         {
             get { return prezime; }
             set
             {
                 if (prezime != value)
                 {
                     prezime = value;
                     OnPropertyChanged("Prezime");
                 }
             }
         }

         public string Adresa
         {
             get { return adresa; }
             set
             {
                 if (adresa != value)
                 {
                     adresa = value;
                     OnPropertyChanged("Adresa");
                 }
             }
         }

         public string Email
         {
             get { return email; }
             set
             {
                 if (email != value)
                 {
                     email = value;
                     OnPropertyChanged("Email");
                 }
             }
         }

         public String BrojTelefona
         {
             get { return brojTelefona; }
             set
             {
                 if (brojTelefona != value)
                 {
                     brojTelefona = value;
                     OnPropertyChanged("BrojTelefona");
                 }
             }
         }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                if (datumRodjenja != value)
                {
                    datumRodjenja = value;
                    OnPropertyChanged("DatumRodjenja");
                }
            }
        }
        public int BrojSlobodnihDana
         {
             get { return brojSlobodnihDana; }
             set
             {
                 if (brojSlobodnihDana != value)
                 {
                     brojSlobodnihDana = value;
                     OnPropertyChanged("BrojSlobodnihDana");
                 }
             }
         }
        

        public void Prikazi()
        {
            Doktor dr = doktorRepository.DobaviByRegistracija(UlogovaniKorisnik.KorisnickoIme, UlogovaniKorisnik.Lozinka);

            Jmbg = dr.Jmbg;
            Ime = dr.Ime;
            Prezime = dr.Prezime;
            Adresa = dr.Adresa;
            BrojTelefona = dr.BrojTelefona;
            DatumRodjenja = dr.DatumRodjenja;
            BrojSlobodnihDana = dr.BrojSlobodnihDana;
            Email = dr.Email;
        }




        public ProfilDoktorViewModel(NavigationService service)
        {
            this.navService = service;
            Prikazi();
            this.ZahtjevZaOdmor = new RelayCommand(Executed_ZahtjevZaOdmor);
            

        }
    }
}
