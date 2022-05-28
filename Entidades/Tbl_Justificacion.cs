using System;
namespace ScapProject0.Entidades
{
    public class Tbl_Justificacion
    {
        private int idJustificacion;
        private int estado;
        private string descripcion;
        private DateTime fechaEntrada;
        private DateTime fechaSalida;
        private DateTime horaEntrada;
        private DateTime horaSalida;

        public int IdJustificacion { get => idJustificacion; set => idJustificacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
    }
}
