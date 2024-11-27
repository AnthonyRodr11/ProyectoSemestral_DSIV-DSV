namespace MotorsApi.Models
{
    //Este modelo fue necesario para no enviar todos los datos de la Flota de Carros
    public class UpdateState
    {
        public string? placa { get; set; }
        public string? estado { get; set; }
        public bool? disponibilidad { get; set; }
    }
}
