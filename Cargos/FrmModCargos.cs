using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
namespace ScapProject0.Cargos
{
    public partial class FrmModCargos : Gtk.Window
    {

        private Gtk.Window caller;

        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        private int idCargo; 
       
        private Tbl_Cargo car = new Tbl_Cargo();

        public Window Caller { get => caller; set => caller = value; }
        public int IdCargo { get => idCargo; set => idCargo = value; }

        protected void llenarCbxDpto()
        {
            List<Tbl_Departamento> listDpto = dtdp.cbxDpto();


            foreach (Tbl_Departamento tdpto in listDpto)
            {
                this.cbxDpto.InsertText(tdpto.IdDepartamento, tdpto.NombreDepartamento);
            }
            this.cbxDpto.Active = 0;
        }



        protected void llenarCampos()
        {
            this.entCargo.Text = this.car.NombreCargo;
            this.txtDesc.Text = car.Descripcion;
        }


        public FrmModCargos(int idCargoActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idCargo = idCargoActual;
            //this.IdCargo = idCargoActual;
            this.car = dtcar.DatosCargo(idCargo);
            this.llenarCampos();
            this.llenarCbxDpto();

            //lblPrueba.Text = IdCargo.ToString();

        }


        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnActualizarActionActivated(object sender, EventArgs e)
        {
            string idDep = this.cbxDpto.ActiveText.Trim().ToString();

            Tbl_Cargo tcar = new Tbl_Cargo()
            {
                IdCargo = idCargo,
                NombreCargo = entCargo.Text,
                Estado = 2,
                Descripcion = txtDesc.Text,
                IdDepartamento = dtcar.getIdDep(idDep)
            };

            if (dtcar.ModificarCargo(tcar))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Cargo modificado correctamente");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnCancelarActionActivated(object sender, EventArgs e)
        {
            FrmCargos fcar = new FrmCargos();
            fcar.Show();
            this.Hide();
        }
    }
}
