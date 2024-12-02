namespace MotorsApi.Models
{
    public class FlotaAlquilerRequest
    {

        public int cod_alquiler { get; set; }

        public string id_vehiculo { get; set; }

        public double total { get; set; }

        public DateTime f_retiro { get; set; }
        public DateTime f_entrega { get; set; }
    }
}
