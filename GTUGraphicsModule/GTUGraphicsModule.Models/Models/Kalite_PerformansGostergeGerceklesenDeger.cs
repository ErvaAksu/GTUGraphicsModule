using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models
{
    public class Kalite_PerformansGostergeGerceklesenDeger
    {

        public int performans_gosterge_id { get; set; }

        public int surec_id { get; set; }

        public int faaliyet_donem_id { get; set; }

        public int periyod { get; set; }

        public int gerceklesen_deger { get; set; }


        public virtual Kalite_PerformansGostergeHedeflenenDeger? Kalite_PerformansGostergeHedeflenenDeger { get; set; }
    }

}
