using System;
using Model;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Repository
{
    public class NeradniDaniRepository
    {
        private String lokacija;
        private List<NeradniDani> nd;
        public NeradniDaniRepository()
        {

        }
        public NeradniDaniRepository(String l)
        {
            lokacija = l;
        }
        public List<NeradniDani> DobaviNeradneDane()
        {
            List<NeradniDani> neradniDani = new List<NeradniDani>();
            using (StreamReader r = new StreamReader(@"..\..\..\Fajlovi\NeradniDani.txt"))
            {
                string json = r.ReadToEnd();
                neradniDani = JsonConvert.DeserializeObject<List<NeradniDani>>(json);
            }
            return neradniDani;
        }
        public void SacuvajNeradanDan(List<NeradniDani> neradni)
        {
            string newJson = JsonConvert.SerializeObject(neradni);
            File.WriteAllText(lokacija, newJson);
        }
    }
}
