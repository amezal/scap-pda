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

        public Tbl_rol DatosRol(int idRol)
        {
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwRol ");
            sb.Append($"WHERE ID='{idRol}';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();
                Tbl_rol rol = new Tbl_rol()
                {
                    Estado = 1,
                    Id_rol = Convert.ToInt32(idr["ID"]),
                    Rol = idr["Rol"].ToString()
                };
                idr.Close();
                return rol;
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

        public bool ModificarRol(Tbl_rol rol)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            //INSERT INTO `LMBA`.`registroES` (`estado`, `fecha`) VALUES('1', '');

            sb.Append("USE LMBA; ");
            sb.Append($"UPDATE rol SET estado='2', rol='{rol.Rol}' ");
            sb.Append($"WHERE id_rol = {rol.Id_rol}");
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

        public bool Eliminar(int idRol)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("USE LMBA; ");
            sb.Append($"UPDATE rol SET estado='3' ");
            sb.Append($"WHERE id_rol = {idRol}");
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

        public bool Nuevo(Tbl_rol rol)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("USE LMBA; ");
            sb.Append($"INSERT INTO rol (rol, estado) VALUES ");
            sb.Append($"('{rol.Rol}', '1');");

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

