using System;
using Gtk;
namespace ScapProject0.Departamentos
{
    public partial class FrmAddDpto : Window
    {


        public FrmAddDpto() :
                base(WindowType.Toplevel)
        {
            this.Build();
        }

        private Window caller;

        public Window Caller { get => caller; set => caller = value; }


        protected void OnBtnBackAddDptoClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
