using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;
using Gtk;

namespace ScapProject0.Datos
{
    public class Dt_tbl_departamento
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        #region Metodos

        public ListStore ListarDpto()
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * From LMBA.VwDepartamento;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), 
                    idr[2].ToString(), idr[3].ToString());
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

        public List<Tbl_Departamento> cbxDpto()
        {
            List<Tbl_Departamento> listaDpto = new List<Tbl_Departamento>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Departamento FROM LMBA.VwDepartamento;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_Departamento tdep = new Tbl_Departamento()
                    {
                        IdDepartamento = (Int32)idr["ID"],
                        NombreDepartamento = idr["Departamento"].ToString()
                    };
                    listaDpto.Add(tdep);
                }
                idr.Close();
                return listaDpto;
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

        public bool guardarDpto(Tbl_Departamento dpto)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();


            sb.Append("INSERT INTO LMBA.Departamento");
            sb.Append("(nombreDepartamento, ext, email, estado)");
            sb.Append("VALUES('" + dpto.NombreDepartamento + "','" + dpto.Ext + "','" + dpto.Email + "','" + 1+ "');");

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

        #endregion


        public Dt_tbl_departamento()
        {
        }
    }
}
