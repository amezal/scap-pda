using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using ScapProject0.Negocios;
using System.Text.RegularExpressions;

namespace ScapProject0.Horarios
{
    public partial class FrmAddHor : Gtk.Window
    {
        private Horarios.Horario caller;

        Dt_tbl_horario dthor = new Dt_tbl_horario();
        Ng_tbl_horario nghor = new Ng_tbl_horario();

        public Horario Caller { get => caller; set => caller = value; }

        public FrmAddHor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


        protected void OnBtnRegresarAddHorClicked(object sender, EventArgs e)
        {
            Caller.Show();
            this.Hide();
        }

        public bool Validar()
        {
            Regex hora = new Regex("\\d{2}\\:\\d{2}\\:\\d{2}");
            bool valido = true;
            void modal(string msg)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, msg);
                ms.Run(); ms.Destroy();
                valido = false;
            }

            if (String.IsNullOrEmpty(entNombreHor.Text.Trim()))
            {
                modal("Debe ingresar el nombre del Horario");
                entNombreHor.GrabFocus();
                return valido;
            }
            if (nghor.existe(entNombreHor.Text, "emailCorporativo"))
            {
                modal("Ya existe un Horario con este nombre");
                entNombreHor.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entHoraIn.Text.Trim()))
            {
                modal("Debe ingresar la hora de entrada");
                entHoraIn.GrabFocus();
                return valido;
            }
            if (!hora.IsMatch(entHoraIn.Text.Trim()))
            {
                modal("La hora de entrada debe tener el formato H:mm:ss");
                entHoraIn.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entHoraFin.Text.Trim()))
            {
                modal("Debe ingresar la hora de salida");
                entHoraFin.GrabFocus();
                return valido;
            }
            if (!hora.IsMatch(entHoraFin.Text.Trim()))
            {
                modal("La hora salida debe tener el formato H:mm:ss");
                entHoraFin.GrabFocus();
                return valido;
            }

            if (!hora.IsMatch(entAlmuerzo.Text.Trim()))
            {
                modal("La duracion del almuerzo debe tener el formato H:mm:ss");
                entAlmuerzo.GrabFocus();
                return valido;
            }
            return valido;
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            bool valido = Validar();
            if (!valido)
            {
                return;
            }

            Tbl_horario thor = new Tbl_horario()
            {
                Nombre = entNombreHor.Text,
                HoraInicio = DateTime.Parse(entHoraIn.Text),
                HoraSalida = DateTime.Parse(entHoraFin.Text),
                Almuerzo = DateTime.Parse(entAlmuerzo.Text)

            };


            if (dthor.GuardarHorario(thor))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Horario guardado correctamente");
                ms.Run();
                ms.Destroy();
                this.Caller.refresh();
            }
        }


    }
}
