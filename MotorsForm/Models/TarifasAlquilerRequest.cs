using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    public class TarifasAlquilerRequest
    {
        public int id_tipo { get; set; }
        public string tipo_auto { get; set; }
        public double tarifaxauto { get; set; }
    }
}
