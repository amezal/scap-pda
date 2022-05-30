using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.UserRol
{
    public partial class frmUserRol : Gtk.Window
    {
        private Gtk.Window caller;
        Dt_tbl_UserRol dtUR = new Dt_tbl_UserRol();
        private int idUserRolActual;

        public Window Caller { get => caller; set => caller = value; }
        public int IdUserRolActual { get => idUserRolActual; set => idUserRolActual = value; }

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
            this.llenarUser();
        }

        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            UserRol.frmAddUserRol frm = new frmAddUserRol();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnModifyActionActivated(object sender, EventArgs e)
        {
            UserRol.frmModUserRol frm = new frmModUserRol(IdUserRolActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();

        }



        protected void OnModifyActionChanged(object o, ChangedArgs args)
        {
        }
    }
}
