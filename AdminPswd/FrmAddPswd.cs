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


        protected void llenarCbxUser()
        {
            List<Tbl_user> listUser = dtus.cbxUser();
            this.cbxUser.InsertText(0, "Seleccione...");

            foreach(Tbl_user dtus in listUser)
            {
                this.cbxUser.InsertText(dtus.Id_user, dtus.Nombres);
            }
            this.cbxUser.Active = 0;
        }
       
        public FrmAddPswd() :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();
            this.llenarCbxUser();

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
