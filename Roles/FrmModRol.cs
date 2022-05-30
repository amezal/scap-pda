using System;
namespace ScapProject0.Roles
{
    public partial class FrmModRol : Gtk.Window
    {
        FrmRol caller;
        private int idRol;

        public FrmRol Caller { get => caller; set => caller = value; }
        public int IdRol { get => idRol; set => idRol = value; }

        public FrmModRol(int id) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            idRol = id;
        }

        protected void OnBtnRegresarClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnCancelarActionActivated(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
