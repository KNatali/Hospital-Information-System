
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Repository
{
    public class ZdravstveniKartonRepository
    {

        private String putanja = @"..\..\..\Fajlovi\ZdravstveniKarton.txt";
        private List<ZdravsteniKarton> sviKartoni = new List<ZdravsteniKarton>();
        private String LokacijaFajla;

        public ZdravstveniKartonRepository()
        {


        }
        public ZdravstveniKartonRepository(String lokacija)
        {
            //putanja = lokacija;
            LokacijaFajla = lokacija;
        }

        public ZdravsteniKarton DobaviZdravstveniKartonById(int id)
        {
            sviKartoni = DobaviZdravstveneKartone();
            foreach (ZdravsteniKarton z in sviKartoni)
            {
                if (z.Id == id)
                    return z;
            }
            return null;
        }

        public ZdravsteniKarton DobaviZdravstveniKartonZaPacijenta(Pacijent pacijent)
        {
            sviKartoni = DobaviZdravstveneKartone();
            foreach (ZdravsteniKarton z in sviKartoni)
            {
                if (z.IdPacijent == pacijent.Jmbg)
                {
                    MessageBox.Show("Nadjen");
                    return z;
                }
                   
            }
            return null;

        }
        public List<ZdravsteniKarton> DobaviZdravstveneKartone()
        {
            List<ZdravsteniKarton> sviKartoni = new List<ZdravsteniKarton>();
            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                sviKartoni = JsonConvert.DeserializeObject<List<ZdravsteniKarton>>(json);
            }
            return sviKartoni;
        }

        public void SacuvajZdravsteveneKartone(List<ZdravsteniKarton> kartoni)
        {
            string newJson = JsonConvert.SerializeObject(kartoni);
            File.WriteAllText(putanja, newJson);
        }

        public void SacuvajNoviKarton(ZdravsteniKarton karton)
        {
            List<ZdravsteniKarton> kartoni = new List<ZdravsteniKarton>();
            if (DobaviZdravstveneKartone() == null)
                kartoni = new List<ZdravsteniKarton>();
            else
                kartoni = DobaviZdravstveneKartone();

            kartoni.Add(karton);
            SacuvajZdravsteveneKartone(kartoni);
        }

        public void AzurirajKarton(ZdravsteniKarton zdravstveniKarton)
        {
            sviKartoni = DobaviZdravstveneKartone();
            foreach (ZdravsteniKarton z in sviKartoni)
            {
                if (z.IdPacijent == zdravstveniKarton.IdPacijent)
                {
                    z.Recepti = zdravstveniKarton.Recepti;
                    z.Alergeni = zdravstveniKarton.Alergeni;
                    z.anamneza = zdravstveniKarton.anamneza;
                    z.UputiZaBolnickoLijecenje = zdravstveniKarton.UputiZaBolnickoLijecenje;
                }
                   
               

            }
            SacuvajZdravsteveneKartone(sviKartoni);
        }
        public void SacuvajAlergen(List<string> alergeni)
        {
            string newJson = JsonConvert.SerializeObject(alergeni);
            File.WriteAllText(putanja, newJson);
        }

    }
}
