using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Ver_Flotas : Conexiondb
    {

        //Metodo para devolver una lista segun su estado <Alquiler,venta,Subasta>
        public List<string> tipos_Flota(string estado)
        {
            List<string> autos = new List<string>();
            string data;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT placa, marca, modelo FROM Flota_Carro WHERE estado = @estado";

                // Agregamos el parámetro estado
                cmd.Parameters.AddWithValue("@estado", estado);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Agregamos cada vehiculo a la lista
                        data = $"Placa: {reader["placa"]}, Marca: {reader["marca"]}, Modelo: {reader["modelo"]}";
                        autos.Add(data);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo cargar la lista de autos"+e);
            }
            finally
            {

                cerrarConexion();
            }
            return autos;
        }
    }
}