using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Versolicitudes : Conexiondb
    {
        //estos metodos cargaran la informacion en la pantalla de solicitudes

        //Obtendremos el nombre del Cliente que mando Solicitud
        public List<string> obtenerNombresolicitante()
        {
            string usuario_id;
            List<string> listaSolicitantes = new List<string>();

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT id_usuario FROM Solicitud";

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Agregamos cada id a la lista
                        usuario_id = reader.GetString(0);
                        listaSolicitantes.Add(usuario_id);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo obtener la lista de solicitantes"+e);
            }
            finally
            {
                cerrarConexion();
            }
            return listaSolicitantes;
        }

        //Metodo para obtener el valor que pide compra el usuario
        public double obtenerMonto(string id_usuario)
        {
            double monto = 0;


            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT monto FROM Solicitud WHERE id_usuario = @id_usuariosuario";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //obtenemos la data y guardamos 
                        monto = reader.GetDouble(0);

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo obtener el monto"+e);
            }
            finally { 

                cerrarConexion(); 
            }
            return monto;
        }

        //Metodo para obtener foto y descripcion de la solicitud
        public List<string> obtenerDescripcion(string id_usuario)
        {
            List<string> data = new List<string>();
            string rutaFoto,descripcion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT descripcion, foto FROM Solicitud WHERE id_usuario = @IdUsuario";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //obtenemos la data y guardamos 
                        descripcion = reader.GetString(0); //descripciion
                        rutaFoto = reader.GetString(1); //ruta de la imagen

                        data.Add(descripcion); // en la posicion 0 esta
                        data.Add(rutaFoto); //en la posicion 1 esta

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo obtener la descripcion y foto" + e);
            }
            finally {

                cerrarConexion();
            }

            return data;
        }
    }
}
