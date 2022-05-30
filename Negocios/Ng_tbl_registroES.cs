using System;
using System.Data;
using Gtk;
using System.Text;
using ScapProject0.Entidades;
using ScapProject0.Datos;

namespace ScapProject0.Negocios
{
    public class Ng_tbl_registroES
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();

        public bool existe(string column, string check, int idEmp)
        {
            bool ex = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append($"SELECT * FROM LMBA.VwRegistro WHERE {column}='{check}' AND idEmpleado = '{idEmp}'");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    ex = true;
                }
                return ex;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo
    }
}
