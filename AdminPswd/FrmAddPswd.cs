using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.AdminPswd
{
    public partial class FrmAddPswd : Gtk.Window
    {
        Dt_tbl_user dtus = new Dt_tbl_user();
        Tbl_user tus = new Tbl_user();
       //private Tbl_user tus;


       
       
        public FrmAddPswd() :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();


        }
        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
