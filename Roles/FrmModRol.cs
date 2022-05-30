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
        private Ng_tbl_rolOpcion ngrolop = new Ng_tbl_rolOpcion();
        private ListStore trvwModel;

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


        protected void LlenarCampos()
        {
            this.txtID.Text = rol.Id_rol.ToString();
            this.txtRol.Text = rol.Rol;

            ListStore model = dtop.listarOpcion();
            model.GetIterFirst(out TreeIter ti);
            do
            {
                int id = Convert.ToInt32(model.GetValue(ti, 0));
                string nombre = model.GetValue(ti, 1).ToString();
                model.SetValue(ti, 0, nombre);
                model.SetValue(ti, 1, id.ToString());
            } while (model.IterNext(ref ti));

            cbxOpcion.Model = model;

            this.trvwModel = dtrolop.ListarRolOpcion(idRol);
            this.trvwRolOpcion.Model = this.trvwModel;
            string[] titulos = { "Opcion", "1", "2", "3"};

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwRolOpcion.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
            this.trvwRolOpcion.Columns[1].Visible = false;
            this.trvwRolOpcion.Columns[2].Visible = false;
            this.trvwRolOpcion.Columns[3].Visible = false;
        }

        protected void OnBtnAgregarClicked(object sender, EventArgs e)
        {
            bool existe = false;
            cbxOpcion.GetActiveIter(out TreeIter iter);
            int id = Convert.ToInt32(cbxOpcion.Model.GetValue(iter, 1));
            string nombre = cbxOpcion.Model.GetValue(iter, 0).ToString();

            trvwRolOpcion.Model.GetIterFirst(out TreeIter ti);
            do
            {
                int idOp = Convert.ToInt32(trvwRolOpcion.Model.GetValue(ti, 2));
                if (idOp == id)
                {
                    existe = true;
                }
            } while (trvwRolOpcion.Model.IterNext(ref ti));

            if (!existe)
            {
                trvwModel.AppendValues(nombre, "", id.ToString(), "");
                trvwRolOpcion.Model = trvwModel;
            }
            else
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "La opcion ya existe");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnGuardarActivated(object sender, EventArgs e)
        {
            bool guardado = false;

            //rol
            Tbl_rol rol = new Tbl_rol()
            {
                Id_rol = Convert.ToInt32(txtID.Text),
                Rol = this.txtRol.Text
            };
            guardado = dtrol.ModificarRol(rol);

            //rolopcion
            trvwRolOpcion.Model.GetIterFirst(out TreeIter ti);
            do
            {
                int idOp = Convert.ToInt32(trvwRolOpcion.Model.GetValue(ti, 2));
                if(!ngrolop.existe(idRol, idOp))
                {
                    dtrolop.NuevoRolOpcion(new Tbl_rolOpcion() { Id_rol = idRol, Id_opcion = idOp });
                }
            } while (trvwRolOpcion.Model.IterNext(ref ti));

            //modal
            if (guardado)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Rol modificado correctamente");
                this.caller.refresh();
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnCancelarActivated(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
