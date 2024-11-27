using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Loggearse : Conexiondb
    {

        //SE MODIFICO LA CONSULTA MYSQL
        public int VerificarLogin(string correo, string contraseña)
        {
            

            try
            {
                // Limpiamos los parámetros
                cmd.Parameters.Clear();

                // Asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                // Consulta SQL con parámetros para evitar inyecciones SQL
                cmd.CommandText = "SELECT * FROM login WHERE correo = @correo AND contraseña = SHA2(@contraseña, 256)";

                // Agregamos los parámetros
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta y verificamos el resultado
               return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al verificar el login: " + e.Message);
            }
            finally
            {
                cerrarConexion();
            }

            return 0;

        }

        //metodo para obtener informacion del usuario {nombre, correo y telefono}
        public List<UsuarioRequest> obtenerUsuario(int id) {
        
            List<UsuarioRequest> cliente = new List<UsuarioRequest>();
            UsuarioRequest usuario = new UsuarioRequest();
            try
            {
                // Limpiamos los parámetros
                cmd.Parameters.Clear();

                // Asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                // Consulta SQL con parámetros para evitar inyecciones SQL
                cmd.CommandText = "SELECT Usuario.nombre, Usuario.apellido, Usuario.telefono, Login.correo FROM  Usuario JOIN Login ON Usuario.id = Login.id_usuario WHERE Usuario.id = @id";

                // Agregamos los parámetros
                cmd.Parameters.AddWithValue("@id", id);
  

                // Abrimos la conexión
                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Verifica si hay registros
                    {
                        usuario.nombre = reader.GetString(0);
                        usuario.apellido = reader.GetString(1);
                        usuario.telefono = reader.GetString(2);
                        usuario.correo = reader.GetString(3);
                    }

                    cliente.Add(usuario);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally {

                cerrarConexion();
            }
            
            return cliente;
        }

        public bool VerificarCorreo(string correo)
        {
            try
            {
                // Limpiamos los parámetros
                cmd.Parameters.Clear();

                // Asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                // Consulta SQL con COUNT para verificar la existencia del correo
                cmd.CommandText = "SELECT COUNT(*) FROM login WHERE correo = @correo";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@correo", correo);

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta y verificamos el resultado
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // Si el resultado es mayor que 0, el correo existe
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al verificar el correo: " + e.Message);
            }
            finally
            {
                // Cerramos la conexión, pase lo que pase
                cerrarConexion();
            }

            // En caso de error, asumimos que el correo no existe
            return false;
        }


    }
}
