using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class Alquiler_Auto : Conexiondb
    {
        public int EditarTarifa(int id, Tarifas_Alquiler tarifas_Alquiler)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el cod
                cmd.CommandText = "UPDATE Tarifas_Alquiler SET tipo_auto = @tipo_auto, tarifaxauto = @tarifaxauto WHERE id_tipo = " + id;

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@tipo_auto", tarifas_Alquiler.tipo_auto));
                cmd.Parameters.Add(new MySqlParameter("@tarifaxauto", tarifas_Alquiler.tarifaxauto));

                //Abrimos conexion
                abrirConexion();
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                    return insertedId;

            }

            catch (Exception e)
            {
                throw;

            }
            finally
            {
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;
        }

        public int ActualizarEstado(int id, Flota_Carro flota_Carro)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el cod
                cmd.CommandText = "UPDATE Tarifas_Alquiler SET estado = @estado WHERE placa = " + id;

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@estado", flota_Carro.estado));
                

                //Abrimos conexion
                abrirConexion();
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                    return insertedId;

            }

            catch (Exception e)
            {
                throw;

            }
            finally
            {
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;

        }

    }
}