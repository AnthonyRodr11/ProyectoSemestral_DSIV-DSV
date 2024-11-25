using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotorsApi.BD.CRUD.Read
{
    public class HistorialTransacciones : Conexiondb
    {
        //Esta clase contendra los historial de transacciones para el usuario mandando el id_usuario

        //Transacciones de Alquileres
        public List<Flota_AlquilerRequest> obtenerMisAlquileres(int id_usario)
        {

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
