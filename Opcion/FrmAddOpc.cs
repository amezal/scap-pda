using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
namespace ScapProject0.Opcion
{
    public partial class FrmAddOpc : Gtk.Window
    {

        Tbl_opcion tbo = new Tbl_opcion();
        Dt_tbl_Opcion dtbo = new Dt_tbl_Opcion();
        MessageDialog ms = null;

        public FrmAddOpc() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }


        private Gtk.Window caller;
        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnSaveActivated(object sender, EventArgs e)
        {
          
            tbo.Opcion = this.txtOpc.Text;
            tbo.Estado = 1;
            try
            {
                if (dtbo.guardarOpcion(tbo))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se guardó correctamente");
                    ms.Run();
                    ms.Destroy();

                    FrmAddOpc op = new FrmAddOpc();
                    op.Show();

                    this.Destroy();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();

        }
    }
}
