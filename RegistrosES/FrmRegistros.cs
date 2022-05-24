using System;
using Gtk;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.RegistrosES
{
    public partial class FrmRegistros : Gtk.Window
    {

        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        Dt_tbl_registroES dtreg = new Dt_tbl_registroES();
        private int idEmpActivo;
        Window caller = null;

        public Window Caller { get => caller; set => caller = value; }

        public FrmRegistros() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idEmpActivo = 1;
            this.llenarCbxeEmpleado();

            this.trvwRegistros.Model = new ListStore(typeof(string), typeof(string), typeof(string));
            string[] titulos = { "Fecha", "Hora Entrada", "Hora Salida" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwRegistros.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void llenarRegistros()
        {
            this.trvwRegistros.Model = dtreg.ListarRegistros(idEmpActivo);
        }

        protected void llenarDatosEmpleado()
        {
            Tbl_Empleado emp = dtem.DatosEmpleado(idEmpActivo);
            this.label1.Text = emp.PrimerNombre + " " + 
            emp.SegundoNombre + " " + 
            emp.PrimerApellido + " " + 
            emp.SegundoApellido;
        }

        protected void llenarCbxeEmpleado()
        {
            ListStore datos = dtem.cbxeEmpleados();
            cbxeEmp.Model = datos;
            cbxeEmp.TextColumn = 1;

            cbxeEmp.Entry.Completion = new EntryCompletion();
            cbxeEmp.Entry.Completion.Model = datos;
            cbxeEmp.Entry.Completion.TextColumn = 1;
        }

        protected void OnJustificarActionActivated(object sender, EventArgs e)
        {
            RegistrosES.FrmJustificaciones justificaciones = new FrmJustificaciones();
            justificaciones.Show();
            justificaciones.Caller = this;
            this.Hide();
        }

        protected void OnCbxeEmpChanged(object sender, EventArgs e)
        {
            cbxeEmp.GetActiveIter(out TreeIter iter);
            int idEmp = Convert.ToInt32(cbxeEmp.Model.GetValue(iter, 0));
            Console.WriteLine(iter);
            this.idEmpActivo = idEmp;
        }

        protected void OnBuscarActionActivated(object sender, EventArgs e)
        {
            this.llenarRegistros();
            this.llenarDatosEmpleado();
            Console.WriteLine(idEmpActivo);
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
