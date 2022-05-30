using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.Opcion
{
    public partial class FrmModOpc : Gtk.Window
    {
        private Gtk.Window caller;

        Dt_tbl_Opcion dtop = new Dt_tbl_Opcion();

        private int idOpc;


        private Tbl_opcion  opc = new Tbl_opcion();

        public Window Caller { get => caller; set => caller = value; }
        public int IdOpc { get => idOpc; set => idOpc = value; }


        protected void llenarCampos()
        {
            this.txtOpc.Text = this.opc.Opcion;

        }





        public FrmModOpc(int id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idOpc = id;
            this.llenarCampos();
        }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {

            Tbl_opcion opc = new Tbl_opcion()
            {
                Id_opcion = idOpc,
                Opcion = txtOpc.Text,
                Estado = 2
            };

            if (dtop.ModificarOpcion(opc))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Opción modificada correctamente");
                ms.Run();
                ms.Destroy();
            }
        }

    }
}
