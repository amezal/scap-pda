using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmLoginAdmin : Gtk.Window
    {
        public FrmLoginAdmin() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton11OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }

        protected void OnButton12Clicked(object sender, EventArgs e)
        {
            FrmMenuAdmin frm = new FrmMenuAdmin();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }
    }
}
