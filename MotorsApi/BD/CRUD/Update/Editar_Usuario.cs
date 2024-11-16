using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class Editar_Usuario : Conexiondb
    {

        public int UsuarioEditar ( Usuario usuario, Login login)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el cod
                cmd.CommandText = "UPDATE Usuario SET telefono = @telefono  WHERE id = @id";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@id", usuario.id));
                cmd.Parameters.Add(new MySqlParameter("@telefono", usuario.telefono));
                cmd.Parameters.Add(new MySqlParameter("@f_actualizacion", usuario.f_actualizacion));


                //Asignamos el cod
                cmd.CommandText = "UPDATE Login SET contraseña = @contraseña, correo = @correo  WHERE id_usuario = @id_usuario";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", login.id_usuario));
                cmd.Parameters.Add(new MySqlParameter("@contraseña", login.contraseña));
                cmd.Parameters.Add(new MySqlParameter("@correo", login.correo));
                



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

                Console.WriteLine("No pudo actualizarce" + e);
            }
            finally
            {
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;
        }





    }
}
