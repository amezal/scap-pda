using System;
namespace ScapProject0.Entidades
{
    public class Tbl_opcion
    {
        private Int32 id_opcion;
        private String opcion;
        private Int32 estado;

        public int Id_opcion { get => id_opcion; set => id_opcion = value; }
        public string Opcion { get => opcion; set => opcion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
