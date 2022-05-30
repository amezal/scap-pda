using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
namespace ScapProject0.UserRol
{
    public partial class frmModUserRol : Gtk.Window
    {
        private Gtk.Window caller;

        Dt_tbl_rol dtr = new Dt_tbl_rol();
        Dt_tbl_user dtus = new Dt_tbl_user();
        Dt_tbl_UserRol dtur = new Dt_tbl_UserRol();
        Tbl_UserRol tur = new Tbl_UserRol();

        private int idUserRol;

        protected void llenarCbxRol()
        {
            List<Tbl_rol> listRol = dtur.cbxRol();


            foreach (Tbl_rol tro in listRol)
            {
           //     this.cbxRol.InsertText(tro.Id_rol, tro.Rol);
            }
       //    this.cbxRol.Active = 0;
        }

        protected void llenarCbxUser()
        {
            List<Tbl_user> listUser = dtus.cbxUser();


            foreach (Tbl_user tus in listUser)
            {
          //      this.cbxUser.InsertText(tus.Id_user, tus.User);
            }
          //  this.cbxUser.Active = 0;
        }

        public frmModUserRol(int idUserRolActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idUserRol = idUserRolActual;
            this.tur = dtur.DatosUserRol(idUserRol);
            this.llenarCbxRol();
            this.llenarCbxUser();
        }

        public int IdUserRol { get => idUserRol; set => idUserRol = value; }
        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnRegresarActivated(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
