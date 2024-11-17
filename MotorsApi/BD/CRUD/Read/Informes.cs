using System.Data;
using MySql.Data.MySqlClient;
namespace MotorsApi.BD.CRUD.Read
{
    public class Informes : Conexiondb
    {
        //Metodo para retornar la data para el  archivo .txt coon informe de flota
        public string [] infoFlota()
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
                Console.WriteLine("No se pudo realizar la consulta"+e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }


    }
}
