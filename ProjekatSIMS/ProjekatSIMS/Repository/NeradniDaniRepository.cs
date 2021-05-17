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
        public NeradniDaniRepository(String l)
        {
            lokacija = l;
        }
        public List<NeradniDani> DobaviNeradneDane()
        {
            using (StreamReader r = new StreamReader(lokacija))
            {
                string json = r.ReadToEnd();
                nd = JsonConvert.DeserializeObject<List<NeradniDani>>(json);
            }
            return nd;
        }
        public void SacuvajNeradanDan(List<NeradniDani> neradni)
        {
            string newJson = JsonConvert.SerializeObject(neradni);
            File.WriteAllText(lokacija, newJson);
        }
    }
}
