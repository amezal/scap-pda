using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using ScapProject0.Entidades;
using System.Collections.Generic;
namespace ScapProject0.Datos
{
    public class Dt_tbl_cargo
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        #region Metodos

        public ListStore listarCargos()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwCargo");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString());
                   
                } //end while
                return datos;

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
                con.CerrarConexion();
            }
        }
        #endregion

        public List<Tbl_Cargo> cbxCargo()
        {
            List<Tbl_Cargo> listaCargo = new List<Tbl_Cargo>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwCargo;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_Cargo tcar = new Tbl_Cargo()
                    {
                        IdCargo = (Int32)idr["ID"],
                        NombreCargo = idr["Cargo"].ToString()
                    };
                    listaCargo.Add(tcar);
                }
                idr.Close();
                return listaCargo;
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

        public Tbl_Cargo DatosCargo(int idCargo)
        {

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Cargo, idDepartamento FROM LMBA.VwCargo ");
            sb.Append("WHERE ID = " + idCargo + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                idr.Read();

                Tbl_Cargo car = new Tbl_Cargo()
                {
                    IdCargo = (Int32)idr["ID"],
                    NombreCargo = idr["Cargo"].ToString(),
                    IdDepartamento = (Int32)idr["idDepartamento"]
                };

                idr.Close();

                return car;
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


        public Dt_tbl_cargo()
        {
        }
    }
}
