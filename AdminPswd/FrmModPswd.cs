using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using ScapProject0.Negocios;
using System.Text.RegularExpressions;


namespace ScapProject0.AdminPswd
{
    public partial class FrmModPswd : Gtk.Window
    {
        private FrmAddPswd caller;
        Dt_tbl_user dtus = new Dt_tbl_user();
        Ng_tbl_user nguser = new Ng_tbl_user();
        //Tbl_user tus = new Tbl_user();
        private int idUser;
        private Tbl_user tus;

        public FrmAddPswd Caller { get => caller; set => caller = value; }

        protected void llenarCampos()
        {
            entName.Text = tus.Nombres;
            entApellido.Text = tus.Apellidos;
            entEmail.Text = tus.Email;
            entUser.Text = tus.User;
            entPIN.Text = tus.Pwd;

                      
        }



        public FrmModPswd(int idUserActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idUser = idUserActual;
            tus = dtus.DatosUser(idUser);
            entPIN.Visibility = false;
            entPIN2.Visibility = false;


        }
       

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.Caller.Show();
            this.Hide();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            bool valido = validar();
            if (!valido)
            {
                return;
            }

            Tbl_user tus = new Tbl_user()
            {
                Id_user = idUser,
                Nombres = entName.Text,
                Apellidos = entApellido.Text,
                Email = entEmail.Text,
                User = entUser.Text,
                Pwd = entPIN.Text
            };
            if (dtus.ModificarUser(tus))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Usuario modificado correctamente");
               // this.caller.refresh();
                ms.Run();
                ms.Destroy();
            }
        }

        public Boolean validar()
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
            if (!PIN.IsMatch(entPIN.Text.Trim()))
            {
                modal("El PIN solo debe tener numeros");
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
    }
}
