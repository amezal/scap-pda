using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.Empleados
{
    public partial class FrmAddEmp : Gtk.Window
    {
        private Gtk.Window caller;
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        Dt_tbl_departamento dtdp= new Dt_tbl_departamento();

        public Window Caller { get => caller; set => caller = value; }

        protected void llenarCbxDpto()
        {
            List<Tbl_Departamento> listDpto =  dtdp.cbxDpto();
            this.cbxDpto.InsertText(0, "Seleccione...");

            foreach(Tbl_Departamento tdpto in listDpto)
            {
                this.cbxDpto.InsertText(tdpto.IdDepartamento, tdpto.NombreDepartamento);
            }
            this.cbxDpto.Active = 0;
       }

        protected void llenarCbxCargo()
        {
            List<Tbl_Cargo> listCargo = dtcar.cbxCargo();
            this.cbxCargo.InsertText(0, "Seleccione...");

            foreach (Tbl_Cargo tcar in listCargo)
            {
                this.cbxCargo.InsertText(tcar.IdCargo, tcar.NombreCargo);
            }
            this.cbxCargo.Active = 0;
        }


        public FrmAddEmp() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.llenarCbxDpto();
            this.llenarCbxCargo();
        }

        protected void OnButton2Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(cbxDpto.Data.Count);
            this.Caller.Show();
            this.Hide();
        }

        protected void OnCbxDptoChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(this.cbxDpto.A);
        }
    }
}
