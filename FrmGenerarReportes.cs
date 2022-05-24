using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;


namespace ScapProject0
{
    public partial class FrmGenerarReportes : Gtk.Window
    {
        Dt_tbl_empleado dtemp = new Dt_tbl_empleado();

        protected void llenarCbxeEmpleado()
        {
            ListStore datos = dtemp.cbxeEmpleados();
            cbxeEmp.Model = datos;
            cbxeEmp.TextColumn = 1;

            cbxeEmp.Entry.Completion = new EntryCompletion();
            cbxeEmp.Entry.Completion.Model = datos;
            cbxeEmp.Entry.Completion.TextColumn = 1;
        }

        public FrmGenerarReportes() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.llenarCbxeEmpleado();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }


        protected void OnCombobox1Changed(object sender, EventArgs e)
        {
        }
    }
}
