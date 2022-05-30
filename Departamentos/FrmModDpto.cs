using System;
using Gtk;
namespace ScapProject0.Departamentos
{
    public partial class FrmModDpto : Window
    {

        public FrmModDpto() :
                base(WindowType.Toplevel)
        {
            this.Build();
        }

        private Window caller;

        public Window Caller { get => caller; set => caller = value; } 


        protected void OnButton2Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
