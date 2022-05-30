using System;
using Gtk;

namespace ScapProject0
{
    public partial class FrmConfig : Gtk.Window
    {
        public FrmConfig() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            AdminPswd.FrmAdminPswd frm = new AdminPswd.FrmAdminPswd();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton5Clicked(object sender, EventArgs e)
        {
            Horarios.Horario frm = new Horarios.Horario();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton6Clicked(object sender, EventArgs e)
        {
            Cargos.FrmCargos frm = new Cargos.FrmCargos();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnButton7Clicked(object sender, EventArgs e)
        {
            Departamentos.FrmDpto frm = new Departamentos.FrmDpto();
            frm.Show();
            frm.Caller = this;
            Console.WriteLine("Hola");
            this.Hide();
        }

        protected void OnBtnOpcionClicked(object sender, EventArgs e)
        {
            Opcion.FrmOpcion op = new Opcion.FrmOpcion();
            op.Show();
            op.Caller = this;
        }

        protected void OnButton2Clicked(object sender, EventArgs e)
        {
            Opcion.FrmOpcion op = new Opcion.FrmOpcion();
            op.Show();
            op.Caller = this;
        }
    }
}
