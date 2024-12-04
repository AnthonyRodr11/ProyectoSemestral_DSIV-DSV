﻿using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Delete
{
    public class EliminarRol : Conexiondb
    {
         public int rolEliminar(string correo)
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
                cmd.CommandText = "DELETE FROM login WHERE correo = @correo";

                //Agregar parametros 
                cmd.Parameters.Add(new MySqlParameter("@correo", correo));

                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insercion > 0)
                    return insercion;
            }
            catch (Exception e)
            {
                throw;
            }
            finally {
                
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;
        }









    }
}
