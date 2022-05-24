using System;
using Gtk;

namespace ScapProject0.RegistrosES
{
    public partial class FrmJustificaciones : Gtk.Window
    {
        public FrmJustificaciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
