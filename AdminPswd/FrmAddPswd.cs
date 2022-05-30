using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using ScapProject0.Negocios;
using System.Text.RegularExpressions;

namespace ScapProject0.AdminPswd
{
    public partial class FrmAddPswd : Gtk.Window
    {
        private AdminPswd.FrmAdminPswd caller;
        Dt_tbl_user dtus = new Dt_tbl_user();
        Tbl_user tus = new Tbl_user();
        Ng_tbl_user nguser = new Ng_tbl_user();
        //private Tbl_user tus;




        public FrmAddPswd() :
                base(Gtk.WindowType.Toplevel)
        {

            this.Build();


        }

        public FrmAdminPswd Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.Caller.Show();
            this.Hide();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            bool valido = Validar();
            if (!valido)
            {
                return;
            }

            Tbl_user user = new Tbl_user()
            {
                Nombres = entName.Text,
                Apellidos = entApellido.Text,
                Email = entEmail.Text,
                User = entUser.Text,
                Pwd = entPIN.Text

            };

            if (dtus.NuevoUser(user))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Usuario guardado correctamente");
                ms.Run();
                ms.Destroy();
                this.caller.refresh();
            }
        }

        protected void OnBtnPINPressed(object sender, EventArgs e)
        {
            entPIN.Visibility = true;
        }

        protected void OnBtnPINReleased(object sender, EventArgs e)
        {
            entPIN.Visibility = false;
        }

        protected void OnBtnPIN2Pressed(object sender, EventArgs e)
        {
            entPIN2.Visibility = true;

        }

        protected void OnBtnPIN2Released(object sender, EventArgs e)
        {
            entPIN2.Visibility = false;
        }


        protected bool Validar()
        {

            Regex PIN = new Regex("\\d{4}");
            bool valido = true;
            void modal(string msg)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, msg);
                ms.Run(); ms.Destroy();
                valido = false;
            }
            if (String.IsNullOrEmpty(entName.Text.Trim()))
            {
                modal("El nombre no puede quedar vacio");
                entName.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entApellido.Text.Trim()))
            {
                modal("El apellido no puede quedar vacio");
                entApellido.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entEmail.Text.Trim()))
            {
                modal("Debe ingresar un email");
                entEmail.GrabFocus();
                return valido;
            }
            if (nguser.existe(entEmail.Text, "email"))
            {
                modal("Ya existe ese email");
                entEmail.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entUser.Text.Trim()))
            {
                modal("Debe ingresar un nombre de usuario");
                entUser.GrabFocus();
                return valido;
            }
            if (nguser.existe(entUser.Text, "user"))
            {
                modal("Ya existe ese nombre de usuario");
                entEmail.GrabFocus();
                return valido;
            }

            if (String.IsNullOrEmpty(entPIN.Text.Trim()))
            {
                modal("El empleado debe tener PIN");
                entPIN.GrabFocus();
                return valido;
            }

            if (String.IsNullOrEmpty(entPIN2.Text.Trim()))
            {
                modal("Debe confirmar el PIN");
                entPIN2.GrabFocus();
                return valido;
            }
            if (!String.Equals(entPIN.Text.Trim(), entPIN2.Text.Trim()))
            {
                modal("Los PIN no son iguales");
                entPIN2.GrabFocus();
                return valido;
            }

            return valido;
        }

        protected void OnCancelarActionActivated(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }
    }
}
