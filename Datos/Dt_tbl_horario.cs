using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;


namespace ScapProject0.Datos
{
    public class Dt_tbl_horario
    {
        //Atributos
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarHorario(string query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwHorario;");

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


            //public Dt_tbl_horario()
            //{
            //}
        }
        /*
        public List<Tbl_horario> CbxHorario()
        {
            List<Tbl_horario> listaHorario = new List<Tbl_horario>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwHorario;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_horario thor = new Tbl_horario()
                    {
                        Id_Horario = (Int32)idr["idHorario"],
                        Nombre = idr["nombre"].ToString()
                    };
                    listaHorario.Add(thor);
                }
                idr.Close();
                return listaHorario;
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
        */



        public bool GuardarHorario(Tbl_horario thor)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("INSERT INTO LMBA.Horario ");
            sb.Append("(nombre, horaInicio, horaSalida, almuerzo, estado) ");
            sb.Append("VALUES ('" 
                        + thor.Nombre + "','" +
                        thor.HoraInicio.ToString("H:mm:ss") + "','" +
                        thor.HoraSalida.ToString("H:mm:ss") + "','" +
                        thor.Almuerzo.ToString("H:mm:ss") + "','" +
                        1 + "','"+
                         "')" );

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if(x > 0)
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


        public bool ModHorario(Tbl_horario temp)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE INTO LMBA.Horario ");
            sb.Append("(nombre = '" + temp.Nombre + "'," +
                    "horaInicio = '" + temp.HoraInicio.ToString("H:mm:ss") + "',"  +
                    "horaSalida = '" + temp.HoraSalida.ToString("H:mm:ss") + "'," +
                    "almuerzo = '" + temp.Almuerzo.ToString("H:mm:ss") + "'," +
                    "estado = '" + 2 +
                     "'WHERE Horario.idHorario = " + temp.Id_Horario + ";");

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


        public bool DeleteHor(int idHOR)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE LMBA.Horario SET ");
            sb.Append(
            "estado='" + 3 + "' " +
            "WHERE idHorario=" + idHOR + ";");

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

        public Tbl_horario DatosHorario(int idHor)
        {
            //Tbl_Empleado emp = new Tbl_Empleado();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT Horario.* FROM LMBA.Empleado");
            sb.Append("WHERE idHorario=" + idHor +";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_horario hor = new Tbl_horario()
                {
                    Id_Horario= (Int32)idr["idHorario"],
                    Nombre = idr["nombre"].ToString(),
                    HoraInicio = (DateTime)idr["horaInicio"],
                    HoraSalida = (DateTime)idr["horaSalida"],
                    Almuerzo = (DateTime)idr["almuerzo"]


                };

                idr.Close();
                return hor;
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

    }
}