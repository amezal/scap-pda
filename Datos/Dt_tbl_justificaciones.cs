using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using System.Collections.Generic;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_justificaciones
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public bool NuevaJustificacion(Tbl_Justificacion tjus)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("INSERT INTO LMBA.Justificacion ");
            sb.Append("(estado, descripcion, fechaEntrada, fechaSalida, horaEntrada, horaSalida) ");
            sb.Append("VALUES ('" +
            tjus.Estado + "', '" +
            tjus.Descripcion + "', '" +
            tjus.FechaEntrada.ToString("yyyy-MM-dd") + "', '" +
            tjus.FechaSalida.ToString("yyyy-MM-dd") + "', '" +
            tjus.HoraEntrada.TimeOfDay.ToString() + "', '" +
            tjus.HoraSalida.TimeOfDay.ToString() + "');");

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
