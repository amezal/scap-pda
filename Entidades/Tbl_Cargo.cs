using System;
namespace ScapProject0.Entidades
{
    public class Tbl_Cargo
    {
        private Int32 idCargo;
        private String nombreCargo;
        private String descripcion;
        private Int32 estado;
        private Int32 idDepartamento;
        private Int32 idEmpCar;

        public int IdCargo { get => idCargo; set => idCargo = value; }
        public string NombreCargo { get => nombreCargo; set => nombreCargo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Estado { get => estado; set => estado = value; }
        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public int IdEmpCar { get => idEmpCar; set => idEmpCar = value; }
    }
}
