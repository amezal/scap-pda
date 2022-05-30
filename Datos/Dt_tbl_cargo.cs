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
        IDataReader idr = null;
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        #region Metodos

        public ListStore listarCargos()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM LMBA.VwCargo");
            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    // El indice 0 es el id, pero no es necesario visualizarlo.
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString(), idr[3].ToString());
                   
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


        public ListStore buscarCargos(String query)
        {
            ListStore datos = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string)
            );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT ID, Cargo, Departamento, Descripcion From LMBA.VwCargo ");
            sb.Append("WHERE Cargo LIKE '" + query + "%';");

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
        }




        public Int32 getIdDep(string departamento)
        {
            int existe = 0;
            sb.Clear();
            sb.Append("Use LMBA;");
            sb.Append("SELECT idDepartamento from Departamento where nombreDepartamento = '" + departamento + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = Convert.ToInt32(idr["idDepartamento"]);
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }


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
            sb.Append("SELECT ID, Cargo, Descripcion, idDepartamento FROM LMBA.VwCargo ");
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
                    Descripcion = idr["Descripcion"].ToString(),
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

        public bool guardarCargo(Tbl_Cargo cargo)
        {
            bool guardado = false;
            int x = 0;
            sb.Clear();
            /*private String nombreCargo;
            private String descripcion;
            private Boolean estado;
            private Int32 idDepartamento;
            */

            sb.Append("INSERT INTO LMBA.Cargo");
            sb.Append("(nombreCargo, descripcion, estado, idDepartamento)");
            sb.Append("VALUES('" + cargo.NombreCargo + "','" + cargo.Descripcion + "','" + 1 + "','" + cargo.IdDepartamento + "');");

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public bool EliminarCargo(int idCargo)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control
            sb.Clear();
            sb.Append("UPDATE LMBA.Cargo SET ");
            sb.Append(
            "estado='" + 3 + "' " +
            "WHERE idCargo=" + idCargo + ";");

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

        public bool ModificarCargo(Tbl_Cargo tcar)
        {
            bool guardado = false; //Bandera
            int x = 0; //Variable de control

            sb.Clear();
            sb.Append("UPDATE LMBA.Cargo SET ");
            sb.Append(
            "nombreCargo='" + tcar.NombreCargo + "'," +
            "descripcion='" + tcar.Descripcion + "'," +
            "estado='" + tcar.Estado + "'," +
            "idDepartamento='" + tcar.IdDepartamento + 
            "' WHERE Cargo.idCargo= " + tcar.IdCargo + ";");

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

        public Dt_tbl_cargo()
        {
        }
    }
}
