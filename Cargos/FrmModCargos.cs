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

            this.cbxDpto.Active = car.IdDepartamento - 1;
        }



        protected void llenarCampos()
        {
            this.entCargo.Text = this.car.NombreCargo;
        }


        public FrmModCargos(int idCargoActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.IdCargo = idCargoActual;
            this.car = dtcar.DatosCargo(IdCargo);
            this.llenarCampos();
            this.llenarCbxDpto();
            
        }


        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
