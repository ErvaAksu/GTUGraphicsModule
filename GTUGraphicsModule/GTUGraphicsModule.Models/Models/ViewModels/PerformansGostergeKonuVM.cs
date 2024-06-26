using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models.ViewModels
{
    public class PerformansGostergeKonuVM
    {

        public Kalite_PerformansGostergeTanim PerformansGostergeTanim { get; set; }
        public Kalite_VeriKategorileri_Revizyon VeriKategorisi { get; set; }
        public IList<Kalite_PerformansGostergeTanim_Revizyon> PerformansGostergeleri { get; set; }

        public Kalite_Konu Konu { get; set; }

    }
}