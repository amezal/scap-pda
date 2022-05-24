using System;
namespace ScapProject0.Entidades
{
    public class Tbl_Empleado
    {
        private Int32 idEmpleado;
        private String numCedula;
        private Boolean estado;
        private String primerNombre;
        private String segundoNombre;
        private String primerApellido;
        private String segundoApellido;
        private DateTime fechaNacimiento;
        private Boolean sexo;
        private DateTime fechaIngreso;
        private String direccion;
        private String observacion;
        private String fotoEmpleado;
        private String telefono;
        private String emailPersonal;
        private String emailCorporativo;
        private Int32 idCargo;
        private Int32 idDepartamento;

        public string NumCedula { get => numCedula; set => numCedula = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public bool Sexo { get => sexo; set => sexo = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string FotoEmpleado { get => fotoEmpleado; set => fotoEmpleado = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string EmailPersonal { get => emailPersonal; set => emailPersonal = value; }
        public string EmailCorporativo { get => emailCorporativo; set => emailCorporativo = value; }
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int IdCargo { get => idCargo; set => idCargo = value; }
        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
    }
}
