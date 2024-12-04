using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsForm.Models
{
    public class Ventas
    {
        //Atributos de la clase ventas
        public int? venta_id {  get; set; }
        public int id_cliente { get; set; }
        public string id_vehiculo { get; set; }
        public DateTime? f_compra {  get; set; }
        public double total { get; set; }
    }
}
