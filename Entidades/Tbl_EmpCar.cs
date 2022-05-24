using System;
namespace ScapProject0.Entidades
{
    public class Tbl_EmpCar
    {
        private Int32 idEmpCar;
        private Boolean estado;
        private String numCedula;

        public int IdEmpCar { get => idEmpCar; set => idEmpCar = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string NumCedula { get => numCedula; set => numCedula = value; }
    }
}
