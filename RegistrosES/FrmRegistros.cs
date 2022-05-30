using System;
using Gtk;
using ScapProject0.Datos;
using ScapProject0.Entidades;
using System.Collections.Generic;

namespace ScapProject0.RegistrosES
{
    public partial class FrmRegistros : Gtk.Window
    {

        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        Dt_tbl_registroES dtreg = new Dt_tbl_registroES();
        private int idEmpActivo;
        Window caller = null;

        public Window Caller { get => caller; set => caller = value; }

        public FrmRegistros() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.idEmpActivo = 1;
            this.llenarCbxeEmpleado();

            this.trvwRegistros.Model = new ListStore(
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string));
            
            string[] titulos = {"ID", "Fecha", "Hora Entrada", "Hora Salida", "Horas Trabajadas", "Horas Extra", "", "", "Justificacion"};

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwRegistros.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
            trvwRegistros.Columns[6].Visible = false;
            trvwRegistros.Columns[7].Visible = false;
        }

        protected void llenarRegistros()
        {
            //this.trvwRegistros.Model = dtreg.ListarRegistros(idEmpActivo);
            ListStore model = dtreg.ListarRegistros(idEmpActivo);
            this.trvwRegistros.Model = model;
        }

        protected void llenarDatosEmpleado()
        {
            Tbl_Empleado emp = dtem.DatosEmpleado(idEmpActivo);
            this.label1.Text = emp.PrimerNombre + " " + 
            emp.SegundoNombre + " " + 
            emp.PrimerApellido + " " + 
            emp.SegundoApellido;
        }

        protected void llenarCbxeEmpleado()
        {
            ListStore datos = dtem.cbxeEmpleados();
            cbxeEmp.Model = datos;
            cbxeEmp.TextColumn = 1;

            cbxeEmp.Entry.Completion = new EntryCompletion();
            cbxeEmp.Entry.Completion.Model = datos;
            cbxeEmp.Entry.Completion.TextColumn = 1;
        }

        protected void OnJustificarActionActivated(object sender, EventArgs e)
        {
            ListStore model = dtreg.ListarRegistros(idEmpActivo);
            List<int> ids = new List<int>();

            model.GetIterFirst(out TreeIter iter);
            do
            {
                ids.Add(Convert.ToInt32(model.GetValue(iter, 0)));
            } while (model.IterNext(ref iter));

            //for (int i = 0; i < model.NColumns; i++)
            //{
            //    TreePath path = new TreePath(new int[] { i });
            //    model.GetIter(out TreeIter iter, path);
            //    int id = Convert.ToInt32(model.GetValue(iter, 0));
            //    ids[i] = id;
            //    Console.WriteLine("ID" + id);
            //}


            RegistrosES.FrmJustificaciones justificaciones = new FrmJustificaciones(idEmpActivo)
            {
                Ids = ids,
                Caller = this
            };

            justificaciones.Show();
            this.Hide();
        }

        protected void OnCbxeEmpChanged(object sender, EventArgs e)
        {
            cbxeEmp.GetActiveIter(out TreeIter iter);
            int idEmp = Convert.ToInt32(cbxeEmp.Model.GetValue(iter, 0));
            Console.WriteLine(iter);
            this.idEmpActivo = idEmp;
        }

        protected void OnBuscarActionActivated(object sender, EventArgs e)
        {
            this.llenarRegistros();
            this.llenarDatosEmpleado();
            Console.WriteLine(idEmpActivo);
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
