using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    public class Solicitud
    {
        public int id_solicitud { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string estado { get; set; }
        public DateTime f_solicitud { get; set; }
        public double monto { get; set; }
    }
}
