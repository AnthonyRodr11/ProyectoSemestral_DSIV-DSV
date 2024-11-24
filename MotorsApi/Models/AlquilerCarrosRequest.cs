namespace MotorsApi.Models
{
    public class AlquilerCarrosRequest
    {
        public string placa { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public string foto { set; get; }
        public int tipoTarifa { set; get; }
        public double tarifa { set; get; }

    }
}
