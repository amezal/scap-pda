using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.AdminPswd
{
    public partial class FrmAdminPswd : Gtk.Window
    {

        //Objetos Globales
        Dt_tbl_user dtus = new Dt_tbl_user();
        private int AdminPswdActual = 1;

        public FrmAdminPswd() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.trvwAdminPswd.Model = dtus.ListarUser();

            string[] titulos = { "ID", "Nombre", "Apellido", "Email", "Password" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwAdminPswd.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            //AdminPswd.FrmAddPswd frmAdd = new AdminPswd.FrmAddPswd();
            FrmAddPswd frmAdd = new FrmAddPswd();
            frmAdd.Show();
            frmAdd.Caller = this;
            this.Hide();
        }

        protected void OnModifyActionActivated(object sender, EventArgs e)
        {
          //  AdminPswd.FrmModPswd frm = new AdminPswd.FrmModPswd();
            FrmModPswd frm = new FrmModPswd(AdminPswdActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
