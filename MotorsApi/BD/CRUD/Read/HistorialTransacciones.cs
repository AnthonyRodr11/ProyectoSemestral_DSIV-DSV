using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class HistorialTransacciones : Conexiondb
    {
        //Esta clase contendra los historial de transacciones para el usuario mandando el id_usuario

        //Transacciones de Alquileres
       
        public List<FlotaAlquilerRequest> obtenerMiAlquiler(int id_usuario)
        {
            //Lista de objetos
            List<FlotaAlquilerRequest> lista = new List<FlotaAlquilerRequest>();

            try
            {
               
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT cod_alquiler, id_vehiculo, total, f_retiro, f_entrega FROM Flota_Alquiler WHERE  id_usuario = @id_usuario";

                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FlotaAlquilerRequest facturita = new FlotaAlquilerRequest()
                        {

                            
                              cod_alquiler = reader.GetInt32(0),
                              id_vehiculo = reader.GetString(1),
                              total = reader.GetDouble(2),
                              f_retiro = reader.GetDateTime(3),
                              f_entrega = reader.GetDateTime(4)

                           

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
        public List<FlotaVenta> obtenerMisCompras(int id_usuario)
        {
            
            //lista de objetos
            List<FlotaVenta> misCompras = new List<FlotaVenta>();

            try
            {   
               
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = "SELECT venta_id, id_vehiculo, f_compra, total FROM Ventas WHERE id_cliente = @id_usuario";

                cmd.Parameters.Add(new MySqlParameter("@id_usuario", id_usuario));

                
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        FlotaVenta compre = new FlotaVenta()
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
           
            List<SubastaRequest> misSubastas = new List<SubastaRequest>();

            try
            {
                
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT cod_subasta, id_placa, valor_puja FROM Flota_Subasta WHERE id_usuario = @id_usuario";

                cmd.Parameters.Add(new MySqlParameter("@id_usuario", id_usuario));

                
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        SubastaRequest subasta = new SubastaRequest()
                        {

                            cod_subasta = Convert.ToInt32(reader["cod_subasta"]),
                            id_placa = reader["id_placa"].ToString(),
                            valor_puja = Convert.ToDouble(reader["valor_puja"])
                        };

                        misSubastas.Add(subasta);
                    }
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

            return misSubastas;
        }
    }
}
