using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    public class SubastaRequest
    {
        public string id_placa { get; set; }
        public double valor_inicial {  get; set; }
        public DateTime t_inicio { get; set; }
        public DateTime t_final { get; set; }
    }
}
