using System;
using Gtk;
using ScapProject0.Datos;

namespace ScapProject0.Empleados
{
    public partial class FrmEmp : Gtk.Window
    {

        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        private int empActual;
        private string query = "";

        public FrmEmp() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.llenarEmpleados();
        }

        protected void llenarEmpleados()
        {
            this.trvwEmpleado.Model = dtem.ListarEmpleados(query);
            string[] titulos = { "ID", "Nombres", "Apellidos", "Cargo", "Departamento" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwEmpleado.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnAgregarAction1Activated(object sender, EventArgs e)
        {
            FrmAddEmp frm = new FrmAddEmp();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnModificarAction1Activated(object sender, EventArgs e)
        {
            FrmModEmp frm = new FrmModEmp(empActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnTrvwEmpleadoCursorChanged(object sender, EventArgs e)
        {

            trvwEmpleado.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = trvwEmpleado.Model;
            model.GetIter(out TreeIter iter, path);
            int idEmpleado = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            empActual = idEmpleado;
        }

        protected void OnTrvwEmpleadoRowActivated(object o, RowActivatedArgs args)
        {
            var model = trvwEmpleado.Model;
            model.GetIter(out TreeIter iter, args.Path);
            String value = model.GetValue(iter, 0).ToString();
            Console.WriteLine(value);
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnBuscarActionActivated(object sender, EventArgs e)
        {
            this.trvwEmpleado.Model = dtem.ListarEmpleados(entBuscar.Text.Trim());
        }
    }
}
