using Model;
using ProjekatSIMS.Service;
using ProjekatSIMS.Service.PreglediPacijent;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Controller.PregledPacijent
{
    public class ZakazivanjePregledaController
    {
        public ZakazivanjePregledaService zakazivanjePregledaService = new ZakazivanjePregledaService();
        public ZauzetiTerminiService zauzetiTermini = new ZauzetiTerminiService();
        public PregledRepository pregledRepository = new PregledRepository();
        public Boolean ZakazivanjePregledaPacijent(String imeDoktora, String prezimeDoktora, DateTime datum, Pacijent pac)
        {

            if (zakazivanjePregledaService.ZakazivanjePregledaPacijent(imeDoktora, prezimeDoktora, datum, pac))
                return true;

            return false;

        }

        public Boolean DaLiJeTerminZauzet(DateTime datum)
        {
            if (zauzetiTermini.DaLiJeTerminZauzet(datum))
            {
                return true;
            }
            return false;
        }

        public List<Pregled> DobaviPregledeZaPacijenta(Pacijent pacijent)
        {
            return pregledRepository.DobaviPregledeZaPacijenta(pacijent);
        }


    }

}
