using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class SolicitudUpdate : Conexiondb
    {
        //Metodo para actualizar el estado de pendiente a rechazado
        public int rechazarSolicitud(int id_solicitud)
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "UPDATE solicitud SET estado = 'rechazada' WHERE id_solicitud = @id_solicitud";

                cmd.Parameters.Add(new MySqlParameter("@id_solicitud", id_solicitud));

                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insertedId > 0)
                {
                    return insertedId;
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

            return 0;
        }

        //Metodo para actualizar el estado de pendiente a rechazado
        public int aceptarSolicitud(int id_solicitud)
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "UPDATE solicitud SET estado = 'aceptada' WHERE id_solicitud = @id_solicitud";

                cmd.Parameters.Add(new MySqlParameter("@id_solicitud", id_solicitud));

                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insertedId > 0)
                {
                    return insertedId;
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

            return 0;
        }

    }
}
