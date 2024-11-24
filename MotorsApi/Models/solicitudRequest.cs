namespace MotorsApi.Models
{
    public class solicitudRequest
    {
        //Atributos 
        public int id_usuario { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public double monto { get; set; }
    }
}