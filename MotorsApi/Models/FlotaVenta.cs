namespace MotorsApi.Models
{
    public class FlotaVenta
    {
        //Atributos de la entidad
        public int cod_venta { get; set; }
        public int id_cliente {  get; set; }
        public string placa { get; set; }
        public DateTime f_compra {  get; set; }
        public double precio { get; set; }
      
    }
}
