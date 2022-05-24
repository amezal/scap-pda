using System;
namespace ScapProject0.Entidades
{
    public class Tbl_rol
    {
        private Int32 id_rol;
        private String rol;
        private Int32 estado;

        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
