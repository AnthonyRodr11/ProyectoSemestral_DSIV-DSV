using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    internal class RegistroRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string identificacion { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public int rol { get; set; }
        public string correo { get; set; }
    }
}
