using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class VentaFlota : Conexiondb
    {
        public int registrarVenta(Ventas flota_Venta)
        {
            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO Flota_Venta (id, placa, precio) VALUES(@id,@placa,@precio)";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@placa", flota_Venta.id_vehiculo));
                cmd.Parameters.Add(new MySqlParameter("@precio", flota_Venta.total));
                cmd.Parameters.Add(new MySqlParameter("@precio", flota_Venta.id_cliente));




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
                throw;
            }
            finally
            {
                cerrarConexion();


            }

            return 0;


        }

        public int? obtenerVentaIdporPlaca(string placa)
        {
            int? codVenta = null;
            try
            {
                // Limpiamos parámetros
                cmd.Parameters.Clear();
                // Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;
                // Asignamos consulta a realizar
                cmd.CommandText = "SELECT cod_venta FROM flota_venta WHERE placa = @placa LIMIT 1";
                // Agregamos el parámetro
                cmd.Parameters.AddWithValue("@placa", placa);
                // Abrimos la conexión
                abrirConexion();
                // Ejecutamos la consulta y leemos el resultado
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        codVenta = reader.GetInt32("cod_venta");
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                // Cerramos la conexión
                cerrarConexion();
            }
            return codVenta;
        }


        //Metodo para agregar registro de venta
        public int venderCarro(FlotaVenta vendido) 
        {
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO ventas (venta_id, id_cliente, id_vehiculo, total) VALUES (@id_venta, @id_cliente, @id_vehiculo, @total)";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@id_vehiculo", vendido.placa));
                cmd.Parameters.Add(new MySqlParameter("@total", vendido.precio));
                cmd.Parameters.Add(new MySqlParameter("@id_venta", vendido.cod_venta));
                cmd.Parameters.Add(new MySqlParameter("@id_cliente", vendido.id_cliente));




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
                throw;
            }
            finally
            {
                cerrarConexion();
            }
            return 0;
        }


        //Metodo para cambiar la disponibilidad de un carro
        public int cambiarDisponibilidad(string placa, bool dispo)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.Text;

                //asignamos el cod
                cmd.CommandText = "UPDATE Flota_Carro SET disponibilidad = @disponibilidad WHERE placa = @placa";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@placa", placa));
                cmd.Parameters.Add(new MySqlParameter("@disponibilidad", dispo));


                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = cmd.ExecuteNonQuery();
                if (insertedId > 0)
                {
                    return insertedId;
                }


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
