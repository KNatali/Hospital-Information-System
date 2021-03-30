using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.PacijentModel
{
    public class CuvanjePregledaPacijent
    {
        private List<Pregled> pregledi = new List<Pregled>();

        public String LokacijaFajla;

        public CuvanjePregledaPacijent(String lokacija)
        {
            LokacijaFajla = lokacija;
        }

        public CuvanjePregledaPacijent()
        {
            pregledi = new List<Pregled>();
            DateTime pocetak = new DateTime(2020, 10, 25);
            Doktor doktor1 = new Doktor { Ime = "Biljana", Prezime = "Marinkov", Adresa = "Marsala Tita 21", BrojTelefona = "063568845", DatumRodjenja = new DateTime(1990, 10, 12), Email = "nbhvuh", Jmbg = "123" };
            Pacijent pacijent1 = new Pacijent { Ime = "hff", Prezime = "hhhh", Adresa = "hefhfei", BrojTelefona = "4558494184", DatumRodjenja = new DateTime(1986, 11, 1), Email = "hfghf", jmbg = "12555" };
            Pregled pregled1 = new Pregled { Pocetak = pocetak, Trajanje = 30, pacijent = pacijent1, doktor = doktor1 };
            pregledi.Add(pregled1);
        }

        public List<Pregled> DobaviSve()
        {
            pregledi = new List<Pregled>();
            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\Home\Dropbox\My PC (DESKTOP-TI6DNK1)\Desktop\ProjekatSIMSdva\Projekat\ProjekatSIMS\PregledPacijent.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(",");

                    Pregled pregled = new Pregled();
                    pregled.Id = Convert.ToInt32(parts[0]);
                    pregled.Pocetak = Convert.ToDateTime(parts[1]);
                    pregled.Trajanje = Convert.ToInt32(parts[2]);
                    pregledi.Add(pregled);
                }
                file.Close();
            }
            return pregledi;
        }

        public void Sacuvaj(Pregled pregled)
        {
            String linija = "";

            String id = pregled.Id.ToString();
            String pocetak = pregled.Pocetak.ToString();
            String trajanje = pregled.Trajanje.ToString();
            String idPacijenta = pregled.pacijent.jmbg.ToString();
            String idDoktora = pregled.doktor.Jmbg.ToString();


            linija += id + "," + pocetak + "," + trajanje + "," + idPacijenta + "," + idDoktora;
            using StreamWriter file = new StreamWriter(LokacijaFajla);

            file.WriteLineAsync(linija);
        }

        public Pregled DobaviJedan(int id)
        {
            // TODO: implement
            return null;
        }

        public Pacijent DobaviPacijenta()
        {
            // TODO: implement
            return null;
        }



    }
}