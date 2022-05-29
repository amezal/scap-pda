using System;
using Gtk;
using System.Timers;
using ScapProject0.Entidades;
using ScapProject0.Datos;
using ScapProject0.Negocios;

namespace ScapProject0
{
    public partial class FrmMarcarES : Gtk.Window
    {
        Dt_tbl_empleado dtem = new Dt_tbl_empleado();
        Dt_tbl_registroES dtreg = new Dt_tbl_registroES();
        Dt_tbl_empleadoRegistro dtEmpReg = new Dt_tbl_empleadoRegistro();
        Ng_tbl_registroES ngreg = new Ng_tbl_registroES();
        private Gtk.Window caller;
        private int idEmp = 2;
        bool registroExiste;
        public Window Caller { get => caller; set => caller = value; }
        public int IdEmp { get => idEmp; set => idEmp = value; }

        public FrmMarcarES() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            DateTime hoy = DateTime.Now;
            registroExiste = ngreg.existe("fecha", hoy.ToString(string.Format("{0}d", "yyyy-MM-d")), idEmp);
            if (registroExiste)
            {
                Console.WriteLine("existe");
                btnSalida.Sensitive = true;
                btnEntrada.Sensitive = false;
            }
            else
            {
                Console.WriteLine("no existe");
                btnSalida.Sensitive = false;
                btnEntrada.Sensitive = true;
            }

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += tick;
            timer.Start();

            this.setearFuentes();

            Tbl_Empleado emp = dtem.DatosEmpleado(idEmp);
            labelBienvenida.Text = $"{(emp.Sexo ? "Bienvenido, ": "Bienvenida, ")}{emp.PrimerNombre}";
        }

        private void setearFuentes()
        {
            Pango.FontDescription txt = new Pango.FontDescription()
            {
                Stretch = Pango.Stretch.UltraExpanded,
                Size = Convert.ToInt32(40 * Pango.Scale.PangoScale),
                Family = "sans serif",
            };
    labelHora.ModifyFont(font_desc:txt);
            labelHora.Text = DateTime.Now.TimeOfDay.ToString();

            Pango.FontDescription btn = new Pango.FontDescription()
            {
                Size = Convert.ToInt32(20 * Pango.Scale.PangoScale),
                Family = "sans serif"
            };
    btnEntrada.Child.ModifyFont(btn);
            btnSalida.Child.ModifyFont(btn);
        }

        private void tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.TimeOfDay.ToString();
        }

        protected void OnButton17Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnBtnEntradaClicked(object sender, EventArgs e)
        {
            btnSalida.Sensitive = true;
            btnEntrada.Sensitive = false;

            bool guardado = false;
            int idReg;
            Tbl_registroES reg = new Tbl_registroES()
            {
                Fecha = DateTime.Now,
                HoraEntrada = DateTime.Now,
            };
            idReg = dtreg.NuevoRegistro(reg);
            guardado = idReg != -1;

            Tbl_empleadoRegistro empReg = new Tbl_empleadoRegistro()
            {
                IdRegistro = idReg,
                IdEmpleado = idEmp
            };
            guardado = dtEmpReg.NuevoEmpReg(empReg);

            if (guardado)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, "Registro agregado correctamente");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnSalidaClicked(object sender, EventArgs e)
        {
            btnSalida.Sensitive = false;
        }
    }
}
