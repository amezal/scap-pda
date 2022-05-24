using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmAccesoPrincipal : Gtk.Window
    {
        public FrmAccesoPrincipal() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            FrmLoginEmpleado frm = new FrmLoginEmpleado();
            frm.Show();
            this.Hide();
        }

        protected void OnButton2Clicked(object sender, EventArgs e)
        {
            FrmLoginAdmin frm = new FrmLoginAdmin();
            frm.Show();
            this.Hide();
        }

        protected void OnButton3OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }
    }
}