using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_user
    {
        //Atributos
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarUser()
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwUser;");

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

        public List<Tbl_user> cbxUser()
        {
            //List<Tbl_Departamento> listaDpto = new List<Tbl_Departamento>()
            List<Tbl_user> listUser = new List<Tbl_user>(); 

            //ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT id_user, firstNombre, firstApellido FROM LMBA.VwUser;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_user tus = new Tbl_user()
                    {
                        Id_user = (Int32)idr["id_user"],
                        Nombres = idr["firstNombre"].ToString()

                    };
                    listUser.Add(tus);


                    //datos.AppendValues(idr[0].ToString(), String.Concat(idr[1].ToString(), " ", idr[2].ToString()));
                }
                idr.Close();
                return listUser;
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
        /*
         * List<Tbl_Departamento> listaDpto = new List<Tbl_Departamento>();
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
         * 
         *         
         * public ListStore cbxeEmpleados()
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
         */

        public Tbl_user DatosUser(int idUser)
        {
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwUser ");
            sb.Append("WHERE id_user=" + idUser + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_user user = new Tbl_user()
                {
                    Id_user = (Int32)idr["id_user"],
                    Pwd = idr["pwd"].ToString()
                };

                idr.Close();
                return user;
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


        public Dt_tbl_user()
        {
        }
    }
}
