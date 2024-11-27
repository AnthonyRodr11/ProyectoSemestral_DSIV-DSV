using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class RegistrandoUsuario : Conexiondb
    {

        //Método para registrar el Login
        public int CreandoRegistro(RegistroUsuario persona)
        {
            Usuario usuario = new Usuario
            {
                nombre = persona.nombre,
                apellido = persona.apellido,
                identificacion = persona.identificacion,
                telefono = persona.telefono
            };

            int usuarioId = Usuario_Registro(usuario);

            if (usuarioId > 0)
            {
                // Registramos el login usando el ID del usuario generado
                Login login = new Login
                {
                    correo = persona.correo,
                    contraseña = persona.contraseña,
                    rol = persona.rol,
                    id_usuario = usuarioId 
                };

                return Login_Registro(login);
            }
            else
            {
                Console.WriteLine("No se pudo registrar el usuario.");
            }
            return 0;
        }



        //Metodo para registrar loa atributos del Usuario
        public int Usuario_Registro(Usuario usuario)
        {
            int usuarioId = 0;

            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Usuario (nombre, apellido, identificacion, telefono)" +
                    "VALUES (@nombre, @apellido, @identificacion, @telefono);" +
                    "SELECT LAST_INSERT_ID();";

                cmd.Parameters.Add(new MySqlParameter("@nombre", usuario.nombre));
                cmd.Parameters.Add(new MySqlParameter("@apellido", usuario.apellido));
                cmd.Parameters.Add(new MySqlParameter("@identificacion", usuario.identificacion));
                cmd.Parameters.Add(new MySqlParameter("@telefono", usuario.telefono));

                abrirConexion();

                // Ejecutamos el comando y obtenemos el ID generado
                usuarioId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                cerrarConexion();
            }

            return usuarioId;
        }



        //SE INSERTA LA CONTRASEÑA CON SHA2
        //Metodo para registrar los atributos del Login 
        public int Login_Registro(Login login)
        {

            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos parametros

                cmd.CommandText = "INSERT INTO Login (id_usuario, contraseña, rol, correo) VALUES (@id_usuario, SHA2(@contraseña, 256), @rol, @correo)";
                cmd.Parameters.Add(new MySqlParameter("@contraseña", login.contraseña));
                cmd.Parameters.Add(new MySqlParameter("@rol", login.rol));
                cmd.Parameters.Add(new MySqlParameter("@correo", login.correo));
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", login.id_usuario));


                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = cmd.ExecuteNonQuery();

                if (insercion > 0)
                {

                    return insercion;
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
