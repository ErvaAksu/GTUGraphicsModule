using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models.ViewModels
{
    public class PerformansGostergeVeriKategorisiBirimVM
    {

        public IList<PerformansGostergeVeriKategorisiVM> PerformansGostergeVeriKategorisiVMList { get; set; }

        public IList<Kalite_Birim> Birimler { get; set; }

        public IList<Kalite_Konu> Konular { get; set; }

    }
}
