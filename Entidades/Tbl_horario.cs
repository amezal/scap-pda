using System;
namespace ScapProject0.Entidades
{
    public class Tbl_horario
    {
        private Int32 id_Horario;
        private string nombre;
        private DateTime horaInicio;
        private DateTime horaSalida;
        private Int32 estado;


        public Tbl_horario()
        {
        }

        public int Id_Horario { get => id_Horario; set => id_Horario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
