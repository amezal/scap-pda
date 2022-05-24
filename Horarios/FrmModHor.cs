using System;
using Gtk;

namespace ScapProject0.Horarios
{
    public partial class FrmModHor : Gtk.Window
    {

        public FrmModHor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackModHorClicked(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }
    }
}
