using System;
namespace ScapProject0.Entidades
{
    public class Tbl_rolOpcion
    {
        private Int32 id_rolOpcion;
        private Int32 id_rol;
        private Int32 id_opcion;

        public int Id_rolOpcion { get => id_rolOpcion; set => id_rolOpcion = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Id_opcion { get => id_opcion; set => id_opcion = value; }
    }
}
