using MySql.Data.MySqlClient;

namespace MotorsApi.BD.CRUD.Delete
{
    public class SubastaDeleter : Conexiondb
    {
        public int EliminarCarro(string placa)
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "DELETE FROM flota_subasta WHERE id_placa = @placa";

                cmd.Parameters.Add(new MySqlParameter("@placa", placa));

                abrirConexion();

                var guardar = cmd.ExecuteNonQuery();

                if (guardar != null && guardar > 0)
                {
                    return guardar;
                }
            }
            catch (Exception error) { Console.WriteLine(error.Message); }
            finally { cerrarConexion(); }
            return 0;
        }
    }
}
