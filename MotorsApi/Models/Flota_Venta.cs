﻿namespace MotorsApi.Models
{
    public class Flota_Venta
    {
        //Atributos de la entidad
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public string placa { get; set; }
        public double precio { get; set; }
      
    }
}
