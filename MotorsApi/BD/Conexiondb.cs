using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD
{
    public class Conexiondb
    {
        //Atributos de la clase 
        public MySqlConnection conexion;
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter;
        public DataSet ds;

        //Objeto de la clase Notificando para hacer saber problemas
        private Notificacion noti = new Notificacion();

        //Metodo constructor para inicializar los atributos
        public Conexiondb()
        {
            try
            {

                string cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                conexion = new MySqlConnection(cadenaConexion);
                cmd = new MySqlCommand();
                cmd.Connection = conexion;
            }
            catch (Exception e)
            {

                noti.notificarError("No se pudo inicializar la cadena de Conexion " + e.Message);
            }
        }

        public MySqlConnection getConnection()
        {
            return conexion;
        }

        //Metodo para abrir conexion
        public void abrirConexion()
        {

            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (Exception e)
            {

                noti.notificarError("No pudimos conectarnos a la base de datos");
            }
        }

        //Metodo para cerrar conecion a la bd
        public void cerrarConexion()
        {
            try
            {
                if (conexion.State != ConnectionState.Closed)
                {

                    conexion.Close();
                }
            }
            catch (Exception e)
            {

                noti.notificarError("No pudimos cerrar la conexion a la base de datos");
            }
        }


    }
}
