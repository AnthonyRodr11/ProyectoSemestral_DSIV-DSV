namespace MotorsApi.Models
{
    //esta clase es model de Subasta Historial
    public class SubastaRequest
    {
        public int? cod_subasta {  get; set; }
        public string? id_placa { get; set; }
        public double? valor_puja { get; set; }
        public int? usuario { set; get; }
        public string? estado { set; get; }
    }
}
