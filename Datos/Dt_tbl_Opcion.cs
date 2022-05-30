using Gtk;
using System.Text;
using ScapProject0.Entidades;
using System.Collections.Generic;
using System.Data;
using ScapProject0.Datos;
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

        public ListStore listarOpcion(String query)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.vwOpcion");
            sb.Append(" WHERE Opcion LIKE '" + query + "%';");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                   idr[2].ToString());

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

        public Tbl_opcion DatosOpcion(int idOpc)
        {

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID Opcion, Opcion, Estado FROM LMBA.vwOpcion ");
            sb.Append("WHERE ID = " + idOpc + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_opcion opc = new Tbl_opcion()
                {
                    Id_opcion = (Int32)idr["ID Opcion"],
                    Opcion = idr["Opcion"].ToString(),
                    Estado = (Int32)idr["Estado"]

                };

                idr.Close();

                return opc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
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


        public bool EliminarOpcion(int idOpc)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE LMBA.opcion SET ");
            sb.Append(
            "estado='" + 3 + "' " +
            "WHERE id_opcion=" + idOpc + ";");

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
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("DT: ERROR= " + e.Message);
                Console.WriteLine("DT: ERROR= " + e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public bool ModificarOpcion(Tbl_opcion topc)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("UPDATE LMBA.opcion SET ");
            sb.Append(
            "opcion='" + topc.Opcion + "'," +
            "estado='" + topc.Estado +
            "' WHERE id_opcion= " + topc.Id_opcion + ";");

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
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("DT: ERROR= " + e.Message);
                Console.WriteLine("DT: ERROR= " + e.StackTrace);
                throw;
            }

            finally
            {
                con.CerrarConexion();
            }
        }


    }
}



