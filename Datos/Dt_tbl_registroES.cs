using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_registroES
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public ListStore ListarRegistros(int idEmpleado)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)
            );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * From LMBA.VwRegistro ");
            sb.Append("WHERE idEmpleado = " + idEmpleado + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    var id = idr["idRegistro"].ToString();
                    var fecha = idr["fecha"].ToString().Split(' ')[0];
                    TimeSpan horaEntrada = TimeSpan.Parse(idr["horaEntrada"].ToString());
                    TimeSpan horaSalida = TimeSpan.Parse(idr["horaSalida"].ToString());
                    TimeSpan entradaH = TimeSpan.Parse(idr["entradaH"].ToString());
                    TimeSpan salidaH = TimeSpan.Parse(idr["salidaH"].ToString());
                    TimeSpan almuerzo = TimeSpan.Parse(idr["almuerzo"].ToString());
                    TimeSpan horasNecesitadas = salidaH.Subtract(entradaH).Subtract(almuerzo);
                    TimeSpan horasTrabajadas = horaSalida.Subtract(horaEntrada).Subtract(almuerzo);
                    TimeSpan horasExtra = horasTrabajadas.Subtract(horasNecesitadas);

                    datos.AppendValues(id, fecha, horaEntrada.ToString(),
                    horaSalida.ToString(), horasTrabajadas.ToString(),
                        horasExtra.ToString(), entradaH.ToString(), salidaH.ToString());
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
    
        public bool Justificar(List<int> ids, int idJustificacion)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("USE LMBA; ");
            ids.ForEach((id) =>
            {
                sb.Append("UPDATE registroES ");
                sb.Append($"INNER JOIN Justificacion ON Justificacion.idJustificacion = {idJustificacion} ");
                sb.Append("SET registroES.idJustificacion = Justificacion.idJustificacion ");
                sb.Append($"WHERE registroES.idRegistro = {id} ");
                sb.Append("AND registroES.fecha >= Justificacion.fechaEntrada ");
                sb.Append("AND registroES.fecha <= Justificacion.fechaSalida; ");
            });

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
