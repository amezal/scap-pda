using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.Horarios
{
    public partial class Horario : Window
    {
        Dt_tbl_horario dth = new Dt_tbl_horario();
        private int horActual;
        private string query = "";

        public Horario() :
                base(WindowType.Toplevel)
        {
            this.Build();
            this.llenarHorario();
            this.entBuscar.Changed += OnBuscarActionActivated;
            this.ModificarAction.Sensitive = false;
            this.EliminarAction.Sensitive = false;

        }

        protected void llenarHorario()
        {
            this.trvwHorario.Model = dth.ListarHorario(query);

            string[] titulos = { "ID", "Nombre", "Hora de entrada", "Hora de salida", "Tiempo de almuerzo" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwHorario.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void refresh()
        {
            this.trvwHorario.Model = dth.ListarHorario(query);
        }

        private Window caller;

        public Window Caller { get => caller; set => caller = value; }


        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            //ScapProject0.Horarios.FrmAddHor frm = new FrmAddHor();
            FrmAddHor frm = new FrmAddHor(); 
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnModifyActionActivated(object sender, EventArgs e)
        {
            //ScapProject0.Horarios.FrmModHor frm = new FrmModHor();
            FrmModHor frm = new FrmModHor(horActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnBtnBackHorClicked(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }

        protected void OnTrvwHorarioCursorChanged(object sender, EventArgs e)
        {
            trvwHorario.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = trvwHorario.Model;
            model.GetIter(out TreeIter iter, path);
            int idHorario = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            horActual = idHorario;
            this.ModificarAction.Sensitive = true;
            this.EliminarAction.Sensitive = true;
        }

        protected void OnTrvwHorarioRowActivated(object o, RowActivatedArgs args)
        {
            FrmModHor frm = new FrmModHor(horActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnBuscarActionActivated(object sender, EventArgs e)
        {
            this.trvwHorario.Model = dth.ListarHorario(entBuscar.Text.Trim());
        }

        protected void OnEliminarActionActivated(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
            ButtonsType.YesNo, "Desea eliminar a este usuario?");

            int result = md.Run();
            if (result == -8)
            {
                if (dth.DeleteHor(horActual))
                {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Horario eliminado");
                    ms.Run();
                    ms.Destroy();
                }
            }
            md.Destroy();
            this.trvwHorario.Model = dth.ListarHorario(query);
        }
    }
}
