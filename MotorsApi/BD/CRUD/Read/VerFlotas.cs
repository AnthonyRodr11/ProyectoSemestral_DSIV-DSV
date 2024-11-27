using Microsoft.Extensions.Primitives;
using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class VerFlotas : Conexiondb
    {

        //Metodo para devolver una lista segun su estado <Alquiler,venta>
        public List<FlotaCarroRequest> tiposFlota(string estado)
        {
            List<FlotaCarroRequest> autos = new List<FlotaCarroRequest>();

            try
            {
                
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = @"
                    SELECT 
                        c.placa, c.marca, c.modelo, c.foto, 
                        v.precio
                    FROM 
                        Flota_Carro c
                    JOIN 
                        Flota_Venta v ON v.placa = c.placa
                    WHERE 
                        c.estado = @estado AND disponibilidad = 1";

                cmd.Parameters.AddWithValue("@estado", estado);

               
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        FlotaCarroRequest flota = new FlotaCarroRequest()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            foto = reader["foto"].ToString(),
                            precio = Convert.ToDouble(reader["precio"])
                        };

                        
                        autos.Add(flota);
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
            return autos;
        }

        public List<FlotaCarroRequest> flotaVenta(string id)
        {
            List<FlotaCarroRequest> autos = new List<FlotaCarroRequest>();

            try
            {
                
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                // Realizamos un JOIN entre Flota_Carro y Flota_Venta para obtener solo los campos necesarios
                cmd.CommandText = @"
                    SELECT 
                        c.placa, c.marca, c.modelo, c.foto, c.km, c.transmision, c.tipo_gas, c.carroceria,
                        v.precio
                    FROM 
                        Flota_Carro c
                    JOIN 
                        Flota_Venta v ON c.placa = v.placa
                    WHERE 
                        c.placa = @placa";

                
                cmd.Parameters.AddWithValue("@placa", id);

               
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Creamos un objeto Flota_CarroRequest para almacenar los datos
                        FlotaCarroRequest flota = new FlotaCarroRequest()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            foto = reader["foto"].ToString(),
                            km = Convert.ToDouble(reader["km"]),
                            transmision = reader["transmision"].ToString(),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            precio = Convert.ToDouble(reader["precio"])
                        };

                       
                        autos.Add(flota);
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
            return autos;
        }

        //Metodo para cargar toda la flota
        public List<FlotaCarro> obtenerFlota()
        {
            List<FlotaCarro> autos = new List<FlotaCarro>();
            string data;

            try
            {
                
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT * from  flota_carro";


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                      
                        FlotaCarro flota = new FlotaCarro()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            color = reader["color"].ToString(),
                            km = Convert.ToDouble(reader["km"]),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            estado = reader["estado"].ToString(),
                            descripcion = reader["descripcion"].ToString(),
                            disponibilidad = Convert.ToBoolean(reader["disponibilidad"]),
                            foto = reader["foto"].ToString()

                        };

                        autos.Add(flota);
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
            return autos;
        }

        //Metodo para cargar toda la flota en venta
        public List<FlotaCarroRequest> obtenerAutos(string estado)
        {
            List<FlotaCarroRequest> autos = new List<FlotaCarroRequest>();
            string data;

            try
            {
                
                cmd.Parameters.Clear();

               
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT  placa,  marca,  modelo,  color,  km,   transmision,   tipo_gas,   carroceria,   estado,    descripcion,    foto   FROM Flota_Carro  WHERE estado = @estado";

             
                cmd.Parameters.AddWithValue("@estado", estado);


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //creamos objeto
                        FlotaCarroRequest flota = new FlotaCarroRequest()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            color = reader["color"].ToString(),
                            km = Convert.ToDouble(reader["km"]),
                            transmision = reader["transmision"].ToString(),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            estado = reader["estado"].ToString(),
                            descripcion = reader["descripcion"].ToString(),
                            foto = reader["foto"].ToString()

                        };

                        autos.Add(flota);
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
            return autos;
        }

        public List<TarifasAlquiler> obtenerTarifas()
        {
            List<TarifasAlquiler> alquileres = new List<TarifasAlquiler>();

            try
            {
               
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = "SELECT * from tarifas_alquiler";


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                      
                        TarifasAlquiler alquiler = new TarifasAlquiler()
                        {
                            id_tipo = Convert.ToInt32(reader["id_tipo"]),
                            tipo_auto = reader["tipo_auto"].ToString(),
                            tarifaxauto = Convert.ToDouble(reader["tarifaxauto"])
                        };

                        alquileres.Add(alquiler);
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
            return alquileres;
        }

        //Metodo para obtener la lista de tipo de autos segun carroceria para venta, alquiler, subasta
        public List<string> listaCarroceria(string estado)
        {
            List<string> carroceria = new List<string>();
            string tipo = string.Empty;

            try
            {
                
                cmd.Parameters.Clear();

              
                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = "SELECT DISTINCT carroceria FROM Flota_Carro WHERE estado = @estado";

               
                cmd.Parameters.AddWithValue("@estado", estado);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        tipo = reader["carroceria"].ToString();
                        carroceria.Add(tipo);
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
            return carroceria;
        }


        //Metodo oferta actual
        public double obtenerOfertaActual(int cod_subasta)
        {

            double valor = 0;
            try
            {
                
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT   valor_puja   FROM Flota_Subasta WHERE cod_subasta = @cod_subasta ";

              
                cmd.Parameters.AddWithValue("@cod_subasta", cod_subasta);


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        valor = reader.GetDouble(0);
                    };

                    return valor;

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
            return valor;

        }

        //Metodo autos alquiler
        public List<AlquilerCarrosRequest> alquileresAutos()
        {
            List<AlquilerCarrosRequest> carrosEnAlquiler = new List<AlquilerCarrosRequest>();
            try
            {

                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"
                    SELECT 
                        fc.placa,
                        fc.marca,
                        fc.modelo,
                        fc.foto,
                        ta.id_tipo,
                        ta.tarifaxauto
                    FROM 
                        Flota_Carro fc
                    INNER JOIN 
                        Tarifas_Alquiler ta
                    ON 
                        fc.carroceria = ta.tipo_auto
                    WHERE 
                        fc.estado = 'alquiler' AND disponibilidad = 1";
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AlquilerCarrosRequest alquilercito = new AlquilerCarrosRequest()
                        {
                            marca = reader["marca"].ToString(),
                            placa = reader["placa"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            foto = reader["foto"].ToString(),
                            tipoTarifa = Convert.ToInt32(reader["id_tipo"]),
                            tarifa = Convert.ToDouble(reader["tarifaxauto"]),
                        };
                        carrosEnAlquiler.Add(alquilercito);
                    }
                }
            }
            catch (Exception e) { throw; }
            finally { cerrarConexion(); }
            return carrosEnAlquiler;



        }

        //Metodo para obtener la lista de autos en subasta
        public List<FlotaSubastaRequest> listaSubasta()
        {
            //Lista de objetos
            List<FlotaSubastaRequest> lista = new List<FlotaSubastaRequest>();

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT  FS.cod_subasta,FS.valor_inicial,FS.valor_puja,FS.t_final,FC.marca, FC.modelo, FC.km, FC.transmision,FC.tipo_gas,FC.carroceria, FC.foto FROM Flota_Subasta FS INNER JOIN Flota_Carro FC ON FS.id_placa = FC.placa WHERE FS.estado = 'activa' AND FC.estado = 'subasta';";

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FlotaSubastaRequest autoSubastar = new FlotaSubastaRequest()
                        {
                            cod_subasta = reader.GetInt32(0),
                            valor_inicial = reader.GetDouble(1),
                            valor_puja = reader.GetDouble(2),
                            t_final = reader.GetDateTime(3),
                            marca = reader.GetString(4),
                            modelo = reader.GetString(5),
                            km = reader.GetDouble(6),
                            transmision = reader.GetString(7),
                            tipo_gas = reader.GetString(8),
                            carroceria = reader.GetString(9),
                            foto = reader.GetString(10),
                        };

                        lista.Add(autoSubastar);
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


        //Lista la informacion de subasta
        public FlotaSubastaRequest listaSubasta(int codigo)
        {

            FlotaSubastaRequest lista = null;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new MySqlParameter("@placa", codigo));

                //asignamos consulta a realizar
                cmd.CommandText = @"    
                                    SELECT 
                                        fc.km, fc.transmision, fc.tipo_gas, fc.carroceria, fc.marca, fc.modelo, fc.foto, fs.t_final, fs.valor_inicial, fs.valor_puja 
                                    FROM 
                                        flota_carro fc
                                    INNER JOIN
                                        flota_subasta fs
                                    ON 
                                        fc.placa = fs.id_placa
                                    WHERE fs.cod_subasta = @placa AND fc.disponibilidad = 1";//placa en realidad es el código de subasta pero era más fácil solo dejarlo en placa. QUe si haciendo el comentario me tomó más tiempo que cambiarlo?
                                                                   //si, pero estoy aburrido

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista = new FlotaSubastaRequest()
                        {
                            km = reader.GetDouble(0),
                            transmision = reader.GetString(1),
                            tipo_gas = reader.GetString(2),
                            carroceria = reader.GetString(3),
                            marca = reader.GetString(4),
                            modelo = reader.GetString(5),
                            foto = reader.GetString(6),
                            t_final = reader.GetDateTime(7),
                            valor_inicial = reader.GetDouble(8),
                            valor_puja = reader.GetDouble(9),
                        };
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
    }
}











