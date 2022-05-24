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

        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();

        public Window Caller { get => caller; set => caller = value; }

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
            this.caller.Show();
            this.Hide();
        }
    }
}
