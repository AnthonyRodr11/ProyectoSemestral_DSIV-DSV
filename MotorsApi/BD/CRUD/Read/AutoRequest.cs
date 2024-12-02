using MotorsApi.Models;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotorsApi.BD.CRUD.Read
{
    public class AutoRequest : Conexiondb
    {

        //Metodo para traer informacion del auto
        public AutoDetallesRequest autoInfo(string placa)
        {
            AutoDetallesRequest auto = new AutoDetallesRequest();

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "sp_obtener_carro_info";

                cmd.Parameters.Add(new MySqlParameter("@p_placa", placa));

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        {
                            
                            auto.marca = reader["marca"].ToString();
                            auto.modelo = reader["modelo"].ToString();
                            auto.foto = reader["foto"].ToString();
                            auto.tarifa = Convert.ToDouble(reader["tarifaxauto"]);
                        }


                    }
                }
            }
            catch (Exception ex) { 
                
                
                throw; 
            }


            finally { cerrarConexion(); }
            return auto;
        }
    }
}
