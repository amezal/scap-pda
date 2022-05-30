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
        public ListStore ListarUser(string query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwUser ");
            sb.Append("WHERE Username LIKE '" + query + "%';");


            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                        idr[2].ToString(), idr[3].ToString(), idr[4].ToString(), idr[5].ToString());
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
                    Nombres = idr["Nombre"].ToString(),
                    Apellidos = idr["Apellido"].ToString(),
                    Email = idr["email"].ToString(),
                    User = idr["Username"].ToString(),
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
        public List<Tbl_user> cbxUser()
        {
            //List<Tbl_Departamento> listaDpto = new List<Tbl_Departamento>()
            List<Tbl_user> listUser = new List<Tbl_user>();

            //ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT id_user, Username FROM LMBA.VwUser;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_user tus = new Tbl_user()
                    {
                        Id_user = (Int32)idr["id_user"],
                        Nombres = idr["Username"].ToString()

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

        public bool NuevoUser(Tbl_user tus)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("INSERT INTO LMBA.user ");
            sb.Append("(nombres, apellidos, email, user, pwd, estado)");
            sb.Append("VALUES ('" +
            tus.Nombres + "','" +
            tus.Apellidos + "','" +
            tus.Email + "','" +
            tus.User + "','" +
            tus.Pwd + "','" +
            1+ "');");

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

        public bool ModificarUser(Tbl_user tus)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE LMBA.user SET ");
            sb.Append(
            "nombres ='" + tus.Nombres + "'," +
            "apellidos ='" + tus.Apellidos + "'," +
            "email ='" + tus.Email + "'," +
            "user ='" + tus.User + "'," +
            "pwd ='" + tus.Pwd + "'," +
            "estado='" + 2 + "'," +
            "' WHERE user.id_user = " + tus.Id_user + ";");

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

        public bool EliminarUser(int idUser)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE LMBA.user SET ");
            sb.Append(
            "estado='" + 3 + "' " +
            "WHERE id_user=" + idUser + ";");

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


        #endregion


        public Dt_tbl_user()
        {
        }
    }
}
