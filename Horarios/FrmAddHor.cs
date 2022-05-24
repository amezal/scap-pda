using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.Horarios
{
    public partial class FrmAddHor : Gtk.Window
    {
        Tbl_horario thor = new Tbl_horario();
        Dt_tbl_horario dthor = new Dt_tbl_horario();

        public FrmAddHor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


        private Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnRegresarAddHorClicked(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            thor.Nombre = entNombreHor.Text;
            thor.HoraInicio = DateTime.Parse(entHoraIn.Text);
            thor.HoraSalida = DateTime.Parse(entHoraFin.Text);

            dthor.GuardarHorario(thor);


        }


    }
}
