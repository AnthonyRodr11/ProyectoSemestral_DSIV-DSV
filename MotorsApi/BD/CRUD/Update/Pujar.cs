using MotorsApi.Models;
using MySql.Data.MySqlClient;

namespace MotorsApi.BD.CRUD.Update
{
    public class Pujar : Conexiondb
    {
        public int InsertarPuja(int usuario, SubastaRequest deuda)
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"UPDATE flota_subasta 
                                    id_usuario, valor_puja
                                SET
                                    id_usuario = @id_usuario, valor_puja = @valor_puja
                                WHERE
                                    id_placa = @placa;
";
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", usuario));
                cmd.Parameters.Add(new MySqlParameter("@valor_puja", deuda.valor_puja));
                cmd.Parameters.Add(new MySqlParameter("@placa", deuda.id_placa));

                abrirConexion();

                var guardar = cmd.ExecuteNonQuery();
                if (guardar > 0)
                    return guardar;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { cerrarConexion(); }
            return 0;
            
        }
    }
}
