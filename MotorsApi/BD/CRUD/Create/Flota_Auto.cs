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
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "sp_registrarAuto"; //poner nombre posteriormente

                //asignamos parametros
                cmd.Parameters.Add( new MySqlParameter("@placa",regAuto.placa));
                cmd.Parameters.Add(new MySqlParameter("@marca", regAuto.marca));
                cmd.Parameters.Add(new MySqlParameter("@modelo", regAuto.modelo));
                cmd.Parameters.Add(new MySqlParameter("@color", regAuto.color));
                cmd.Parameters.Add(new MySqlParameter("@km", regAuto.km));
                cmd.Parameters.Add(new MySqlParameter("@transmision", regAuto.transmision));
                cmd.Parameters.Add(new MySqlParameter("@tipo_gas", regAuto.tipo_gas));
                cmd.Parameters.Add(new MySqlParameter("@carroceria", regAuto.carroceria));
                cmd.Parameters.Add(new MySqlParameter("@estado", regAuto.estado));
                cmd.Parameters.Add(new MySqlParameter("@descripcion", regAuto.descripcion));
                cmd.Parameters.Add(new MySqlParameter("@disponibilidad", regAuto.disponibilidad));
                cmd.Parameters.Add(new MySqlParameter("@foto", regAuto.foto));

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
                Console.WriteLine("No se pudo registrar el Auto"+e);
            }
            finally
            {
                cerrarConexion();

            }
            return insercion = 0;
        }

    }
}
