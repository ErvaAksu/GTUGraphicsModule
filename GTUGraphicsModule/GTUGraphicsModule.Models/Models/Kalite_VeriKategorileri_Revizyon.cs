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
    public class Kalite_VeriKategorileri_Revizyon
    {
        public int veri_kategorisi_id { get; set; }

        [ForeignKey(nameof(Kalite_VeriKategorileri))]
        public int ust_veri_kategorisi_id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        public string aciklama { get; set; }
        public int baslangic_ticks { get; set; }
        public int bitis_ticks { get; set; }

        [Key]
        public int ef_gereksininmi_icin_id { get; set; }

        public virtual Kalite_VeriKategorileri? Kalite_VeriKategorileri { get; set; }


    }
}
