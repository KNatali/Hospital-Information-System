using Model;
using Service;

namespace Controller
{
    public class OtkazivanjePregledaDoktorController
    {
        private OtkazivanjePregledaDoktorService otkazivanjePregledaDoktorService = new OtkazivanjePregledaDoktorService();
        public void OtkazivanjePregleda(Pregled pregled)
        {
            otkazivanjePregledaDoktorService.OtkazivanjePregleda(pregled);
        }
    }
}
