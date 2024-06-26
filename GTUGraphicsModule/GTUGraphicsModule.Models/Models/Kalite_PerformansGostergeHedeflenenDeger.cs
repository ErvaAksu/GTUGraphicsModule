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
    public class Kalite_PerformansGostergeHedeflenenDeger
    {

        [ForeignKey(nameof(Kalite_PerformansGostergeTanim_Revizyon))]
        public int performans_gosterge_id { get; set; }

        public int surec_id { get; set; }

        public int faaliyet_donem_id { get; set; }

        public int hedeflenen_deger { get; set; }

        public virtual Kalite_PerformansGostergeTanim_Revizyon? Kalite_PerformansGostergeTanim_Revizyon { get; set; }

        public virtual ICollection<Kalite_PerformansGostergeGerceklesenDeger>? Kalite_PerformansGostergeGerceklesenDeger { get; set; }
    }
}
