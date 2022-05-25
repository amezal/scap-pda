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
        public ListStore ListarEmpleados(String query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)
            );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Nombres, Apellidos, Cargo, Departamento From LMBA.VwEmpleado ");
            sb.Append("WHERE concat(Nombres, Apellidos) LIKE '" + query + "%';");

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
            sb.Append("SELECT Empleado.*, VwEmpleado.idDepartamento FROM LMBA.Empleado, LMBA.VwEmpleado ");
            sb.Append("WHERE ID=" + idEmp + " AND idEmpleado=" + idEmp + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_Empleado emp = new Tbl_Empleado()
                {
                    IdEmpleado = (Int32)idr["idEmpleado"],
                    NumCedula = idr["numCedula"].ToString(),
                    //Estado = (Int32)idr["estado"],
                    PrimerNombre = idr["primerNombre"].ToString(),
                    SegundoNombre = idr["segundoNombre"].ToString(),
                    PrimerApellido = idr["primerApellido"].ToString(),
                    SegundoApellido = idr["segundoApellido"].ToString(),
                    FechaNacimiento = DateTime.Parse(idr["fechaNacimiento"].ToString()),
                    FechaIngreso = DateTime.Parse(idr["fechaIngreso"].ToString()),
                    Sexo = idr["sexo"].ToString().Equals("1") ? true : false,
                    Telefono = idr["telefono"].ToString(),
                    EmailCorporativo = idr["emailCorporativo"].ToString(),
                    EmailPersonal = idr["emailPersonal"].ToString(),
                    Direccion = idr["direccion"].ToString(),
                    Observacion = idr["observacion"].ToString(),
                    IdCargo = (Int32)idr["idCargo"],
                    //Id_user = (Int32)idr["id_user"],
                    PIN = idr["PIN"].ToString(),
                    IdHorario = (Int32)idr["idHorario"],
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
