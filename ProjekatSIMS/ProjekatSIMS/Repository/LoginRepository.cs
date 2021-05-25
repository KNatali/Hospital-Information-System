using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
    public class LoginRepository
    {
        private String lokacija = @"..\..\..\Fajlovi\RegistrovaniKorisnici.txt";
        private List<RegistrovaniKorisnik> registrovaniKorisnici = new List<RegistrovaniKorisnik>();
        public void SacuvajRegistrovanogKorisnika(List<RegistrovaniKorisnik> registrovani)
        {
            string newJson = JsonConvert.SerializeObject(registrovani);
            File.WriteAllText(lokacija, newJson);
        }

        public List<RegistrovaniKorisnik> DobaviSveRegistrovaneKorisnike()
        {
            using (StreamReader sr = new StreamReader(lokacija))
            {
                string json = sr.ReadToEnd();

                registrovaniKorisnici = JsonConvert.DeserializeObject<List<RegistrovaniKorisnik>>(json);
            }
            return registrovaniKorisnici;
        }
    }
}
