using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotorsApi.BD.CRUD.Read
{
    public class AutoRequest : Conexiondb
    {
        public string AutoInfo(string placa)
        {
            string lista = null;

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "sp_obtener_carro_info";

                cmd.Parameters.Add(new MySqlParameter("@p_placa", placa));

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        lista = string.Join(";",
                            reader["marca"].ToString(),
                            reader["modelo"].ToString(),
                            reader["foto"].ToString(),
                            reader["tarifaxauto"].ToString()
                        );

                        // Añadimos la fila a la lista
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { cerrarConexion(); }
            return lista;
        }
    }
}
