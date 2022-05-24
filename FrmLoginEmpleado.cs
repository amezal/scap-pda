using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmLoginEmpleado : Gtk.Window
    {
        public FrmLoginEmpleado() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton14Clicked(object sender, EventArgs e)
        {
            FrmMarcarES frm = new FrmMarcarES();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton13COnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }
    }
}
