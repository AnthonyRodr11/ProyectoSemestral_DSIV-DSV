using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    public class CarroFlotaRequest
    {
        //Atributos de la entidad
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public double km { get; set; }
        public string transmision { get; set; }
        public string tipo_gas { get; set; }
        public string carroceria { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public string foto { get; set; }
    }
}
