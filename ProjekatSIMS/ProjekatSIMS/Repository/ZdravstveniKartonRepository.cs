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

        public ZdravstveniKartonRepository()
        {


        }

        public ZdravsteniKarton DobaviZdravstveniKartonZaPacijenta(Pacijent pacijent)
        {
            sviKartoni = DobaviZdravstveneKartone();
            foreach (ZdravsteniKarton z in sviKartoni)
            {
                if (z.pacijent.Jmbg == pacijent.Jmbg)
                    return z;
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
                if (z.pacijent.Jmbg == zdravstveniKarton.pacijent.Jmbg)
                {
                    z.Recepti = zdravstveniKarton.Recepti;
                    z.Alergeni = zdravstveniKarton.Alergeni;
                    z.anamneza = zdravstveniKarton.anamneza;
                    z.Terapija = zdravstveniKarton.Terapija;
                    z.UputiZaBolnickoLijecenje = zdravstveniKarton.UputiZaBolnickoLijecenje;
                }
                   
               

            }
            SacuvajZdravsteveneKartone(sviKartoni);
        }


    }
}
