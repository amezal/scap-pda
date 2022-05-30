using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_rol
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public ListStore ListarRoles(String query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string)
            );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * From LMBA.VwRol ");
            sb.Append($"WHERE Rol LIKE '{query}%';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                        idr[2].ToString());
                    Console.WriteLine(idr[1].ToString());
                }
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                idr.Close();
            }

            return datos;
        }
    }
}

