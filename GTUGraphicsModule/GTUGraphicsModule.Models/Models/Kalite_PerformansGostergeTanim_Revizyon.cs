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
    public class Kalite_PerformansGostergeTanim_Revizyon
    {

        [ForeignKey(nameof(Kalite_PerformansGostergeTanim))]
        public int performans_gosterge_tanim_id { get; set; }

        public string kod { get; set; }
        public string eski_kod { get; set; }
        public int revizyon_numarasi { get; set; }
        public string ad { get; set; }
        public string ad_ingilizce { get; set; }
        public string tanim { get; set; }
        public int olcu_birim_cesit { get; set; }
        public int formul_cesit { get; set; }
        public int izleme_periyot_cesit { get; set; }
        public int genel_gosterge_formul_cesit { get; set; }
        public bool aktif { get; set; }
        public int strateji_id { get; set; }
        public int baslangic_ticks { get; set; }
        public int bitis_ticks { get; set; }
        public int _silinecek_gosterge_cesit { get; set; }
        public int _silinecek_sonuc_kriter_cesit { get; set; }
        public int _silinecek_formul_cesit { get; set; }
        public int _silinecek_genel_gosterge_formul_cesit { get; set; }

        [Key]
        public int _ef_gereksinimi_icin_id { get; set; }
        public virtual Kalite_PerformansGostergeTanim? Kalite_PerformansGostergeTanim { get; set; }

        public virtual Kalite_PerformansGostergeHedeflenenDeger? Kalite_PerformansGostergeHedeflenenDeger { get; set; }


    }
}
