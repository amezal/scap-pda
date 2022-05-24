using System;
namespace ScapProject0.Entidades
{
    public class Tbl_Departamento
    {
        private Int32 idDepartamento;
        private String nombreDepartamento;
        private String ext;
        private String email;
        private Boolean estado;

        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
        public string Ext { get => ext; set => ext = value; }
        public string Email { get => email; set => email = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
