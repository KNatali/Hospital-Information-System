using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class ProfilDoktorViewModel:BindableBase
    {
        private NavigationService navService;
        private Doktor doktor;
        public Doktor Doktor
        {
            get { return doktor; }
            set
            {
                if (doktor != value)
                {
                    doktor = value;
                    OnPropertyChanged("Doktor");
                }
            }
        }
        /* private String jmbg;
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
        */




        public ProfilDoktorViewModel(NavigationService service,Doktor doktor)
        {
            this.navService = service;
            this.Doktor = doktor;
            

        }
    }
}
