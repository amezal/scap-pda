using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
namespace ScapProject0.Departamentos
{
    public partial class FrmAddDpto : Window
    {
        MessageDialog ms = null;
        Tbl_Departamento tbd = new Tbl_Departamento();
        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();

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

        protected void OnGuardarActionActivated(object sender, EventArgs e)

        {
            tbd.NombreDepartamento= this.txtNombre.Text;
            tbd.Ext = this.txtExt.Text;
            tbd.Email = this.txtEmail.Text;
            try
            {
                if (dtdp.guardarDpto(tbd))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se guardo correctamente");
                    ms.Run();
                    ms.Destroy();

                    FrmAddDpto ac = new FrmAddDpto();
                    ac.Show();

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
