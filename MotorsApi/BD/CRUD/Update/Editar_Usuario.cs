using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class Editar_Usuario : Conexiondb
    {
        //Editasmos Telefono de Usuario
        //public int UsuarioEditar ( Usuario usuario, Login login)
        //{
        //    try
        //    {
        //        //Limpiamos parametros
        //        cmd.Parameters.Clear();

        //        //asignamos el tipo
        //        cmd.CommandType = CommandType.Text;

        //        //asignamos el cod
        //        cmd.CommandText = "UPDATE Usuario SET telefono = @telefono  WHERE id = @id";

        //        //asignamos parametros
        //        cmd.Parameters.Add(new MySqlParameter("@id", usuario.id));
        //        cmd.Parameters.Add(new MySqlParameter("@telefono", usuario.telefono));
        //        cmd.Parameters.Add(new MySqlParameter("@f_actualizacion", usuario.f_actualizacion));


        //        //Abrimos conexion
        //        abrirConexion();

        //        //Validacion de Actualizacion
        //        int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
        //        if (insertedId > 0)
        //        {
        //            return insertedId;
        //        }


        //    }

        //    catch (Exception e)
        //    {

        //        Console.WriteLine("No pudo actualizarse" + e);
        //    }
        //    finally
        //    {
        //        //Cerramos conexion
        //        cerrarConexion();
        //    }
        //    return 0;
        //}

        public int EditarUsuario(int id, ActualizarUsuario usuario)
        {

            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //Asignamos el cod
                cmd.CommandText = "EditarUsuarioLogin";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@p_id_usuario", id));
                cmd.Parameters.Add(new MySqlParameter("@p_telefono", usuario.telefono));
                cmd.Parameters.Add(new MySqlParameter("@p_contraseña", usuario.contraseña));
                cmd.Parameters.Add(new MySqlParameter("@p_correo", usuario.correo));


                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insercion > 0)
                {
                    return insercion;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo registrar el Auto" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return 0;
        }



    }
}
