using System;
using System.Data;
using System.Text;
using ScapProject0.Datos;
namespace ScapProject0.Negocios
{
    public class Ng_tbl_rolOpcion
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();

        public bool existe(int idRol, int idOpcion)
        {
            bool ex = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append($"SELECT * FROM LMBA.rolOpcion WHERE id_rol={idRol} AND id_opcion={idOpcion}");
            //Console.WriteLine(sb.ToString());
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
