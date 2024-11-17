using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Flota_Auto : Conexiondb
    {

        //Metodo para registrar un nuevo auto a la tabla Flota_Carro
        public int registraAutoflota(Flota_Carro regAuto)
        {
            //declaracion de variables de trabajo
            int insercion = 0;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "sp_registrarAuto"; //poner nombre posteriormente

                //asignamos parametros
                // Asignamos los parámetros con nombres que coincidan con el procedimiento
                cmd.Parameters.Add(new MySqlParameter("@p_placa", regAuto.placa));
                cmd.Parameters.Add(new MySqlParameter("@p_marca", regAuto.marca));
                cmd.Parameters.Add(new MySqlParameter("@p_modelo", regAuto.modelo));
                cmd.Parameters.Add(new MySqlParameter("@p_color", regAuto.color));
                cmd.Parameters.Add(new MySqlParameter("@p_km", regAuto.km));
                cmd.Parameters.Add(new MySqlParameter("@p_transmision", regAuto.transmision));
                cmd.Parameters.Add(new MySqlParameter("@p_tipo_gas", regAuto.tipo_gas));
                cmd.Parameters.Add(new MySqlParameter("@p_carroceria", regAuto.carroceria));
                cmd.Parameters.Add(new MySqlParameter("@p_estado", regAuto.estado));
                cmd.Parameters.Add(new MySqlParameter("@p_descripcion", regAuto.descripcion));
                cmd.Parameters.Add(new MySqlParameter("@p_disponibilidad", regAuto.disponibilidad));
                cmd.Parameters.Add(new MySqlParameter("@p_foto", regAuto.foto));

                //abrir Conexion
                abrirConexion();
                //validamos si se inserto el auto
                return insercion = cmd.ExecuteNonQuery();

                Console.WriteLine("holakease");

                if (insercion > 0)
                {
                    return insercion;
                }
                else
                {
                    insercion = -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo registrar el Auto" + e.ToString());
            }
            finally
            {
                cerrarConexion();
                
            }
            return insercion;
        }

    }
}
