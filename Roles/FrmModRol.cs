using System;
using ScapProject0.Entidades;
using ScapProject0.Datos;
using ScapProject0.Negocios;
using Gtk;

namespace ScapProject0.Roles
{
    public partial class FrmModRol : Gtk.Window
    {
        FrmRol caller;
        private int idRol;
        private Tbl_rol rol;
        private Dt_tbl_rol dtrol = new Dt_tbl_rol();
        private Dt_tbl_Opcion dtop = new Dt_tbl_Opcion();
        private Dt_tbl_rolOpcion dtrolop = new Dt_tbl_rolOpcion();

        public FrmRol Caller { get => caller; set => caller = value; }
        public int IdRol { get => idRol; set => idRol = value; }

        public FrmModRol(int id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            idRol = id;
            rol = dtrol.DatosRol(idRol);
            this.LlenarCampos();
        }

        protected void OnBtnRegresarClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnCancelarActionActivated(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void LlenarCampos()
        {
            this.txtID.Text = rol.Id_rol.ToString();
            this.txtRol.Text = rol.Rol;

            TreeModel model = dtop.listarOpcion();
            model.GetIterFirst(out TreeIter ti);
            do
            {
                int id = Convert.ToInt32(model.GetValue(ti, 0));
                string nombre = model.GetValue(ti, 1).ToString();
                model.SetValue(ti, 0, nombre);
                model.SetValue(ti, 1, id.ToString());
            } while (model.IterNext(ref ti));

            cbxOpcion.Model = model;

            this.trvwRolOpcion.Model = dtrolop.ListarRolOpcion(idRol);
            string[] titulos = { "Opcion", "", "", ""};

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwRolOpcion.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
            this.trvwRolOpcion.Columns[1].Visible = false;
            this.trvwRolOpcion.Columns[2].Visible = false;
            this.trvwRolOpcion.Columns[3].Visible = false;
        }
    }
}
