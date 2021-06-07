using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.UputiPacijent
{
    public class UputBolnickoLecenjeController
    {
        public UputBolnickoLijecenjeRepository uputBolnickoLijecenjeRepository = new UputBolnickoLijecenjeRepository();
        public List<UputBolnickoLijecenje> DobaviSveUpute()
        {
            return uputBolnickoLijecenjeRepository.DobaviSveUpute();
        }
    }
}
