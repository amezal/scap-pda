using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.UserRol
{
    public partial class frmUserRol : Gtk.Window
    {
        private Gtk.Window caller;
        Dt_tbl_UserRol dtUR = new Dt_tbl_UserRol();

        public Window Caller { get => caller; set => caller = value; }

        protected void llenarUser()
        {
            this.tvwUserRol.Model = dtUR.listarUserRol();

            string[] titulos = { "ID", "Usuario", "Rol"};
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwUserRol.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }
        public frmUserRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            UserRol.frmAddUserRol frm = new frmAddUserRol();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }
    }
}
