﻿using System;
using Gtk;
using System.Collections.Generic;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using ScapProject0.Negocios;
using System.Text.RegularExpressions;

namespace ScapProject0.Empleados
{
    public partial class FrmAddEmp : Gtk.Window
    {
        private Empleados.FrmEmp caller;
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        Dt_tbl_departamento dtdp = new Dt_tbl_departamento();
        Dt_tbl_horario dthor = new Dt_tbl_horario();
        Dt_tbl_empleado dtemp = new Dt_tbl_empleado();
        Ng_tbl_empleado ngemp = new Ng_tbl_empleado();


        public Empleados.FrmEmp Caller { get => caller; set => caller = value; }

        protected void llenarCbxDpto()
        {
            this.cbxDpto.Model = dtdp.ListarDpto();
            this.cbxDpto.TextColumn = 1;
        }

        protected void llenarCbxCargo()
        {
            this.cbxCargo.Model = dtcar.listarCargos();
            this.cbxCargo.TextColumn = 1;
        }

        protected void llenarCbxHorario()
        {
            TreeModel model = dthor.ListarHorario("");
            model.GetIterFirst(out TreeIter ti);

            do
            {
                int id = Convert.ToInt32(model.GetValue(ti, 0));
                string nombre = model.GetValue(ti, 1).ToString();
                model.SetValue(ti, 0, nombre);
                model.SetValue(ti, 1, id.ToString());
            } while (model.IterNext(ref ti));

            cbxHorario.Model = model;
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

        protected void OnCancelarAction1Activated(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
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
            if (ngemp.existe(entCedula.Text, "numCedula"))
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
            if (ngemp.existe(entEmailCorp.Text, "emailCorporativo"))
            {
                modal("Ya existe ese email");
                entEmailCorp.GrabFocus();
                return valido;
            }
            if (ngemp.existe(entTel.Text, "telefono"))
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
                modal("El empleade debe tener horario");
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

            Tbl_Empleado emp = new Tbl_Empleado()
            {
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

            if (dtemp.NuevoEmpleado(emp))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Usuario guardado correctamente");
                ms.Run();
                ms.Destroy();
                this.caller.refresh();
            }
        }
    }
}
