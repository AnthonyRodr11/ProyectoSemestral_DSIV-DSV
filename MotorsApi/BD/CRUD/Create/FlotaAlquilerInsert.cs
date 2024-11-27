using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class FlotaAlquilerInsert : Conexiondb
    {

       
        public int InsertarAlquilado(AlquilerRequest alquiler)
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO flota_alquiler (id_vehiculo, id_usuario, tipo_tarifa, f_retiro, f_entrega, total, id_seguro) VALUES (@id_vehiculo, @id_usuario, @tarifa, @f_retiro, @f_entrega, @total, @id_seguro)";

                cmd.Parameters.Add(new MySqlParameter("@id_vehiculo", alquiler.placa));
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", alquiler.idUsuario));
                cmd.Parameters.Add(new MySqlParameter("@tarifa", alquiler.tipoTarifa));
                cmd.Parameters.Add(new MySqlParameter("@f_retiro", alquiler.fechaRetiro));
                cmd.Parameters.Add(new MySqlParameter("@f_entrega", alquiler.fechaEntrega));
                cmd.Parameters.Add(new MySqlParameter("@total", alquiler.precioTotal));
                cmd.Parameters.Add(new MySqlParameter("@id_seguro", alquiler.idSeguro));

                abrirConexion();
                var guardar = cmd.ExecuteNonQuery();
                if (guardar > 0)
                    return guardar;
            }
            catch (Exception e){

                throw;
            }
            finally { cerrarConexion(); }

            return 0;
        }

    }
}
