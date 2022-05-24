using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;

namespace ScapProject0.Datos
{
    public class Conexion
    {

        #region atributos
        private String cadena = String.Empty;
        private MySqlConnection con { get; set; }
        private MySqlCommand sqlCommand { get; set; }
        private IDataReader idr { get; set; }
        #endregion

        #region metodos
        public string CadenaConexion()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Database = "LMBA";
            sb.UserID = "root";
            sb.Password = "Temporal2022+";
            return sb.ConnectionString;

        }

        public void AbrirConexion()
        {
            MessageDialog ms = null;
            if (con.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                con.ConnectionString = cadena;
                try
                {
                    con.Open();

                    //ms = new MessageDialog(null, DialogFlags.Modal,
                        //MessageType.Info, ButtonsType.Ok, "Se abrio la conexion a la BD Seguridad");
                    //ms.Run();
                    //ms.Destroy();
                    Console.WriteLine("Se conectó a la BD HR");
                }
                catch (Exception e)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, e.Message);
                    ms.Run();
                    ms.Destroy();
                    Console.WriteLine("ERROR: " + e);
                }//fin try-catch
            }//fin if-else
        }//fin del metodo

        public void CerrarConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                return;
            }
            else
            {
                con.Close();
            }
        }//fin del metodo

        public IDataReader Leer(CommandType ct, string consulta)
        {
            idr = null;
            sqlCommand.Connection = con;
            sqlCommand.CommandType = ct;
            sqlCommand.CommandText = consulta;
            try
            {
                idr = sqlCommand.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return idr;
        }//fin del metodo

        public Int32 Ejecutar(CommandType ct, string consulta)
        {
            int retorno = 0;
            sqlCommand.Connection = con;
            sqlCommand.CommandType = ct;
            sqlCommand.CommandText = consulta;
            try
            {
                retorno = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }//fin try-catch
            return retorno;
        }//fin del metodo

        #endregion

        #region constructor
        public Conexion()
        {
            cadena = CadenaConexion();
            con = new MySqlConnection();
            sqlCommand = new MySqlCommand();
        }
        #endregion
    }
}
