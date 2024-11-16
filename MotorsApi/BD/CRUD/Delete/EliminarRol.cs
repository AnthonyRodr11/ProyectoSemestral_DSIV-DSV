﻿using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Delete
{
    public class EliminarRol : Conexiondb
    {
         public int RolEliminar(Usuario usuario)
        {

            //declaracion de variable de trabajo 
            int insercion;


            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType =CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "DELETE FROM Usuario WHERE id = @id";

                //Agregar parametros 
                cmd.Parameters.Add(new MySqlParameter("@id", usuario.id));


                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insercion > 0)
                    return insercion;
            }
            catch (Exception e)
            {

                Console.WriteLine("No se pudo registrar el Auto" + e);
            }
            finally {
                
                //Cerramos conexion
                cmd.Connection.Close(); 
            }
            return 0;
        }









    }
}
