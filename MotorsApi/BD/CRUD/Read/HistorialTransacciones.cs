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

                            cod_alquiler = reader.GetInt32(0),
                            id_vehiculo = reader.GetString(1),
                            f_retiro = reader.GetDateTime(2),
                           f_entrega = reader.GetDateTime(3)

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
        public List<Flota_Venta> obtenerMisCompras(int id_usario)
        {
            
            //lista de objetos
            List<Flota_Venta> misCompras = new List<Flota_Venta>();

            try
            {   
                //limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo consulta
                cmd.CommandType = CommandType.Text;

                //asignamos codigo
                cmd.CommandText = "SELECT venta_id, id_vehiculo, f_compra, total FROM Ventas WHERE id_cliente = @id_usuario";

                cmd.Parameters.Add(new MySqlParameter("@id_usario", id_usario));

                //abrimos conexion
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        Flota_Venta compre = new Flota_Venta()
                        {
                            cod_venta = reader.GetInt32(0),
                            placa = reader.GetString(1),
                            f_compra = reader.GetDateTime(2),
                            precio = reader.GetDouble(3),

                        };

                        misCompras.Add(compre);
                    }
                }
            }
            catch (Exception e)
            {
                throw;

            }
            finally { 
                
                cerrarConexion();
            }

            return misCompras;
        }

        //Transacciones de Subasta
        public List<SubastaRequest> obtenerMisSubastas(int id_usuario)
        {

        }
    }
}
