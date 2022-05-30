using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Entidades;
using ScapProject0.Datos;

namespace ScapProject0.RegistrosES
{
    public partial class FrmJustificaciones : Gtk.Window
    {
        private Gtk.Window caller;
        private List<int> ids;
        private int idEmp;

        Dt_tbl_justificaciones dtjus = new Dt_tbl_justificaciones();
        Dt_tbl_registroES dtreg = new Dt_tbl_registroES();
        TimeSpan horaEntrada;
        TimeSpan horaSalida;

        public Window Caller { get => caller; set => caller = value; }
        public List<int> Ids { get => ids; set => ids = value; }

        public FrmJustificaciones(int id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idEmp = id;
            ListStore horas = dtreg.ListarRegistros(id);
            horas.GetIterFirst(out TreeIter iter);
            //Console.WriteLine(horas.GetValue(iter, 7));
            TimeSpan entrada = TimeSpan.Parse(horas.GetValue(iter, 6).ToString());
            TimeSpan salida = TimeSpan.Parse(horas.GetValue(iter, 7).ToString());
            this.horaEntrada = entrada;
            this.horaSalida = salida;

            this.entHoraInicio.SetRange(entrada.Hours, salida.Hours);
            this.entHoraFin.SetRange(entrada.Hours, salida.Hours);
            this.entMinInicio.SetRange(entrada.Minutes, 59);
            this.entMinFin.SetRange(entrada.Minutes, 59);

            entMinInicio.Changed += HoraInicioChanged;
            entHoraInicio.Changed += HoraInicioChanged;
            entMinFin.Changed += HoraFinChanged;
            entHoraFin.Changed += HoraFinChanged;
        }

        void HoraInicioChanged(object sender, EventArgs e)
        {
            entHoraInicio.GetRange(out double min, out double max);
            if(entHoraInicio.Value > min)
            {
                entMinInicio.SetRange(0, 59);
            }
            else
            {
                if (entMinInicio.Value < horaEntrada.Minutes)
                {
                    entMinInicio.Value = horaEntrada.Minutes;
                }
                entMinInicio.SetRange(horaEntrada.Minutes, 59);

            }

            if (entHoraInicio.Value > max - 1)
            {
                entMinInicio.SetRange(0, horaSalida.Minutes);
            }
        }


        void HoraFinChanged(object sender, EventArgs e)
        {
            entHoraFin.GetRange(out double min, out double max);
            if (entHoraFin.Value > min)
            {
                entMinFin.SetRange(0, 59);
            }
            else
            {
                if (entMinFin.Value < horaEntrada.Minutes)
                {
                    entMinFin.Value = horaEntrada.Minutes;
                }
                entMinFin.SetRange(horaEntrada.Minutes, 59);

            }

            if (entHoraFin.Value > max - 1)
            {
                entMinFin.SetRange(0, horaSalida.Minutes);
            }
        }


        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }


        protected void OnCancelActionActivated(object sender, EventArgs e)
        {
            Console.WriteLine(entDesc.Buffer.Text);
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            bool guardado = true;
            Tbl_Justificacion tjus = new Tbl_Justificacion
            {
                Estado = 1,
                Descripcion = entDesc.Buffer.Text,
                FechaEntrada = cldInicio.Date,
                HoraEntrada = DateTime.Parse(entHoraInicio.Text + ":" + entMinInicio.Text + ":00"),
                FechaSalida = cldFin.Date,
                HoraSalida = DateTime.Parse(entHoraFin.Text + ":" + entMinFin.Text + ":00"),
            };

            int idJustificacion = dtjus.NuevaJustificacion(tjus);
            //int idJustificacion = 14;
            guardado = dtreg.Justificar(ids, idJustificacion);

            if (guardado)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Justificacion guardada correctamente");
                ms.Run();
                ms.Destroy();
            }

        }
    }
}
