
namespace MotorsApi.Models
{
    public class FlotaSubastaRequest
    {
        public int cod_subasta { get; set; }
        public double valor_inicial { get; set; }
        public double valor_puja { get; set; }
        public DateTime t_final { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public double km {  get; set; }
        public string transmision { get; set; }
        public string tipo_gas { get; set; }
        public string carroceria { get; set; }
        public string foto { get; set; }

    }
}
