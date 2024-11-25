using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class HistorialTransacciones : Conexiondb
    {
        //Esta clase contendra los historial de transacciones para el usuario mandando el id_usuario

        //Transacciones de Alquileres
       
        public List<Flota_AlquilerRequest> obtenerMiAlquiler(int id_usuario)
        {
            //Lista de objetos
            List<Flota_AlquilerRequest> lista = new List<Flota_AlquilerRequest>();

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT cod_alquiler, id_vehiculo, f_retiro, f_entregas FROM Flota_Alquiler WHERE  id_usuario = @id_usuario";

                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flota_AlquilerRequest facturita = new Flota_AlquilerRequest()
                        {
                            id_vehiculo = reader["marca"].ToString(),
                            cod_alquiler = Convert.ToInt32(reader["cod_alquiler"]),
                            f_entrega = Convert.ToDateTime(reader["f_entrega"]),
                            f_retiro = Convert.ToDateTime(reader["f_retiro"])

                        };

                        lista.Add(facturita);
                    };

                }


            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {

                cerrarConexion();

            }
            return lista;




        }
        //Transacciones de Venta


        //Transacciones de Subasta

    }
}
