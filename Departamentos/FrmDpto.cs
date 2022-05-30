using System;
using Gtk;
using ScapProject0.Datos;
namespace ScapProject0.Departamentos
{
    public partial class FrmDpto : Window
    {

        //Objetos Globales
        Dt_tbl_departamento dtDpto = new Dt_tbl_departamento();
        private Window caller;

        public Window Caller { get => caller; set => caller = value; }

        public FrmDpto() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.tvwDpto.Model = dtDpto.ListarDpto();

            string[] titulos = { "ID", "Departamento", "Extensión", "Email" };

            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwDpto.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }


        protected void OnAddActionActivated(object sender, EventArgs e)
        {
            FrmAddDpto frmp = new FrmAddDpto();
            frmp.Show();
            frmp.Caller = this;
            this.Hide();
        }

        protected void OnBtnBuscarActivated(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnBtnModificarActivated(object sender, EventArgs e)
        {
            FrmModDpto frmm = new FrmModDpto();
            frmm.Show();
            frmm.Caller = this;
            this.Hide();
        }
    }
}
