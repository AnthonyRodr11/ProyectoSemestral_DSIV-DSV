namespace MotorsApi.Models
{
    public class SolicitudRequest
    {
        //Atributos 
        public int id_usuario { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public DateTime f_solicitud { get; set; }
        public double monto { get; set; }
    }
}