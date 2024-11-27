using MotorsApi.Models;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotorsApi.BD.CRUD.Read
{
    public class SeguroRead : Conexiondb
    {

        //Muestra la lista de los Seguros de los Autos
        public List<SeguroRequest> obtenerListaSeguros() 
        {
            List<SeguroRequest> lista = new List<SeguroRequest>();

            try
            {
                

                
                cmd.Parameters.Clear();

               
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "SELECT tipo_seguro, precio, descripcion FROM seguros"; 

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        SeguroRequest seguro = new SeguroRequest()
                        {
                            tipo_seguro = reader["tipo_seguro"].ToString(),
                            precio = Convert.ToDouble(reader["precio"]),
                            descripcion = reader["descripcion"].ToString()
                        };
                        
                        lista.Add(seguro);
                    }
                }
            }
            catch (Exception e) { throw; }
            finally { cerrarConexion(); }
            return lista;
        }
    }
}
