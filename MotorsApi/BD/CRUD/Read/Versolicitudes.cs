using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using MotorsApi.Models;

namespace MotorsApi.BD.CRUD.Read
{
    public class Versolicitudes : Conexiondb
    {
        //estos metodos cargaran la informacion en la pantalla de solicitudes

        //Obtendremos el nombre  y apellido del usuario dado el id_solicitud
        public string obtenernombresolicitante(int id_solicitud)
        {
            string nombre = string.Empty;
            string apellido = string.Empty;
            string nombreCompleto = string.Empty;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT Usuario.nombre, Usuario.apellido FROM Solicitud JOIN Usuario ON Solicitud.id_usuario = Usuario.id WHERE Solicitud.id_solicitud = @id_solicitud";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nombre = reader.GetString(0);
                        apellido = reader.GetString(1);
                        nombreCompleto = $"{nombre} {apellido}";
                    }
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
            return nombreCompleto;
        }

        //Metodo para obtener el valor que pide compra el usuario
        public double obtenerMonto(int id_solicitud)                  //cambiar por id_solicitud
        {
            double monto = 0;


            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT monto FROM Solicitud WHERE id_solicitud = @id_solicitud";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

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
                throw;
            }
            finally {

                cerrarConexion();
            }
            return monto;
        }

        //Metodo para obtener descripcion de la solicitud
        public string obtenerDescripcion(int id_solicitud)          //cambiar por id_solicitud
        {
            
            string descripcion = "";

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT descripcion FROM Solicitud WHERE id_solicitud = @id_solicitud";

                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //obtenemos la data y guardamos 
                        descripcion = reader.GetString(0); //descripciion

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally {

                cerrarConexion();
            }

            return descripcion;
        } 


        

        //Metodo para mostrar todas las solicitudes
        public List<SolicitudesRequest> obtenerSolicitudes()
        {
            List<SolicitudesRequest> solicitudes = new List<SolicitudesRequest>();

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT Solicitud.id_solicitud,Usuario.nombre,Usuario.apellido,Solicitud.estado,Solicitud.f_solicitud,Solicitud.monto FROM  Solicitud JOIN Usuario ON Solicitud.id_usuario = Usuario.id";

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SolicitudesRequest solicitud = new SolicitudesRequest()
                        {    
                            id_solicitud = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            apellido = reader.GetString(2),
                            estado = reader.GetString(3),
                            f_solicitud = reader.GetDateTime(4),
                            monto = reader.GetDouble(5),
                        };

                        //agregamos cada lista de objeto a la lista 
                        solicitudes.Add(solicitud);
                    }
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

            return solicitudes;
        }
        
    }
}
