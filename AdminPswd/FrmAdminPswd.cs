using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.AdminPswd
{
    public partial class FrmAdminPswd : Gtk.Window
    {

        //Objetos Globales
        Dt_tbl_user dtus = new Dt_tbl_user();
        private int userActual = 1;

        public FrmAdminPswd() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.trvwAdminPswd.Model = dtus.ListarUser();

            string[] titulos = { "ID", "Nombre", "Apellido", "Email", "Usuario","Password" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwAdminPswd.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }
        public void refresh()
        {
            this.trvwAdminPswd.Model = dtus.ListarUser();
        }

        protected void OnAddActionActivated(object sender, EventArgs e)
        {

            FrmAddPswd frmAdd = new FrmAddPswd();
            frmAdd.Show();
            frmAdd.Caller = this;
            this.Hide();
        }



        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnTrvwAdminPswdCursorChanged(object sender, EventArgs e)
        {
            trvwAdminPswd.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = trvwAdminPswd.Model;
            model.GetIter(out TreeIter iter, path);
            int idUser = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            userActual = idUser;
            this.ModificarAction2.Sensitive = true;
            this.EliminarAction1.Sensitive = true;
        }

        protected void OnTrvwAdminPswdRowActivated(object o, RowActivatedArgs args)
        {
            /*FrmModPswd frm = new FrmModPswd(userActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
            */           
        }

        protected void OnEliminarAction1Activated(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
            ButtonsType.YesNo, "Desea eliminar a este usuario?");

            int result = md.Run();
            if (result == -8)
            {
                if (dtus.EliminarUser(userActual))
                {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Usuario eliminado");
                    ms.Run();
                    ms.Destroy();
                }
            }
            md.Destroy();
            this.trvwAdminPswd.Model = dtus.ListarUser();
        }

        protected void OnModificarAction2Activated(object sender, EventArgs e)
        {
            /*
            FrmModPswd frm = new FrmModPswd(userActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
            */           
        }
    }
}
