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

        public Window Caller { get => caller; set => caller = value; }
        public List<int> Ids { get => ids; set => ids = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }

        public FrmJustificaciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
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
