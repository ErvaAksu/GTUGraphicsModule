using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Models.Models
{
    public class Kalite_Birim
    {
        [Key]
        public int Id { get; set; }

        public string BirimAdi { get; set; }

    }
}
