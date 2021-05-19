using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class NotifikacijaService
   {
        public Repository.NotifikacijaRepository notifikacijaRepository = new NotifikacijaRepository();

        public List<Notifikacija> DobaviSve()
        {
            return notifikacijaRepository.DobaviSve();
        }

    }
}