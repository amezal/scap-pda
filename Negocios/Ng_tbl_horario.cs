﻿using System;
using System.Data;
using Gtk;
using System.Text;
using ScapProject0.Entidades;
using ScapProject0.Datos;

namespace ScapProject0.Negocios
{ 
    public class Ng_tbl_horario
        {

        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();

        public bool existe(string check, string column, int not = 0)
        {
            bool ex = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append($"SELECT * FROM LMBA.Horario WHERE {column}='{check}' AND idHorario <> '{not}'");

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


        public Ng_tbl_horario()
            {
            }
        }
}
