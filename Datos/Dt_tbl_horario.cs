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
        public ListStore ListarHorario()
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string));
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


            //public Dt_tbl_horario()
            //{
            //}
        }

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

        public bool GuardarHorario(Tbl_horario thor)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("INSERT INTO LMBA.Horario ");
            sb.Append("(nombre, horaInicio, horaSalida, estado) ");
            sb.Append("VALUES ('" + thor.Nombre + "','" + thor.HoraInicio.ToString("H:mm:ss") + "','" + thor.HoraSalida.ToString("H:mm:ss") + "','" + 1 +"')" );

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
        #endregion

    }
}