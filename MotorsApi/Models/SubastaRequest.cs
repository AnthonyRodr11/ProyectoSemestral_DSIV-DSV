namespace MotorsApi.Models
{
    //esta clase es model de Subasta Historial
    public class SubastaRequest
    {
        public int cod_subasta {  get; set; }
        public string id_placa { get; set; }
        public double valor_puja { get; set; }
    }
}
