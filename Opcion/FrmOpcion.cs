using System;
using Gtk;
using ScapProject0.Datos;

namespace ScapProject0.Opcion
{
    public partial class FrmOpcion : Gtk.Window
    {
          Dt_tbl_Opcion dtop = new Dt_tbl_Opcion();

        public FrmOpcion() :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();
            this.llenarOpcion();

        }
        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void llenarOpcion()
        {
            this.twOpcion.Model = dtop.listarOpcion();

            string[] titulos = { "ID", "Opcion" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.twOpcion.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnBtnAddActivated(object sender, EventArgs e)
        {
            Opcion.FrmAddOpc frm = new FrmAddOpc();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }
    }
}
