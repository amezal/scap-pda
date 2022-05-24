using System;
namespace ScapProject0.Entidades
{
    public class Tbl_registroES
    {
        private Int32 idRegistro;
        private DateTime fecha;
        private DateTime horaEntrada;
        private DateTime horaSalida;

        public int IdRegistro { get => idRegistro; set => idRegistro = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
    }
}
