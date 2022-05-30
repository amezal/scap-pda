using System;
using Gtk;
using System.Text;
using ScapProject0.Entidades;
using System.Collections.Generic;
using System.Data;
using System;

namespace ScapProject0.Datos
{
    public class Dt_tbl_rolOpcion
    {
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public ListStore ListarRolOpcion(int idRol)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            sb.Clear();
            sb.Append("USE LMBA; ");
            sb.Append("SELECT opcion.opcion AS Opcion, rolOpcion.* ");
            sb.Append("FROM LMBA.rolOpcion INNER JOIN opcion ON opcion.id_opcion = rolOpcion.id_opcion ");
            sb.Append($"WHERE id_rol='{idRol}';");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString(), idr[3].ToString());
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

        public bool NuevoRolOpcion(Tbl_rolOpcion rolOp)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("USE LMBA; ");
            sb.Append("INSERT INTO rolOpcion ");
            sb.Append("(id_rol, id_opcion) VALUES");
            sb.Append($"('{rolOp.Id_rol}', '{rolOp.Id_opcion}');");
            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                }
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("DT: ERROR= " + e.Message);
                Console.WriteLine("DT: ERROR= " + e.StackTrace);
                return false;
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
            return guardado;
        }
    }
}
