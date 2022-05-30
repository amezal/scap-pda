using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.UserRol
{
    public partial class frmAddUserRol : Gtk.Window
    {
        private Gtk.Window caller;
        MessageDialog ms = null;
        Dt_tbl_rol dtr = new Dt_tbl_rol();
        Dt_tbl_user dtus = new Dt_tbl_user();
        Dt_tbl_UserRol dtur = new Dt_tbl_UserRol();
        Tbl_UserRol tur = new Tbl_UserRol();

        protected void llenarCbxSelectUser()
        {
            List<Tbl_user> listUser = dtus.cbxUser();
            this.llenarCbxSelectUser.InsertText(0, "Seleccione...");

            foreach (Tbl_user tus in listUser)
            {
                this.llenarCbxSelectUser.InsertText(tus.Id_user, tus.User);
            }
            this.cbxSelectDpto.Active = 0;
        }

        protected void llenarCbxSelectRol()
        {
            List<Tbl_rol> listRol = dtur.cbxRol();
            this.llenarCbxSelectRol.InsertText(0, "Seleccione...");

            foreach (Tbl_rol tro in listRol)
            {
                this.llenarCbxSelectRol.InsertText(tro.Id_rol, tro.Id_rol);
            }
            this.llenarCbxSelectRol.Active = 0;
        }


        public frmAddUserRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnRegresarActivated(object sender, EventArgs e)
        {
            this.Hide();
            this.caller.Show();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            string idUser = this.cbxUser.ActiveText.Trim().ToString();
            string idRol = this.cbxRol.ActiveText.Trim().ToString();

            tur.Id_rol = dtur.getIdRol(idRol);
            tur.Id_user = dtur.getIdUser(idUser);

            try
            {
                if (dtur.guardarUserRol(tur))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se guardó correctamente");
                    ms.Run();
                    ms.Destroy();

                    frmAddUserRol aus = new frmAddUserRol();
                    aus.Show();

                    this.Destroy();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
