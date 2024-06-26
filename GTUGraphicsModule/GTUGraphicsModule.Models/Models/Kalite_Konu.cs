using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models
{
    public class Kalite_Konu
    {
        [Key]
        public int Id { get; set; }

        public string KonuAdi { get; set; }

    }
}
