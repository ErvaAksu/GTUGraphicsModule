using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models
{
    public class Kalite_PerformansGostergeBirimIliski
    {
        [ForeignKey(nameof(Kalite_PerformansGostergeTanim))]
        public int performans_gosterge_id { get; set; }

        [ForeignKey(nameof(Kalite_Birim))]
        public int birim_id { get; set; }
        public int baslangic_ticks { get; set; }
        public int bitis_ticks { get; set; }

        [Key]
        public int ef_gereksinimi_icin_id { get; set; }

        public virtual Kalite_PerformansGostergeTanim? Kalite_PerformansGostergeTanim { get; set; }

        public virtual Kalite_Birim? Kalite_Birim { get; set; }

    }
}
