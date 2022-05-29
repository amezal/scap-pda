using System;
using System.Data;
using Gtk;
using System.Text;
using ScapProject0.Entidades;

namespace ScapProject0.Datos
{
    public class Dt_tbl_empleadoRegistro
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public bool NuevoEmpReg(Tbl_empleadoRegistro empReg)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            //INSERT INTO `LMBA`.`registroES` (`estado`, `fecha`) VALUES('1', '');

            sb.Append("USE LMBA; ");
            sb.Append("INSERT INTO empleadoRegistro ");
            sb.Append("(idRegistro, idEmpleado) VALUES");
            sb.Append($"('{empReg.IdRegistro}', '{empReg.IdEmpleado}');");
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
