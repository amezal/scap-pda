using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_empleado
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region Metodos
        public ListStore ListarEmpleados()
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)
            );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Nombres, Apellidos, Cargo, Departamento From LMBA.VwEmpleado;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                        idr[2].ToString(), idr[3].ToString(), idr[4].ToString());
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

        public ListStore cbxeEmpleados()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Nombres, Apellidos FROM LMBA.VwEmpleado;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), String.Concat(idr[1].ToString(), " ", idr[2].ToString()));
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, e.Message);
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

        public Tbl_Empleado DatosEmpleado(int idEmp)
        {
            //Tbl_Empleado emp = new Tbl_Empleado();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwEmpleado ");
            sb.Append("WHERE ID=" + idEmp + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_Empleado emp = new Tbl_Empleado()
                {
                    IdEmpleado = (Int32)idr["ID"],
                    NumCedula = idr["Cedula"].ToString(),
                    PrimerNombre = idr["Nombres"].ToString().Split(' ')[0],
                    SegundoNombre = idr["Nombres"].ToString().Split(' ')[1],
                    PrimerApellido = idr["Apellidos"].ToString().Split(' ')[0],
                    SegundoApellido = idr["Apellidos"].ToString().Split(' ')[1],
                    Telefono = idr["Telefono"].ToString(),
                    EmailCorporativo = idr["Email"].ToString(),
                    IdCargo = (Int32)idr["idCargo"],
                    IdDepartamento = (Int32)idr["idDepartamento"]
                };

                idr.Close();
                return emp;
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


        #endregion


        public Dt_tbl_empleado()
        {
        }
    }
}
