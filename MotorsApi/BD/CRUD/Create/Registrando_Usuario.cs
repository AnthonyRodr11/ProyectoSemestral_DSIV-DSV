using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Registrando_Usuario : Conexiondb
    {
        public int Usuario_Registro(Usuario usuario, Login login)
        {
            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO Usuario (nombre,apellido,identificacion,telefono) VALUES (@nombre,@apellido,@identificacion,@telefono)"; //poner nombre posteriormente

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@nombre", usuario.nombre));
                cmd.Parameters.Add(new MySqlParameter("@apellido", usuario.apellido));
                cmd.Parameters.Add(new MySqlParameter("@identificacion", usuario.indentificacion));
                cmd.Parameters.Add(new MySqlParameter("@telefono", usuario.telefono));
                cmd.Parameters.Add(new MySqlParameter("@f_creacion", usuario.f_creacion));

                
                cmd.CommandText = "INSERT INTO Login (contraseña,rol,correo) VALUES (@contraseña,@rol,@correo)";
                cmd.Parameters.Add(new MySqlParameter("@contraseña", login.contraseña));
                cmd.Parameters.Add(new MySqlParameter("@rol", login.rol));
                cmd.Parameters.Add(new MySqlParameter("@correo", login.correo));


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
