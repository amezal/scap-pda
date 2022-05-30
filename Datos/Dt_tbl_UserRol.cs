using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using ScapProject0.Entidades;
using System.Collections.Generic;


namespace ScapProject0.Datos
{
    public class Dt_tbl_UserRol
    {
        Conexion con = new Conexion();
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public ListStore listarUserRol()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.vwUserRol");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    // El indice 0 es el id, pero no es necesario visualizarlo.
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString());

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

        public Int32 getIdUser(string user)
        {
            int existe = 0;
            sb.Clear();
            sb.Append("Use LMBA;");
            sb.Append("SELECT id_user from user where user = '" + user + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = Convert.ToInt32(idr["id_user"]);
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }

        public Int32 getIdRol(string rol)
        {
            int existe = 0;
            sb.Clear();
            sb.Append("Use LMBA;");
            sb.Append("SELECT id_rol from rol where id_rol = '" + rol + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = Convert.ToInt32(idr["id_rol"]);
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }

        public List<Tbl_user> cbxUser()
        {
            List<Tbl_user> listaUser = new List<Tbl_user>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwUser;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_user tus = new Tbl_user()
                    {
                        Id_user = (Int32)idr["id_User"],
                         User = idr["Username"].ToString()
                    };
                    listaUser.Add(tus);
                }
                idr.Close();
                return listaUser;
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
        public List<Tbl_rol> cbxRol()
        {
            List<Tbl_rol> listaRol = new List<Tbl_rol>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.rol;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_rol tro = new Tbl_rol()
                    {
                        Id_rol = (Int32)idr["id_rol"],
                        Rol = idr["rol"].ToString()
                    };
                    listaRol.Add(tro);
                }
                idr.Close();
                return listaRol;
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

        public Tbl_UserRol DatosUserRol(int idUserRol)
        {

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID_UserRol, ID_Usuario, ID_Rol FROM LMBA.vwUserRol ");
            sb.Append("WHERE ID = " + idUserRol + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_UserRol ur = new Tbl_UserRol
                {
                    
                    Id_userRol = (Int32)idr["ID_UserRol"],
                    Id_user= (Int32)idr["ID_Usuario"],
                    Id_rol = (Int32)idr["ID_Rol"]
                };

                idr.Close();

                return ur;
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

        public bool guardarUserRol(Tbl_UserRol userRol)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();


            sb.Append("INSERT INTO LMBA.userRol");
            sb.Append("(id_rol, id_user)");
            sb.Append("VALUES('" + userRol.Id_rol + "','" + userRol.Id_user + "');");

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

        public Dt_tbl_UserRol()
        {
        }
    }
}
