 using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Loggearse : Conexiondb
    {

       //Metodo para verificar los valores del Login
        public int verificarLogin(string correo, string contraseña)
        {
            
            try
            {
                
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = "SELECT * FROM login WHERE correo = @correo AND contraseña = SHA2(@contraseña, 256)";

             
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

               
                abrirConexion();

               
               return Convert.ToInt32(cmd.ExecuteScalar());
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

        public int loginForm(string correo, string contraseña)
        {

            try
            {

                cmd.Parameters.Clear();


                cmd.CommandType = CommandType.Text;


                cmd.CommandText = "SELECT rol FROM login WHERE correo = @correo AND contraseña = SHA2(@contraseña, 256)";


                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);


                abrirConexion();


                return Convert.ToInt32(cmd.ExecuteScalar());
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

        //metodo para obtener informacion del usuario {nombre, correo y telefono}
        public List<UsuarioRequest> obtenerUsuario(int id) {
        
            List<UsuarioRequest> cliente = new List<UsuarioRequest>();
            UsuarioRequest usuario = new UsuarioRequest();
            try
            {
               
                cmd.Parameters.Clear();

                
                cmd.CommandType = CommandType.Text;

                
                cmd.CommandText = "SELECT Usuario.nombre, Usuario.apellido, Usuario.telefono, Login.correo FROM  Usuario JOIN Login ON Usuario.id = Login.id_usuario WHERE Usuario.id = @id";

              
                cmd.Parameters.AddWithValue("@id", id);
  

               
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


        //Metodo para contar la cantidad de Correos por los usuarios
        public int ObtenerIdPorCorreo(string correo)
        {
            try
            {
              
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT id_usuario FROM login WHERE correo = @correo";

                // Asignar el parámetro
                cmd.Parameters.AddWithValue("@correo", correo);

                // Abrir la conexión
                abrirConexion();

                // Ejecutar la consulta y obtener el resultado
                var result = cmd.ExecuteScalar();

                // Verificar si el resultado es nulo (correo no encontrado)
                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("El correo proporcionado no existe en la base de datos.");
                }

                // Convertir el resultado a entero (ID del usuario)
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error al obtener el ID del usuario.", ex);
            }
            finally
            {
                // Asegurar el cierre de la conexión
                cerrarConexion();
            }
        }


    }
}
