using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmMenuAdmin : Gtk.Window
    {
        public FrmMenuAdmin() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton25Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnButton24Clicked(object sender, EventArgs e)
        {
            FrmGenerarReportes frm = new FrmGenerarReportes();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton22Clicked(object sender, EventArgs e)
        {
            Empleados.FrmEmp frm = new Empleados.FrmEmp();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton23Clicked(object sender, EventArgs e)
        {
            RegistrosES.FrmRegistros frm = new RegistrosES.FrmRegistros();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnConfiguracionActivated(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }
    }
}
