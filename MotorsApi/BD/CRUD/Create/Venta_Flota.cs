using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Venta_Flota : Conexiondb
    {
        public int registrarVenta(Flota_Venta flota_Venta)
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
                cmd.CommandText = "INSERT INTO Flota_Venta (placa, precio) VALUES(@placa,@precio)"; //poner nombre posteriormente

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@placa", flota_Venta.placa));
                cmd.Parameters.Add(new MySqlParameter("@precio", flota_Venta.precio));

                ;

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
