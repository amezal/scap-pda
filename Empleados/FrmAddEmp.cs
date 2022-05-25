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
        Dt_tbl_horario dthor = new Dt_tbl_horario();


        public Window Caller { get => caller; set => caller = value; }

        protected void llenarCbxDpto()
        {
            List<Tbl_Departamento> listDpto =  dtdp.cbxDpto();
            foreach(Tbl_Departamento tdpto in listDpto)
            {
                this.cbxDpto.InsertText(tdpto.IdDepartamento, tdpto.NombreDepartamento);
            }

       }

        protected void llenarCbxCargo()
        {
            List<Tbl_Cargo> listCargo = dtcar.cbxCargo();
            foreach (Tbl_Cargo tcar in listCargo)
            {
                this.cbxCargo.InsertText(tcar.IdCargo, tcar.NombreCargo);
            }
        }

        protected void llenarCbxHorario()
        {
            List<Tbl_horario> listHorario = dthor.CbxHorario();
            foreach (Tbl_horario thor in listHorario)
            {
                this.cbxHorario.InsertText(thor.Id_Horario, thor.Nombre);
            }
        }

        protected void llenarCbxSexo()
        {
            this.cbxSexo.InsertText(0, "Mujer");
            this.cbxSexo.InsertText(1, "Hombre");
        }

        public FrmAddEmp() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.llenarCbxDpto();
            this.llenarCbxCargo();
            this.llenarCbxHorario();
            this.llenarCbxSexo();
            entPIN.Visibility = false;
            entPIN2.Visibility = false;
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

        protected void OnCancelarAction1Activated(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }

        protected void OnGuardarAction1Activated(object sender, EventArgs e)
        {

        }

        protected void OnButton3Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
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
    }
}
