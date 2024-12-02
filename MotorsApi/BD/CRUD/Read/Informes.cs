using System.Data;
using MotorsApi.Models;
using System.Numerics;
using MySql.Data.MySqlClient;
namespace MotorsApi.BD.CRUD.Read
{
    public class Informes : Conexiondb
    {
        //Metodo para retornar la data para el  archivo .txt con informe de flota
        public string[] infoFlota()
        {
            List<string> data = new List<string>();

            try
            {
                
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT placa,marca,modelo,color,km,transmision,tipo_gas,carroceria FROM Flota_Carro";

                
                abrirConexion();

               
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        string row = string.Join(";",
                            reader["placa"].ToString(),
                            reader["marca"].ToString(),
                            reader["modelo"].ToString(),
                            reader["color"].ToString(),
                            reader["km"].ToString(),
                            reader["transmision"].ToString(),
                            reader["tipo_gas"].ToString(),
                            reader["carroceria"].ToString()
                        );

                      
                        data.Add(row);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }
        
        //Metodo que guarda registros de la tabla ventas
        public async Task<string[]> infoVentas()
        {
            List<string> data = new List<string>();

            try
            {
                
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.CommandText = "ObtenerInfoVentas";

                
                abrirConexion();

               
                using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        
                        string row = string.Join(";",
                            reader["ID_Venta"]?.ToString() ?? "N/A",    // Usamos "N/A" o un valor por defecto en caso de nulos
                            reader["Nombre_Cliente"]?.ToString() ?? "Desconocido",
                            reader["Fecha_Compra"]?.ToString() ?? "Sin Fecha",
                            reader["Placa"]?.ToString() ?? "Desconocida",
                            reader["Total"]?.ToString() ?? "0.00"
                        );

                        
                        data.Add(row);
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

            return data.ToArray();

        }

        //Metodo que guarda registros de la tabla Alquiler
        public string[] infoAlquiler()
        {
            List<string> data = new List<string>();

            try
            {
                
                cmd.Parameters.Clear();

              
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT    cod_alquiler,    id_vehiculo,   id_usuario,    tipo_tarifa,    f_retiro,   f_entrega,    total   FROM     Flota_Alquiler;";

               
                abrirConexion();

               
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                            reader["cod_alquiler"].ToString(),
                            reader["id_vehiculo"].ToString(),
                            reader["id_usuario"].ToString(),
                            reader["tipo_tarifa"].ToString(),
                            reader["f_retiro"].ToString(),
                            reader["f_entrega"].ToString(),
                            reader["total"].ToString()

                        );

                        
                        data.Add(row);
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

            return data.ToArray();

        }

        //Metodo que guarda registro e de la tabla subasta 
        public string[] infoSubastas()
        {
            List<string> data = new List<string>();

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_obtenerSubastas";

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                      
                        string row = string.Join(";",
                           reader["cod_subasta"].ToString(),
                           reader["valor_inicial"].ToString(),
                           reader["id_placa"].ToString(),
                           reader["valor_puja"].ToString(),
                           reader["id_usuario"].ToString(),
                           reader["nombre"].ToString(),
                           reader["apellido"].ToString(),
                           reader["estado"].ToString(),
                           reader["t_inicio"].ToString(),
                           reader["t_final"].ToString()
                        );

                        data.Add(row);
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

            return data.ToArray();
        }




        //Este metodo Guarda todos los registros de la tabla solicitud 
        public string[] infoSolicitudes()
        {
            List<string> data = new List<string>();

            try
            {
                
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.CommandText = "sp_obtener_solicitudes";

                
                abrirConexion();

                
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                              reader["id_solicitud"].ToString(),  
                              reader["nombre_cliente"].ToString(), 
                              reader["estado"].ToString(),         
                              reader["f_solicitud"].ToString(),    
                              reader["monto"].ToString()

                        );

                        
                        data.Add(row);
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

            return data.ToArray();

        }














    }

}
