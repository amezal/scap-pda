using Gtk;
using System.Text;
using ScapProject0.Entidades;
using System.Collections.Generic;
using System.Data;
using System;

namespace ScapProject0.Datos
{
    public class Dt_tbl_Opcion
    {
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public Dt_tbl_Opcion()
        {

        }

        public ListStore listarOpcion()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT id_opcion, opcion FROM LMBA.opcion");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString());

                } //end while
                return datos;

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
                con.CerrarConexion();
            }
        }

        public ListStore buscarOpcion(String query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT id_opcion, opcion from LMBA.opcion ");
            sb.Append("WHERE opcion LIKE '" + query + "%';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString());
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

        public bool guardarOpcion(Tbl_opcion opc)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();
           
            sb.Append("INSERT INTO LMBA.opcion");
            sb.Append("(opcion, estado)");
            sb.Append("VALUES('" + opc.Opcion + "',' " + opc.Estado + "');");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                if (x > 0)
                {
                    guardado = true;
                }
                return guardado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.CerrarConexion();
            }
        }

    }
}



