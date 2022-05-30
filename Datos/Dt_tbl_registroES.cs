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
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT VwRegistro.*, ");
            sb.Append("CONCAt(j.descripcion, ' ', j.horaEntrada, ' - ', j.horaSalida) AS Justificacion ");
            sb.Append("FROM VwRegistro LEFT JOIN Justificacion j ");
            sb.Append("ON j.idJustificacion = VwRegistro.idJustificacion ");
            sb.Append($"WHERE idEmpleado = '{idEmpleado}';");

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
                    string justificacion = idr["Justificacion"].ToString();

                    datos.AppendValues(id, fecha, horaEntrada.ToString(),
                    horaSalida.ToString(), horasTrabajadas.ToString(),
                        horasExtra.ToString(), entradaH.ToString(), salidaH.ToString(), justificacion);
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

        public int UltimoRegistro(int idEmp)
        {
            int idReg;
            IDataReader idr = null;
            sb.Clear();
            sb.Append($"SELECT Max(idRegistro) FROM LMBA.VwRegistro WHERE idEmpleado='{idEmp}';");
            Console.WriteLine(sb.ToString());

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();
                idReg = Convert.ToInt32(idr[0]);
                Console.WriteLine(idReg);
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
            return idReg;
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

        public int NuevoRegistro(Tbl_registroES reg)
        {
            int idReg = -1;
            IDataReader idr = null;

            sb.Clear();
            sb.Append("USE LMBA; ");
            sb.Append("INSERT INTO registroES ");
            sb.Append("(estado, fecha, horaEntrada) VALUES");
            sb.Append($"('1', '{reg.Fecha.ToString("yyyy-MM-dd")}', '{reg.HoraEntrada.ToString("HH:mm:ss")}'); ");
            sb.Append($"SELECT Max(idRegistro) FROM LMBA.registroES;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();
                idReg = Convert.ToInt32(idr[0]);
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
            return idReg;
        }

        public bool MarcarSalida(Tbl_registroES reg)
        {
            int x = 0;
            bool guardado = false;
            IDataReader idr = null;
            //UPDATE `LMBA`.`registroES` SET `horaEntrada` = '02:47:25' WHERE (`idRegistro` = '18');
            sb.Clear();
            //sb.Append("USE LMBA; ");
            sb.Append("UPDATE LMBA.registroES ");
            sb.Append($"SET horaSalida = '{reg.HoraSalida.ToString("HH:mm:ss")}' ");
            sb.Append($"WHERE idRegistro = '{reg.IdRegistro}';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();
                if(x > 0)
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
