using Model.DoktorModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class Pacijent
    {
        public Boolean IzmeniInformacije(String i, String p, String m, String t, String a, String j, DateTime d)
        {
            string linija;
            List<String> linije = new List<string>();
            using (StreamReader fajl = new StreamReader(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt"))
            {
                while ((linija = fajl.ReadLine()) != null)
                {
                    string[] deo = linija.Split(",");
                    if (deo[5] == this.Jmbg.ToString())
                    {
                        deo[0] = i.ToString();
                        deo[1] = p.ToString();
                        deo[2] = m.ToString();
                        deo[3] = t.ToString();
                        deo[4] = a.ToString();
                        deo[5] = j.ToString();
                        deo[6] = d.ToString();
                        linija = deo[0] + "," + deo[1] + "," + deo[2] + "," + deo[3] + "," + deo[4] + "," + deo[5] + "," + deo[6];
                    }
                    linije.Add(linija);
                }
                fajl.Close();
            }
            File.WriteAllLinesAsync(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt", linije);
            return true;
        }

        public Boolean ObrisiPacijent()
        {
            string linija;
            List<String> linije = new List<string>();
            using (StreamReader fajl = new StreamReader(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt"))
            {
                while ((linija = fajl.ReadLine()) != null)
                {
                    string[] deo = linija.Split(",");
                    if (deo[5] != this.Jmbg.ToString())
                    {
                        linije.Add(linija);
                    }
                }
                fajl.Close();
            }
            File.WriteAllLinesAsync(@"C:\Users\mrvic\Projekat\ProjekatSIMS\Pacijent.txt", linije);
            return true;
        }

        public String Jmbg { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String BrojTelefona { get; set; }
        public String Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String Adresa { get; set; }

        public RegistrovaniKorisnik registrovaniKorisnik;
        public System.Collections.ArrayList pregled;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetPregled()
        {
            if (pregled == null)
                pregled = new System.Collections.ArrayList();
            return pregled;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetPregled(System.Collections.ArrayList newPregled)
        {
            RemoveAllPregled();
            foreach (Pregled oPregled in newPregled)
                AddPregled(oPregled);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddPregled(Pregled newPregled)
        {
            if (newPregled == null)
                return;
            if (this.pregled == null)
                this.pregled = new System.Collections.ArrayList();
            if (!this.pregled.Contains(newPregled))
            {
                this.pregled.Add(newPregled);
                newPregled.SetPacijent(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovePregled(Pregled oldPregled)
        {
            if (oldPregled == null)
                return;
            if (this.pregled != null)
                if (this.pregled.Contains(oldPregled))
                {
                    this.pregled.Remove(oldPregled);
                    oldPregled.SetPacijent((Model.Pacijent)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllPregled()
        {
            if (pregled != null)
            {
                System.Collections.ArrayList tmpPregled = new System.Collections.ArrayList();
                foreach (Pregled oldPregled in pregled)
                    tmpPregled.Add(oldPregled);
                pregled.Clear();
                foreach (Pregled oldPregled in tmpPregled)
                    oldPregled.SetPacijent((Model.Pacijent)null);
                tmpPregled.Clear();
            }
        }

    }
}