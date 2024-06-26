using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models.ViewModels
{
    public class PerformansGostergeVM
    {

        public Kalite_PerformansGostergeTanim_Revizyon PerformansGosterge { get; set; }
        public Kalite_PerformansGostergeHedeflenenDeger HedeflenenDeger { get; set; }
        public Kalite_PerformansGostergeGerceklesenDeger GerceklesenDeger { get; set; }

    }
}
