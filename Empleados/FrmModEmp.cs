using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;

namespace ScapProject0.Empleados
{
    public partial class FrmModEmp : Gtk.Window
    {
        private Gtk.Window caller;
        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();
        Dt_tbl_horario dthor = new Dt_tbl_horario();
        private int idEmp;
        private Tbl_Empleado emp;


        public Window Caller { get => caller; set => caller = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }

        protected void llenarCampos()
        {
            //Tbl_Empleado emp = dtem.DatosEmpleado(idEmp);
            entId.Text = emp.IdEmpleado.ToString();
            entPrimerNombre.Text = emp.PrimerNombre;
            entSegundoNombre.Text = emp.SegundoNombre;
            entPrimerApellido.Text = emp.PrimerApellido;
            entSegundoApellido.Text = emp.SegundoApellido;
            entCedula.Text = emp.NumCedula;
            entTel.Text = emp.Telefono;
            entEmailCorp.Text = emp.EmailCorporativo;
            entEmailPer.Text = emp.EmailPersonal;
            entPIN.Text = emp.PIN;
            entDireccion.Text = emp.Direccion;
            entObservacion.Text = emp.Observacion;
            cldNac.Date = emp.FechaNacimiento;
            cldIngreso.Date = emp.FechaIngreso;

        }

        protected void llenarCbxDpto()
        {
            List<Tbl_Departamento> listDpto = dtdp.cbxDpto();
            foreach (Tbl_Departamento tdpto in listDpto)
            {
                this.cbxDpto.InsertText(tdpto.IdDepartamento, tdpto.NombreDepartamento);
            }
            this.cbxDpto.Active = emp.IdDepartamento - 1;
        }

        protected void llenarCbxCargo()
        {
            List<Tbl_Cargo> listCargo = dtcar.cbxCargo();
           
            foreach (Tbl_Cargo tcar in listCargo)
            {
                this.cbxCargo.InsertText(tcar.IdCargo, tcar.NombreCargo);
                Console.WriteLine(tcar.IdCargo + tcar.NombreCargo);
            }
            this.cbxCargo.Active = emp.IdCargo - 1;
        }

        protected void llenarCbxHorario()
        {
            List<Tbl_horario> listHorario = dthor.CbxHorario();
            foreach (Tbl_horario thor in listHorario)
            {
                this.cbxHorario.InsertText(thor.Id_Horario, thor.Nombre);
            }
            this.cbxHorario.Active = emp.IdHorario - 1;
        }

        protected void llenarCbxSexo()
        {
            this.cbxSexo.InsertText(0, "Mujer");
            this.cbxSexo.InsertText(1, "Hombre");
            this.cbxSexo.Active = emp.Sexo ? 1 : 0;
        }

        public FrmModEmp(int idEmpActual) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idEmp = idEmpActual;
            emp = dtem.DatosEmpleado(idEmp);
            this.llenarCampos();
            this.llenarCbxDpto();
            this.llenarCbxCargo();
            this.llenarCbxHorario();
            this.llenarCbxSexo();
            entPIN.Visibility = false;
            entPIN2.Visibility = false;
        }


        protected void OnButton3Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnCancelarAction1Activated(object sender, EventArgs e)
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
