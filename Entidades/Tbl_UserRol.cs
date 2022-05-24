using System;
namespace ScapProject0.Entidades
{
    public class Tbl_UserRol
    {
        private Int32 id_userRol;
        private Int32 id_user;
        private Int32 id_rol;

        public int Id_userRol { get => id_userRol; set => id_userRol = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
    }
}
