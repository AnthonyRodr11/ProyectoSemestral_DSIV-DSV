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
        public bool verificarCorreo(string correo)
        {
            try
            {
                
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;

               
                cmd.CommandText = "SELECT COUNT(*) FROM login WHERE correo = @correo";

              
                cmd.Parameters.AddWithValue("@correo", correo);

               
                abrirConexion();

               
                int count = Convert.ToInt32(cmd.ExecuteScalar());

             
                return count > 0;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                cerrarConexion();
            }

            
            return false;
        }


    }
}
