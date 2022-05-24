using System;
using Gtk;
using ScapProject0.Datos;


namespace ScapProject0.Horarios
{
    public partial class Horario : Window
    {
        Dt_tbl_horario dth = new Dt_tbl_horario();

        public Horario() :
                base(WindowType.Toplevel)
        {
            this.Build();
            this.trvwHorario.Model = dth.ListarHorario();

            string[] titulos = { "ID", "Nombre", "Hora de entrada", "Hora de salida"};

            for (int i = 0; i < titulos.Length; i++)
            {
                this.trvwHorario.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        private Window caller;

        public Window Caller { get => caller; set => caller = value; }


        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            //ScapProject0.Horarios.FrmAddHor frm = new FrmAddHor();
            FrmAddHor frm = new FrmAddHor(); 
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnModifyActionActivated(object sender, EventArgs e)
        {
            //ScapProject0.Horarios.FrmModHor frm = new FrmModHor();
            FrmModHor frm = new FrmModHor();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnBtnBackHorClicked(object sender, EventArgs e)
        {
            caller.Show();
            this.Hide();
        }
    }
}
