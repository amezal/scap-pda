using System;
namespace ScapProject0.Entidades
{
    public class Tbl_empleadoRegistro
    {
        private Int32 idEmpleadoRegistro;
        private Int32 idRegistro;
        private Int32 numCedula;

        public int IdEmpleadoRegistro { get => idEmpleadoRegistro; set => idEmpleadoRegistro = value; }
        public int IdRegistro { get => idRegistro; set => idRegistro = value; }
        public int NumCedula { get => numCedula; set => numCedula = value; }
    }
}
