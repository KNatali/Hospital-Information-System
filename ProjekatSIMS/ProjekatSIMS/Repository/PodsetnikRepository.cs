using Newtonsoft.Json;
using ProjekatSIMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjekatSIMS.Repository
{
   public class PodsetnikRepository
    {
        private const string putanja = @"..\..\..\Fajlovi\Podsetnik.txt";
        private string v;

        public PodsetnikRepository(string v)
        {
            this.v = v;
        }

        public PodsetnikRepository()
        {
        }

        public void SacuvajPodsetnik(List<Podsetnik> podsetnici)
        {
            string newJson = JsonConvert.SerializeObject(podsetnici);
            File.WriteAllText(putanja, newJson);
        }


        public List<Podsetnik> DobaviSvePodsetnikeZaJmbg(String jmbg)
        {

            List<Podsetnik> podsetnici = new List<Podsetnik>();
            List<Podsetnik> podsetniciZaPacijenta = new List<Podsetnik>();

            using (StreamReader r = new StreamReader(putanja))
            {
                string json = r.ReadToEnd();
                podsetnici = JsonConvert.DeserializeObject<List<Podsetnik>>(json);
            }
            foreach (Podsetnik pod in podsetnici)
            {
                if (pod.pacijent == jmbg)
                {
                    podsetniciZaPacijenta.Add(pod);
                }
            }

            return podsetniciZaPacijenta;
        }

        public List<Podsetnik> DobaviSvePodsetnike()
        {
            List<Podsetnik> podsetnici = new List<Podsetnik>();
            using (StreamReader sr = new StreamReader(putanja))
            {
                string json = sr.ReadToEnd();

                podsetnici = JsonConvert.DeserializeObject<List<Podsetnik>>(json);
            }
            return podsetnici;
        }
    }
}
