using MotorsApi.Models;
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

        //Metodo para cargar toda la flota
        public List<Flota_Carro> obtenerFlota()
        {
            List<Flota_Carro> autos = new List<Flota_Carro>();
            string data;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT * from  flota_carro";
                

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //creamos objeto
                        Flota_Carro flota = new Flota_Carro()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            color = reader["color"].ToString(),
                            km = Convert.ToDouble(reader["color"]),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            estado = reader["estado"].ToString(),
                            descripcion = reader["descripcion"].ToString(),
                            disponibilidad = Convert.ToBoolean(reader["disponibilidad"]),
                            foto = reader.ToString()

                        };
                        
                        autos.Add(flota);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo cargar la lista de autos" + e);
            }
            finally
            {

                cerrarConexion();
            }
            return autos;
        }
    }
}