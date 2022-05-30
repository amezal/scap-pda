using System;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using Gtk;

namespace ScapProject0.Roles
{
    public partial class FrmRol : Gtk.Window
    {
        Dt_tbl_rol dtrol = new Dt_tbl_rol();
        string query = "";
        int rolActual;

        public FrmRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.ListarRoles();
            this.btnModificar.Sensitive = false;
            this.btnEliminar.Sensitive = false;
        }
        protected void ListarRoles()
        {
            this.trvwRol.Model = dtrol.ListarRoles(query);

            string[] titulos = { "ID", "Rol", "Opciones" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwRol.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnTrvwRolCursorChanged(object sender, EventArgs e)
        {
            trvwRol.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = trvwRol.Model;
            model.GetIter(out TreeIter iter, path);
            int idRol = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            rolActual = idRol;
            this.btnModificar.Sensitive = true;
            this.btnEliminar.Sensitive = true;
        }

        protected void OnTrvwRolRowActivated(object o, RowActivatedArgs args)
        {
            //FrmModEmp frm = new FrmModEmp(empActual);
            //frm.Show();
            //frm.Caller = this;
            //this.Hide();
        }

        protected void OnBtnModificarActivated(object sender, EventArgs e)
        {
            FrmModRol frm = new FrmModRol(rolActual) { Caller = this };
            frm.Show();
            this.Hide();
        }
    }
}
