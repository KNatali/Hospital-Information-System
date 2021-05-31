using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class VerifikovanjeLijekovaController
    {
        private VerifikovanjeLijekovaService verifikovanjeLijekovaService = new VerifikovanjeLijekovaService();

        public void OdobriLijek(Lijek lijek)
        {
            verifikovanjeLijekovaService.OdobriLijek(lijek);
        }

        public void OdbaciLijek(Lijek lijek,String poruka)
        {
            verifikovanjeLijekovaService.OdbaciLijek(lijek, poruka);
        }
    }
}
