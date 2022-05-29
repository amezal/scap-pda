using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
namespace ScapProject0.Cargos
{
    public partial class FrmAddCargos : Gtk.Window
    {

        private Gtk.Window caller;
        MessageDialog ms = null;

        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();

        public Window Caller { get => caller; set => caller = value; }

        Dt_tbl_cargo dtc = new Dt_tbl_cargo();
        Tbl_Cargo tbc = new Tbl_Cargo();

        protected void llenarCbxSelectDpto()
        {
            List<Tbl_Departamento> listDpto = dtdp.cbxDpto();
            this.cbxSelectDpto.InsertText(0, "Seleccione...");

            foreach (Tbl_Departamento tdpto in listDpto)
            {
                this.cbxSelectDpto.InsertText(tdpto.IdDepartamento, tdpto.NombreDepartamento);
            }
            this.cbxSelectDpto.Active = 0;
        }

       


        public FrmAddCargos() :
              base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.llenarCbxSelectDpto();

        }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            FrmCargos fc = new FrmCargos();
            fc.Show();
            //this.caller.Show();
            this.Hide();
        }

        protected void OnGuardarActionActivated(object sender, EventArgs e)
        {
            string idDep = this.cbxSelectDpto.ActiveText.Trim().ToString();



            tbc.NombreCargo = this.TxtCargo.Text;
            tbc.Descripcion = this.TxtDescTuani.Text.Trim();
            tbc.IdDepartamento = dtc.getIdDep(idDep);
            //tbc.IdDepartamento = Convert.ToInt32(this.TxtDept.Text);

            try
            {
                if (dtc.guardarCargo(tbc))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Se guardó correctamente");
                    ms.Run();
                    ms.Destroy();

                    FrmAddCargos ac = new FrmAddCargos();
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
