using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Loggearse : Conexiondb
    {

        public List<Login> logearse()
        {
            // Variables de proceso
            List<Login> dataUsuario = new List<Login>();
            Login login = new Login();
            try
            {
                // Limpiamos
                cmd.Parameters.Clear();

                // Asignamos el tipo
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT * FROM login";

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Verifica si hay registros
                    {
                        login.id_usuario = reader.GetInt32(0);
                        login.contraseña = reader.GetString(1);
                        login.rol = reader.GetInt32(2);
                        login.correo = reader.GetString(3);
                    }

                    dataUsuario.Add(login);
                }
            }
            catch (Exception e)
            {
               Console.WriteLine("Problemas al iniciar sesión " + e);
            }
            finally
            {
                cerrarConexion();
            }

            return dataUsuario;
        }


        public bool VerificarLogin(string correo, string contraseña)
        {
            bool esValido = false;

            try
            {
                // Limpiamos los parámetros
                cmd.Parameters.Clear();

                // Asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                // Consulta SQL con parámetros para evitar inyecciones SQL
                cmd.CommandText = "SELECT COUNT(*) FROM login WHERE correo = @correo AND contraseña = @contraseña";

                // Agregamos los parámetros
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta y verificamos el resultado
                esValido = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al verificar el login: " + e.Message);
            }
            finally
            {
                cerrarConexion();
            }

            return esValido;

        }

    }
}
