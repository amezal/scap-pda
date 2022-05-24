using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.AdminPswd
{
    public partial class FrmModPswd : Gtk.Window
    {
        Dt_tbl_user dtus = new Dt_tbl_user();
        //Tbl_user tus = new Tbl_user();
        private int idUser;
        private Tbl_user tus;

        protected void llenarCampos()
        {
            entPwd.Text = tus.Pwd;
                      
        }

        protected void llenarCbxUser()
        {
            List<Tbl_user> listUser = dtus.cbxUser();
            foreach(Tbl_user tduser in listUser)
            {
                this.cbxUser.InsertText(tduser.Id_user, tduser.Nombres);
            }
            this.cbxUser.Active = tus.Id_user - 1;
        }


        public FrmModPswd(int idUserActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idUser = idUserActual;
            tus = dtus.DatosUser(IdUser);
            this.llenarCampos();
            this.llenarCbxUser();
                     
        }
        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }
        public int IdUser { get => idUser; set => idUser = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
