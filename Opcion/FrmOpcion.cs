using System;
using Gtk;
using ScapProject0.Datos;

namespace ScapProject0.Opcion
{
    public partial class FrmOpcion : Gtk.Window
    {
            Dt_tbl_Opcion dtop = new Dt_tbl_Opcion();
            private int OpcActual;
            MessageDialog ms = null;
            private string query = "";

        public FrmOpcion() :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();
            this.llenarOpcion();
            this.btnModify.Sensitive = false;
            this.btnDelete.Sensitive = false;

        }
        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        public void refresh()
        {
            this.twOpcion.Model = dtop.listarOpcion(query);
        }


        protected void llenarOpcion()
        {
            this.twOpcion.Model = dtop.listarOpcion(query);

            string[] titulos = { "ID", "Opcion" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.twOpcion.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnTwOpcionCursorChanged(object sender, EventArgs e)
        {
            twOpcion.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = twOpcion.Model;
            model.GetIter(out TreeIter iter, path);
            int idOpc = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            OpcActual = idOpc; 
            this.btnModify.Sensitive = true;
            this.btnDelete.Sensitive = true;

        }

        protected void OnBtnAddActivated(object sender, EventArgs e)
        {
            Opcion.FrmAddOpc frm = new FrmAddOpc();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnBtnSearchActivated(object sender, EventArgs e)
        {
            this.twOpcion.Model = dtop.buscarOpcion(entry1.Text.Trim());
        }

        protected void OnBtnDeleteActivated(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
            ButtonsType.YesNo, "¿Desea eliminar esta opción?");

            int result = md.Run();
            if (result == -8)
            {
                if (dtop.EliminarOpcion(OpcActual))
                {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Opción eliminada");
                    ms.Run();
                    ms.Destroy();
                    this.llenarOpcion();
                }
            }
            md.Destroy();
            this.twOpcion.Model = dtop.listarOpcion(query);

        }

        protected void OnBtnModifyActivated(object sender, EventArgs e)
        {
            if (OpcActual == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Seleccione una opción");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                Opcion.FrmModOpc frm = new Opcion.FrmModOpc(OpcActual);
                frm.Show();
                frm.Caller = this;
                this.Hide();
                Console.WriteLine(OpcActual);
            }
        }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}

