using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using ScapProject0.Negocios;
using System.Text.RegularExpressions;

namespace ScapProject0.Empleados
{
    public partial class FrmModEmp : Gtk.Window
    {
        private FrmEmp caller;
        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();
        Dt_tbl_horario dthor = new Dt_tbl_horario();
        Ng_tbl_empleado ngemp = new Ng_tbl_empleado();
        private int idEmp;
        private Tbl_Empleado emp;


        public FrmEmp Caller { get => caller; set => caller = value; }
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
            this.cbxDpto.Model = dtdp.ListarDpto();
            this.cbxDpto.TextColumn = 1;
            for (int i = 0; i < cbxDpto.Model.NColumns; i++)
            {
                TreePath path = new TreePath(new int[] { i });
                cbxDpto.Model.GetIter(out TreeIter iter, path);
                int id = Convert.ToInt32(cbxDpto.Model.GetValue(iter, 0));
                if (emp.IdDepartamento == id)
                {
                    cbxDpto.Active = i;
                }
            }
        }

        protected void llenarCbxCargo()
        {
            this.cbxCargo.Model = dtcar.listarCargos();
            this.cbxCargo.TextColumn = 1;

            for (int i = 0; i < cbxCargo.Model.NColumns; i++)
            {
                TreePath path = new TreePath(new int[] { i });
                cbxCargo.Model.GetIter(out TreeIter iter, path);
                int id = Convert.ToInt32(cbxCargo.Model.GetValue(iter, 0));
                if(emp.IdCargo == id)
                {
                    cbxCargo.Active = i;
                }
            }
        }

        protected void llenarCbxHorario()
        {
            TreeModel model = dthor.ListarHorario();
            model.GetIterFirst(out TreeIter ti);
            int active = 0;
            int i = 0;
            do
            {
                int id = Convert.ToInt32(model.GetValue(ti, 0));
                string nombre = model.GetValue(ti, 1).ToString();
                model.SetValue(ti, 0, nombre);
                model.SetValue(ti, 1, id.ToString());
                if (emp.IdHorario == id)
                {
                    active = i;
                }
                i++;
            } while (model.IterNext(ref ti));

            cbxHorario.Model = model;
            cbxHorario.Active = active;
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

        protected void OnGuardarAction1Activated(object sender, EventArgs e)
        {
            bool valido = validar();
            if (!valido)
            {
                return;
            }
            cbxCargo.GetActiveIter(out TreeIter cargoiter);
            cbxHorario.GetActiveIter(out TreeIter horiter);

            var idCargo = Convert.ToInt32(cbxCargo.Model.GetValue(cargoiter, 0));
            var idHorario = Convert.ToInt32(cbxHorario.Model.GetValue(horiter, 1));

            Tbl_Empleado em = new Tbl_Empleado()
            {
                IdEmpleado = idEmp,
                NumCedula = entCedula.Text,
                PrimerNombre = entPrimerNombre.Text,
                SegundoNombre = entSegundoNombre.Text,
                PrimerApellido = entPrimerApellido.Text,
                SegundoApellido = entSegundoApellido.Text,
                FechaNacimiento = cldNac.Date,
                FechaIngreso = cldIngreso.Date,
                Sexo = cbxSexo.Active == 1,
                Telefono = entTel.Text,
                EmailPersonal = entEmailPer.Text,
                EmailCorporativo = entEmailCorp.Text,
                Direccion = entDireccion.Text,
                Observacion = entObservacion.Text,
                PIN = entPIN.Text,
                IdCargo = idCargo,
                IdHorario = idHorario
            };

            if (dtem.ModificarEmpleado(em))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Usuario modificado correctamente");
                this.caller.refresh();
                ms.Run();
                ms.Destroy();
            }
        }

        protected bool validar()
        {
            Regex cedula = new Regex("\\d{3}\\-\\d{6}\\-\\d{4}[A-Z]");
            Regex PIN = new Regex("\\d{4}");
            bool valido = true;
            void modal(string msg)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, msg);
                ms.Run(); ms.Destroy();
                valido = false;
            }
            if (String.IsNullOrEmpty(entCedula.Text.Trim()))
            {
                modal("La cedula no puede quedar vacia");
                entCedula.GrabFocus();
                return valido;
            }
            if (!cedula.IsMatch(entCedula.Text.Trim()))
            {
                modal("La cedula debe tener el formato xxx-xxxxxx-xxxxA");
                entCedula.GrabFocus();
                return valido;
            }
            if (ngemp.existe(entCedula.Text, "numCedula", this.idEmp))
            {
                modal("Ya existe el numero de Cedula");
                entCedula.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entPrimerNombre.Text.Trim()))
            {
                modal("El empleado debe tener primer nombre");
                entPrimerNombre.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entPrimerApellido.Text.Trim()))
            {
                modal("El empleado debe tener primer apellido");
                entPrimerApellido.GrabFocus();
                return valido;
            }
            if (cbxCargo.Active == -1)
            {
                modal("El empleado debe tener cargo");
                cbxCargo.GrabFocus();
                return valido;
            }
            if (String.IsNullOrEmpty(entEmailCorp.Text.Trim()))
            {
                modal("El empleado debe tener primer email corporativo");
                entEmailCorp.GrabFocus();
                return valido;
            }
            if (ngemp.existe(entEmailCorp.Text, "emailCorporativo", this.idEmp))
            {
                modal("Ya existe ese email");
                entEmailCorp.GrabFocus();
                return valido;
            }
            if (ngemp.existe(entTel.Text, "telefono", this.idEmp))
            {
                modal("Ya existe ese telefono");
                entTel.GrabFocus();
                return valido;
            }
            if (cbxSexo.Active == -1)
            {
                Console.WriteLine(cbxSexo.Active);
                modal("El empleade debe tener sexo");
                cbxSexo.GrabFocus();
                return valido;
            }
            if (cbxHorario.Active == -1)
            {
                modal("El empleado debe tener horario");
                cbxHorario.GrabFocus();
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
            if (String.IsNullOrEmpty(entDireccion.Text.Trim()))
            {
                modal("El empleado debe tener direccion");
                entDireccion.GrabFocus();
                return valido;
            }
            if (cldNac.Date.CompareTo(DateTime.Now.AddYears(-18)) > 0)
            {
                modal("El empleado debe ser mayor a 18 años");
                cldNac.GrabFocus();
                return valido;
            }
            return valido;
        }

    }
}
