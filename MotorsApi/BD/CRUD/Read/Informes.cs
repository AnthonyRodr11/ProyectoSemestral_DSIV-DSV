using System.Data;
using MySql.Data.MySqlClient;
namespace MotorsApi.BD.CRUD.Read
{
    public class Informes : Conexiondb
    {
        //Metodo para retornar la data para el  archivo .txt coon informe de flota
        public string[] infoFlota()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT placa,marca,modelo,color,km,transmision,tipo_gas,carroceria FROM Flota_Carro";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
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

                        // Añadimos la fila a la lista
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
        public string[] infoVentas()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT v.venta_id AS ID_Venta,  c.nombre AS Nombre_Cliente,    v.f_compra AS Fecha_Compra,   v.placa AS Placa,    v.total AS Total FROM     ventas v  INNER JOIN     clientes c; ";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                            reader["venta_id"].ToString(),
                            reader["id_cliente"].ToString(),
                            reader["nombre"].ToString(),
                            reader["placa"].ToString(),
                            reader["total"].ToString()

                        );

                        // Añadimos la fila a la lista
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

        //Metodo que guarda registros de la tabla Alquiler
        public string[] infoAlquiler()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT    cod_alquiler,    id_vehiculo,   id_usuario,    tipo_tarifa,    f_retiro,   f_entrega,    total   FROM     Flota_Alquiler;";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
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

                        // Añadimos la fila a la lista
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

        //Metodo que guarda registro e de la tabla subasta 
        public string[] infoSubastas()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT cod_subasta, valor_inicial, id_placa, valor_puja,  id_usuario,  estado,    t_inicio,  t_final  FROM     Flota_Subasta  WHERE   estado = 'finalizada'";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                           reader["cod_subasta"].ToString(),
                           reader["valor_inicial"].ToString(),
                           reader["id_placa"].ToString(),
                           reader["valor_puja"].ToString(),
                           reader["id_usuario"].ToString(),
                           reader["estado"].ToString(),
                           reader["t_inicio"].ToString(),
                           reader["t_final"].ToString()

                        );

                        // Añadimos la fila a la lista
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


        
        //Este metodo Guarda todos los registros de la tabla solicitud 
        public string[] infoSolicitudes()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT s.id_solicitud,  u.nombre AS nombre_cliente,  s.estado,  s.f_solicitud,  s.monto   FROM    Solicitud s   INNER JOIN     Usuario u ON s.id_usuario = u.id";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
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

                        // Añadimos la fila a la lista
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














    }

}
