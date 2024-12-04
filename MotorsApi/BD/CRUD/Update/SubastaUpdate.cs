using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update

{
    public class SubastaUpdate : Conexiondb
    {
        public int ActualizarEstadoSubasta(AgregarSubasta subastita)
        {
            try
            {

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "UPDATE flota_carro SET estado = 'subasta' WHERE placa = @placa";

                cmd.Parameters.Add(new MySqlParameter("@placa", subastita.id_placa));

                abrirConexion();

                var guarda = cmd.ExecuteNonQuery();
                if (guarda > 0)
                    return guarda;
            }
            catch (MySqlException ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            finally { cerrarConexion(); }

            return 0;

        }

        public int ActualizarEstadoSubasta(AgregarSubasta subastita, string estado)
        {
            try
            {

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "UPDATE flota_carro SET estado = @estado WHERE placa = @placa";

                cmd.Parameters.Add(new MySqlParameter("@placa", subastita.id_placa));
                cmd.Parameters.Add(new MySqlParameter("@estado", estado));

                abrirConexion();

                var guarda = cmd.ExecuteNonQuery();
                if (guarda > 0)
                    return guarda;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { cerrarConexion(); }

            return 0;

        }

    }
}
