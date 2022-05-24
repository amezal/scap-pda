using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmMarcarES : Gtk.Window
    {
        public FrmMarcarES() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton17Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
