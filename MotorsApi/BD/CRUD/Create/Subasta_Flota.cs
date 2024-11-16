using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Subasta_Flota : Conexiondb
    {

        //Metodo para mandar un auto a Subastar
        public int registrarAutosubasta(Flota_Subasta autoSubastar)
        {
           
            try
            {
                //limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "sp_registrarSubasta"; //poner nombre posteriormente

                //asignamos parametros

                cmd.Parameters.Add(new MySqlParameter("@valor_inicial", autoSubastar.valor_inicial));
                cmd.Parameters.Add(new MySqlParameter("@id_placa", autoSubastar.id_placa));
                cmd.Parameters.Add(new MySqlParameter("@valor_puja", autoSubastar.valor_puja));
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", autoSubastar.id_usuario));
                cmd.Parameters.Add(new MySqlParameter("@estado", autoSubastar.estado));
                cmd.Parameters.Add(new MySqlParameter("@t_incio", autoSubastar.t_inicio));
                cmd.Parameters.Add(new MySqlParameter("@t_final", autoSubastar.t_final));

                //abrimos conexion a la BD
                abrirConexion();

                //validamos si se inserto el registro en la tabla Flota_Subasta
                int insercion = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insercion > 0)
                {
                    return insercion;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo mandar a subastar el auto"+e);
            }
            finally
            {
                cerrarConexion();
            }
            return 0;

        }

    }
}
