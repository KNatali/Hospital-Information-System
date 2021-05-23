using Model;
using Repository;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class PregledajZdravstveniKarton : Page

    {
        public List<ZdravsteniKarton> ZdravstveniKarton
        {
            get;
            set;
        }
        public PregledajZdravstveniKarton()
        {
            InitializeComponent();
            this.DataContext = this;
            ZdravstveniKarton = new List<ZdravsteniKarton>();
            ZdravstveniKartonRepository zdravstveniKartonRepository = new ZdravstveniKartonRepository();
            ZdravstveniKarton = zdravstveniKartonRepository.DobaviZdravstveneKartone();
        }
    }
}
