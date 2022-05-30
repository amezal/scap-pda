using System;
using ScapProject0.Entidades;
using ScapProject0.Datos;
using ScapProject0.Negocios;
using Gtk;

namespace ScapProject0.Roles
{
    public partial class FrmAddRol : Gtk.Window
    {
        FrmRol caller;
        private int idRol;
        private Tbl_rol rol;
        private Dt_tbl_rol dtrol = new Dt_tbl_rol();
        private Dt_tbl_Opcion dtop = new Dt_tbl_Opcion();
        private Dt_tbl_rolOpcion dtrolop = new Dt_tbl_rolOpcion();
        private Ng_tbl_rolOpcion ngrolop = new Ng_tbl_rolOpcion();
        private ListStore trvwModel;

        public FrmRol Caller { get => caller; set => caller = value; }
        public int IdRol { get => idRol; set => idRol = value; }


        public FrmAddRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnBtnGuardarActivated(object sender, EventArgs e)
        {
            bool guardado = false;

            //rol
            Tbl_rol rol = new Tbl_rol()
            {
                Rol = this.txtRol.Text
            };
            Console.WriteLine(txtRol.Text);
            guardado = dtrol.Nuevo(rol);

            //modal
            if (guardado)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Rol guardado correctamente");
                this.caller.refresh();
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnRegresarClicked(object sender, EventArgs e)
        {
            this.Hide();
            this.Caller.Show();
        }
    }
}
